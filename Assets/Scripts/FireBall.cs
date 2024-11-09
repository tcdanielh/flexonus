using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject FireCracker;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "hittable"){
            GameObject fireCracker = Instantiate(FireCracker, transform.position, transform.rotation);

            //fireCracker.GetComponent<Rigidbody>().velocity = transform.gameObject.GetComponent<Rigidbody>().velocity;

            Destroy(transform.gameObject);
        }
        
    }
}
