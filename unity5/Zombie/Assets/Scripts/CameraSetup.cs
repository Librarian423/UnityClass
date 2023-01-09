using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;


public class CameraSetup : MonoBehaviourPun
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;

        if (photonView.IsMine)
        {
            var brain = Camera.main.GetComponent<CinemachineBrain>();
            var vcam = brain.ActiveVirtualCamera as CinemachineVirtualCamera;
            vcam.Follow = transform;
            vcam.LookAt = transform;
        }
    }

  
}
