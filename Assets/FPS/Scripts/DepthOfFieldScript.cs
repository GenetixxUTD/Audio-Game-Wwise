using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.Rendering;

public class DepthOfFieldScript : MonoBehaviour
{
    public GameObject Camera;
    public UnityEngine.Rendering.VolumeProfile volumeProfile;


    UnityEngine.Rendering.Universal.DepthOfField dof;
    PlayerWeaponsManager m_WeaponsManager;

    private void Start()
    {
        m_WeaponsManager = GetComponent<PlayerWeaponsManager>();

        volumeProfile = Camera.GetComponent<UnityEngine.Rendering.Volume>()?.profile;
        if(!volumeProfile) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));
 
        // You can leave this variable out of your function, so you can reuse it throughout your class.
   
 
        if(!volumeProfile.TryGet(out dof)) throw new System.NullReferenceException(nameof(dof));


    }

    private void Update()
    {
        if (m_WeaponsManager.IsAiming)
        {
            dof.gaussianStart.value = 65f;
            dof.gaussianEnd.value = 110f;
        }
        else
        {
            dof.gaussianStart.value = 20f;
            dof.gaussianEnd.value = 40f;
        }
    }

}
