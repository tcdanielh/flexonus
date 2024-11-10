using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class OVRManager : NetworkBehaviour
{
    public Transform chestPos;
    public MovementRecognizer move;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
                move.FireBallSpawn();
            
        }
    }
}