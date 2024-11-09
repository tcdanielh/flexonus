using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Input;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 100;
    public GameFlowManager gameFlowManager;
    void Start()
    {
        //gameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
    }

    void OnCollisionEnter(Collision collision){
        if (collision.transform.tag == "attack"){
            Attack attack = collision.transform.GetComponent<Attack>();
            TakeDamage(attack.damage);
            StartCoroutine(ContinuousDamage(1f, attack.continuousDamage));
        }
    }
    IEnumerator ContinuousDamage(float delayTime, int continuousDamage)
    {
        int i = 3;
        while (i > 0)
        {
            yield return new WaitForSeconds(delayTime);
            TakeDamage(continuousDamage);
            i -= 1;
        }
    }
    void TakeDamage(int damage){
        hp -= damage;
    }
    void Update(){
        if (hp <= 0) {
            //gameFlowManager.gameOver();
        }
    }
    
}
