using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpaceTarget.Runtime;

public class NRealManager : MonoBehaviour
{
    [SerializeField] SpaceTargetBehaviour m_SpaceTarget;
    private NRRGBCamTextureExtend nrRGBCam;

    // Start is called before the first frame update
    void Start()
    {
        nrRGBCam = new NRRGBCamTextureExtend();
        nrRGBCam.Play();

        IARBaseProvider mARProvider = new NRealProvider(nrRGBCam);
        m_SpaceTarget.StartTracking(mARProvider);

    }

    private void OnDestroy()
    {
        nrRGBCam?.Stop();
        m_SpaceTarget?.StopTracking();
    }
    // Update is called once per frame
    void Update()
    {

    }
}