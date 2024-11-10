using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Fracture : NetworkBehaviour
{
    public GameObject fracturedObject;
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
                // Apply a random explosion force for a shattering effect
                Vector3 explosionDir = (piece.transform.position - fracturedObject.transform.position).normalized;
                float explosionForce = Random.Range(100f, 500f);
                rb.AddForce(explosionDir * explosionForce);
            }
        }
    }


    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
