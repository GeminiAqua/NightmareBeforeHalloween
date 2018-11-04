using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int startingHealth = 250;
    public int extraHPMultiplier = 1;
    public int currentHealth;
    public int minHealth = 0;
    public bool isDead;
    public int currLevel;

    void Start()
    {
        currentHealth = startingHealth;
        Invoke("resetHealth", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        checkDead();
    }
    
    public int GetHealth()
    {
        return this.currentHealth;
    }
    
    public void AddHealth(int increaseValue)
    {
        if (!isHealthfull())
        {
            this.currentHealth += increaseValue;
        }
        //make sure not to go over
        if (currentHealth > startingHealth)
            resetHealth();
    }
    public void DecrementHealth(int decrementValue)
    {
        this.currentHealth -= decrementValue;
    }

    public bool isHealthfull()
    {
        if (currentHealth < startingHealth)
        {
            return false;
        }
        return true;
    }
    
    public void resetHealth()
    {
        GameObject levelText = GameObject.FindWithTag("LevelCounter");
        currLevel = levelText.GetComponent<LevelScript>().levelVar;
        if (gameObject.tag.Equals("Player")){
            this.currentHealth = startingHealth;
        } else {
            this.currentHealth = startingHealth + (currLevel * extraHPMultiplier);
        }
    }
    
    void checkDead(){
        if (currentHealth <= 0){
            isDead = true;
        }
    }

}
