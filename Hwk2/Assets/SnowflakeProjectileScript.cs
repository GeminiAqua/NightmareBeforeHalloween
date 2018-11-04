using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeProjectileScript : MonoBehaviour {

    public GameObject prefab;
    public TyController player;
    public float castDelay = 0.2f;
    
	// Use this for initialization
	void Start () {
        prefab = Resources.Load("SnowflakeProjectile") as GameObject;
	}
    
    public void snowflakeAttack(){
        Invoke("delayedSnowflakeAttack", castDelay);
    }
    
    void delayedSnowflakeAttack(){
        GameObject missile = Instantiate(prefab) as GameObject;
        missile.transform.position = player.transform.position + new Vector3(0, 1, 0) + (player.transform.forward * 0.5f);
        Rigidbody rBody = missile.GetComponent<Rigidbody>();
        rBody.velocity = player.transform.forward * 40;
    }
}
