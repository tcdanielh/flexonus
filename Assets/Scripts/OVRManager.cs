using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class OVRManager : NetworkBehaviour
{
    public Transform chestPos;

    public MovementRecognizer move;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    [ServerRpc]
    public void RequestSpellSpawnServerRpc()
    {
        move.FireBallSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!IsServer)
            {
                RequestSpellSpawnServerRpc();
            }
            else
            {
                move.FireBallSpawn();    
            }
            
        }       
    }
}
