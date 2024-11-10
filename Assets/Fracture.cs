using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    public GameObject fracturedObject;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("attack"))
        {
            fracturedObject = Instantiate(fracturedObject, transform.position, transform.rotation);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(Disappear());
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3f);
        Destroy(fracturedObject);
        Destroy(gameObject);
    }
}
