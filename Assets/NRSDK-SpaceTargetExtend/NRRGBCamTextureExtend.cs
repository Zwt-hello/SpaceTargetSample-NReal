using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class NRRGBCamTextureExtend : CameraModelView
{
    public NRRGBCamTextureExtend() : base(CameraImageFormat.RGB_888)
    {

    }

    private byte[] rawdata;
    public byte[] GetRawImgeData()
    {
        if (rawdata != null)
            return rawdata;
        else
            return null;
    }
    protected override void OnRawDataUpdate(FrameRawData frame)
    {
        //base.OnRawDataUpdate(frame);
        rawdata = frame.data;
    }
}
