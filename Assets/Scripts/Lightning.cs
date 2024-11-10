using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Lightning : NetworkBehaviour
{
    public GameObject zap;
    
    [ServerRpc(RequireOwnership = false)]
    private void InstantiateZapServerRpc()
    {
        
        GameObject temp = Instantiate(zap, transform.position, transform.rotation);
        temp.GetComponent<NetworkObject>().Spawn();
        Destroy(transform.gameObject);
    
    }
    private void InstantiateZap()
    {
        GameObject temp = Instantiate(zap, transform.position, transform.rotation);
        temp.GetComponent<NetworkObject>().Spawn();
        Destroy(transform.gameObject);
    
    }

    public void ZapSpawn()
    {
        if (!IsServer)
        {
            InstantiateZapServerRpc();
        }
        else
        {
            InstantiateZap();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("hittable"))
        {
            ZapSpawn();
            StartCoroutine(WaitToEnd(1f, zap));
            
            Destroy(transform.gameObject);
            
        }
        if (other.gameObject.name.EndsWith("EffectMesh"))
        {
            ZapSpawn();
            StartCoroutine(WaitToEnd(1f, zap));
        
            Destroy(transform.gameObject);
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("hittable"))
        {
            ZapSpawn();
            StartCoroutine(WaitToEnd(1f, zap));
            
            Destroy(transform.gameObject);
            
        }
        
        if (other.gameObject.name.EndsWith("EffectMesh"))
        {

            ZapSpawn();
            StartCoroutine(WaitToEnd(1f, zap));
            
            Destroy(transform.gameObject);

        }
    }

    IEnumerator WaitToEnd(float delayTime, GameObject zap)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(zap);
        Destroy(transform.gameObject);
    }
}
