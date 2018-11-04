using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSpawner : MonoBehaviour {

    public GameObject powerUpHeal;
    public GameObject powerUpInvincible;
    public GameObject powerUpSpeed;
    public float spawnCooldown = 30f;
    public float spawnDelay = 1f;
    public float totalSpawnTime;
    
	void Start () {
            powerUpHeal = Resources.Load("PowerUpHeal") as GameObject;
            powerUpInvincible = Resources.Load("PowerUpInvincible") as GameObject;
            powerUpSpeed = Resources.Load("PowerUpSpeed") as GameObject;
            InvokeRepeating("producePowerUp", spawnDelay, spawnCooldown);
	}
    
    void producePowerUp(){
        int i = Random.Range(0, 3);
        if ( i == 0){
            instantiatePowerUp(powerUpSpeed);
        } else if ( i == 1 ){
            instantiatePowerUp(powerUpInvincible);
        } else {
            instantiatePowerUp(powerUpHeal);
        }
    }
    
    void instantiatePowerUp(GameObject item){
        GameObject newMob = Instantiate(item, transform.position + new Vector3(0, 10f, 0), transform.rotation);
    }
}
