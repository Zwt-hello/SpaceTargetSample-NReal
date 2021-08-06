using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceTarget.Runtime;

public class NRealProvider : IARBaseProvider
{
    private NRRGBCamTextureExtend nrealRGBCam;

    public NRealProvider(NRRGBCamTextureExtend rgbcam)
    {
        nrealRGBCam = rgbcam;
    }
    public IARBase Create()
    {
        return new NRealImplemention(nrealRGBCam);
    }
}