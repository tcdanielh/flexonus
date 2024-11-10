using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject Zap;
    GameObject zap;
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.transform.CompareTag("hittable"))
        {
            zap = Instantiate(Zap, transform.position, transform.rotation);
            StartCoroutine(WaitToEnd(1f, zap));
            Destroy(transform.parent.GetChild(0).gameObject);
            Destroy(transform.parent.GetChild(1).gameObject);
        }
    }
    IEnumerator WaitToEnd(float delayTime, GameObject zap)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(zap);
        Destroy(transform.gameObject);
    }
}
