using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Input;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int hp = 100;
    public GameFlowManager gameFlowManager;
    public Image healthBar;
    void Start()
    {
        //gameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
    }

    void OnTriggerEnter(Collider collision){
        if (collision.transform.tag == "attack"){
            Attack attack = collision.transform.GetComponent<Attack>();
            if (attack == null)
            {
                return;
            }
            TakeDamage(attack.damage);
            StartCoroutine(ContinuousDamage(1f, attack.continuousDamage));
        }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.transform.tag == "attack"){
            Attack attack = collision.transform.GetComponent<Attack>();
            if (attack == null)
            {
                return;
            }
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
        UpdateHealth(hp);
    }
    void UpdateHealth(int health){
        healthBar.fillAmount = (float) health / (float)100;
    }
    void Update(){
        if (hp <= 0) {
            //gameFlowManager.gameOver();
        }
    }
    
}
