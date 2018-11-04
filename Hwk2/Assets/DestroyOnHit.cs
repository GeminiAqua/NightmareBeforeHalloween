using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {

    public GameObject impactParticles;
    public GameObject impactSound;
    
    void Start(){
        // impactSound = Resources.Load("ImpactIce") as GameObject;
    }
    
	private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Monster")) {
           // GameObject newMob = Instantiate(impactSound) as GameObject;
           GameObject newMob = Instantiate(impactSound);
           newMob.transform.position = transform.position;
           Destroy(gameObject, 0.1f);
        } else if (collision.gameObject.tag.Equals("Ground")) {
           Destroy(gameObject);
        }
    }
}