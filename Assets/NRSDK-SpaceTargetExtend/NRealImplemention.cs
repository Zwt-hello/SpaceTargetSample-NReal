using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceTarget.Runtime;
using NRKernal;

public class NRealImplemention : IARBase
{
    private NRRGBCamTextureExtend m_NRRGBCamTexture;
    public NRealImplemention(NRRGBCamTextureExtend nrealRGBCam)
    {
        m_NRRGBCamTexture = nrealRGBCam;
    }

    public Pose ARCameraTrackingPose()
    {
        return NRFrame.CenterEyePose;
    }

    public ARBaseSessionTrackingState ARSessionTrackingState()
    {
        ARBaseSessionTrackingState baseTrackingState = ARBaseSessionTrackingState.NONE;
        if (NRFrame.LostTrackingReason == LostTrackingReason.NONE)
        {
            baseTrackingState = ARBaseSessionTrackingState.TRACKING;
        }
        else
        {
            baseTrackingState = ARBaseSessionTrackingState.LIMITED;
        }
        return baseTrackingState;
    }

    ARBaseCameraIntrinsics IARBase.ARCameraIntrinsics()
    {
        //NRSDK tip
        //[fx 0 cx
        //0 fy cy
        //0 0 1]

        //[fx fy] focal length
        //[cx cy] principal point

        NativeMat3f nativeMat = NRFrame.GetRGBCameraIntrinsicMatrix();
        Vector2 focalLength = new Vector2(nativeMat.column0.X, nativeMat.column1.Y);
        Vector2 principalPoint = new Vector2(nativeMat.column2.X, nativeMat.column2.Y);
        Vector2Int resulution = new Vector2Int(m_NRRGBCamTexture.Width, m_NRRGBCamTexture.Height);

        ARBaseCameraIntrinsics camIntrinsics = new ARBaseCameraIntrinsics
        {
            focalLength = focalLength,
            principalPoint = principalPoint,
            resolution = resulution
        };
        return camIntrinsics;
    }

    ARBaseCameraImageData IARBase.ARCameraRawImageData()
    {
        ARBaseCameraImageData data = new ARBaseCameraImageData
        {
            rawImageData = m_NRRGBCamTexture.GetRawImgeData(),
            supportedTextureFormat = SupportedTextureFormat.RGB24,
            rawImageOrientation = CameraImageOrientation.NONE
        };
        return data;
    }
}