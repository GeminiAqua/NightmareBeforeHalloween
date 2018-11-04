using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    public GameObject target;
    public TyController player;
    public GameObject particlesPrefab;
    
    public float powerUpDuration = 10f;
    public float speedMultiplier = 2f;
    
	void Start () {
		target = GameObject.FindWithTag("Player");
        player = target.GetComponent<TyController>();
        particlesPrefab = Resources.Load("ChristmasParticles") as GameObject;
	}
    
    void Update(){
        if (transform.position.y > 2f){
            transform.position -= new Vector3(0f, 4f * Time.deltaTime, 0);
        }
    }
	
	void OnTriggerEnter(Collider other){
        if (other.tag.Equals("Player")){
            if (gameObject.tag.Equals("PowerUpHeal")){
                powerUpHeal();
            } else if (gameObject.tag.Equals("PowerUpInvincible")){
                powerUpInvincible();
            } else if (gameObject.tag.Equals("PowerUpSpeed")){
                powerUpSpeed();
            }
            GameObject particles = Instantiate(particlesPrefab) as GameObject;
            particles.transform.position = transform.position;
            selfDestruct();
        }
    }
    
    void powerUpHeal(){
        target.GetComponent<Health>().resetHealth();
    }
    
    void powerUpInvincible(){
        player.powerUpInvincible(powerUpDuration);
    }
    
    void powerUpSpeed(){
        player.powerUpSpeed(powerUpDuration, speedMultiplier);
    }
    
    void selfDestruct(){
        Destroy(gameObject, 0.1f);
    }
    
}
