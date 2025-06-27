using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement ;

public class Combat : MonoBehaviour
{   
    public float maxHealth = 100 ;
    public float currentHealth ;
    Animator animator ;
    public bool isDead ;
    public Manager manager ;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth ;
        animator = gameObject.GetComponent<Animator>();

    }

    public void TakeDamage(int attackPower){
        FindAnyObjectByType<Audio>().play("Damage");
        currentHealth -= attackPower ;
        if (currentHealth < 0 )currentHealth = 0 ;
        animator.SetTrigger("Hit");
        if(currentHealth<=0){
            Die();
            manager.GameOver();
        }
    }
    void Die(){
        isDead = true ;
        animator.SetBool("isDead",isDead);
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static ;
        
    }
    public void displayHealth(Text text){
        text.text = Convert.ToString(currentHealth) ;
    }
}
