using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class OVRManager : MonoBehaviour
{
    private bool onlyOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onlyOnce) 
            return;
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            NetworkManager.Singleton.StartHost();
            onlyOnce = true;
        }
        
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            NetworkManager.Singleton.StartClient();
            onlyOnce = true;
        }
    }
}
