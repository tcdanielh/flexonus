using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fracture : NetworkBehaviour
{
    public GameObject fracturedObject;

    private void Start()
    {
        IsKenObject(fracturedObject);
    }

    //
    // [ServerRpc(RequireOwnership = false)]
    // private void InstantiateFracServerRpc()
    // {
    //     
    //     GameObject temp = Instantiate(fracturedObject, transform.position, transform.rotation);
    //     temp.GetComponent<NetworkObject>().Spawn();
    //     Destroy(transform.gameObject);
    //
    // }
    // private void InstantiateFrac()
    // {
    //     GameObject temp = Instantiate(fracturedObject, transform.position, transform.rotation);
    //     temp.GetComponent<NetworkObject>().Spawn();
    //     Destroy(transform.gameObject);
    //
    // }
    //
    // public void FracSpawn()
    // {
    //     if (!IsServer)
    //     {
    //         InstantiateFracServerRpc();
    //     }
    //     else
    //     {
    //         InstantiateFrac();
    //     }
    // }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("attack"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            fracturedObject.SetActive(true);
            ShatterObject(fracturedObject);
            StartCoroutine(Disappear());
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("attack"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            fracturedObject.SetActive(true);
            ShatterObject(fracturedObject);
            StartCoroutine(Disappear());
        }
    }

    void ShatterObject(GameObject fracturedObject)
    {
        fracturedObject.SetActive(true);

        // Apply forces to each piece of the fractured object
        foreach (Transform piece in fracturedObject.transform)
        {
            Rigidbody rb = piece.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                rb.isKinematic = false;
                // Apply a random explosion force for a shattering effect
                Vector3 explosionDir = (piece.transform.position - fracturedObject.transform.position).normalized;
                float explosionForce = Random.Range(10f, 50f);
                rb.AddForce(explosionDir * explosionForce);
                rb.isKinematic = false;
            }
        }
    }

    void IsKenObject(GameObject fracturedObject)
    {
        fracturedObject.SetActive(true);

        // Apply forces to each piece of the fractured object
        foreach (Transform piece in fracturedObject.transform)
        {
            Rigidbody rb = piece.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
