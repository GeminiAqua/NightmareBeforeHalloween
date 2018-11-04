using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagementScript : MonoBehaviour {

    public GameObject staff;
    public GameObject sword;
    public GameObject cleaver;
    string currWeapon;
    public float weaponSwitchDelay = 0.25f;
    public bool canSwitch;
    public GameObject weaponSwitchParticles;
    public TyController player;
    public AudioSource switchSound;

    void Start(){
        canSwitch = true;
        switchSound = gameObject.GetComponent<AudioSource>();
    }
    
	void Update () {
		checkCurrentWeapon();
        switchWeapon();
	}
    
    void checkCurrentWeapon(){
        if (staff.activeSelf){
            currWeapon = "staff";
        } else if (sword.activeSelf){
            currWeapon = "sword";
        } else if (cleaver.activeSelf){
            currWeapon = "cleaver";
        }
        player.updateWeapon(currWeapon);
    }
    
    void switchWeapon(){
        if (Input.GetKeyDown(KeyCode.Tab) && canSwitch){
            switchSound.Play();
            canSwitch = false;
            Invoke("setSwitchTrue", weaponSwitchDelay);
            if (staff.activeSelf){
                staff.SetActive(false);
                instantiateParticles();
                sword.SetActive(true);
            } else if (sword.activeSelf){
                sword.SetActive(false);
                instantiateParticles();
                cleaver.SetActive(true);
            } else if (cleaver.activeSelf){
                cleaver.SetActive(false);
                instantiateParticles();
                staff.SetActive(true);
            }
        }
    }
    
    void setSwitchTrue(){
        canSwitch = true;
    }
    
    void instantiateParticles(){
        GameObject particles = Instantiate(weaponSwitchParticles) as GameObject;
            particles.transform.position = transform.position;
    }
}
