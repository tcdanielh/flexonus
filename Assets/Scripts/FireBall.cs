using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject FireCracker;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "hittable"){
            GameObject fireCracker = Instantiate(FireCracker, transform.position, transform.rotation);
            fireCracker.GetComponent<NetworkObject>().Spawn();
            //fireCracker.GetComponent<Rigidbody>().velocity = transform.gameObject.GetComponent<Rigidbody>().velocity;
            Destroy(transform.gameObject);
            // if other.gameObject.GetComponent<h>()
        }

        if (other.gameObject.name.EndsWith("EffectMesh"))
        {
            GameObject fireCracker = Instantiate(FireCracker, transform.position, transform.rotation);
            fireCracker.GetComponent<NetworkObject>().Spawn();
            //fireCracker.GetComponent<Rigidbody>().velocity = transform.gameObject.GetComponent<Rigidbody>().velocity;

            Destroy(transform.gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "hittable"){
            GameObject fireCracker = Instantiate(FireCracker, transform.position, transform.rotation);
            fireCracker.GetComponent<NetworkObject>().Spawn();
            //fireCracker.GetComponent<Rigidbody>().velocity = transform.gameObject.GetComponent<Rigidbody>().velocity;

            Destroy(transform.gameObject);
        }
        
        if (other.gameObject.name.EndsWith("EffectMesh"))
        {
            GameObject fireCracker = Instantiate(FireCracker, transform.position, transform.rotation);
            fireCracker.GetComponent<NetworkObject>().Spawn();
            //fireCracker.GetComponent<Rigidbody>().velocity = transform.gameObject.GetComponent<Rigidbody>().velocity;

            Destroy(transform.gameObject);
        }
        
    }
}
