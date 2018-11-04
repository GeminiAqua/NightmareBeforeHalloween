using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsUIManagerScript : MonoBehaviour {
    
    [System.Serializable]
    public class Player{
        public GameObject target;
        public TyController controller;
        public string currWeapon;
    }
    
    [System.Serializable]
    public class WeaponsHolder{
        public Image staffHolder;
        public Image swordHolder;
        public Image cleaverHolder;
    }
    
    [System.Serializable]
    public class Weapons{
        public Image staff;
        public Image sword;
        public Image cleaver;
    }
    
    public Text displayText;
    public Player player = new Player();
    public WeaponsHolder weaponsHolder = new WeaponsHolder();
    public Weapons weapons = new Weapons();
    private string[] weaponNames = new string[] {"Staff of the Snowflake", "Golem Slayer", "Witch Butcherer"};
	
    void Start(){
        player.target = GameObject.FindWithTag("Player");
        player.controller = player.target.GetComponent<TyController>();
    }
    
	// Update is called once per frame
	void Update () {
		matchWeaponString();
        updateWeapons();
	}
    
    void matchWeaponString(){
        player.currWeapon = player.controller.currentWeapon;
    }
    
    void updateWeapons(){
        if (player.currWeapon.Equals("staff")){
            activateWeapon(weaponsHolder.staffHolder, weapons.staff);
            inactivateWeapon(weaponsHolder.swordHolder, weapons.sword);
            inactivateWeapon(weaponsHolder.cleaverHolder, weapons.cleaver);
            displayText.text = weaponNames[0];
        } else if (player.currWeapon.Equals("sword")){
            inactivateWeapon(weaponsHolder.staffHolder, weapons.staff);
            activateWeapon(weaponsHolder.swordHolder, weapons.sword);
            inactivateWeapon(weaponsHolder.cleaverHolder, weapons.cleaver);
            displayText.text = weaponNames[1];
        } else if (player.currWeapon.Equals("cleaver")){
            inactivateWeapon(weaponsHolder.staffHolder, weapons.staff);
            inactivateWeapon(weaponsHolder.swordHolder, weapons.sword);
            activateWeapon(weaponsHolder.cleaverHolder, weapons.cleaver);
            displayText.text = weaponNames[2];
        } 
    }
    
    void inactivateWeapon(Image weaponPanel, Image weaponVar){
        weaponPanel.color = new Color(1, 1, 1, 0.39f);
        weaponVar.color = new Color(0.19f, 0.19f, 0.19f, 0.19f);
    }
    
    void activateWeapon(Image weaponPanel, Image weaponVar){
        weaponPanel.color = new Color(0.098f, 0.76f, 0f, 1);
        weaponVar.color = new Color(1, 1, 1, 1);
    }
}
