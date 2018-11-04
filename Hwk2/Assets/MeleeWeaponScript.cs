using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponScript : MonoBehaviour {

	public int attackPower = 10;
    public int golemMultiplier = 9;
    public int witchMultiplier = 2;
    public int mouseMultiplier = 5;
    public TyController player;
    public AudioSource aSource;
    public AudioClip slashHitFlesh;
    public AudioClip slashHitSolid;
    
    void Start(){
        aSource = gameObject.GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider other){
        if (other.tag.Equals("Monster") && (player.attackInput > 0)){
            if (other.gameObject.GetComponent<AIGolem>()){
                // aSource.PlayClipAtPoint(slashHitSolid, transform.position);
                aSource.PlayOneShot(slashHitSolid, 1f);
                AIGolem golem = other.gameObject.GetComponent<AIGolem>();
                if (golem.isAbleToBeDamaged){
                    golem.doMeleeDamage(attackPower * golemMultiplier);
                }
            } else if (other.gameObject.GetComponent<AIWitch>()){
                // aSource.PlayClipAtPoint(slashHitFlesh, transform.position);
                aSource.PlayOneShot(slashHitFlesh, 1f);
                AIWitch witch = other.gameObject.GetComponent<AIWitch>();
                if (witch.isAbleToBeDamaged){
                    witch.doMeleeDamage(attackPower * witchMultiplier);
                }
            } else if (other.gameObject.GetComponent<AIMouseSpear>()){
                // aSource.PlayClipAtPoint(slashHitFlesh, transform.position);
                aSource.PlayOneShot(slashHitFlesh, 1f);
                AIMouseSpear mouse = other.gameObject.GetComponent<AIMouseSpear>();
                if (mouse.isAbleToBeDamaged){
                    mouse.doMeleeDamage(attackPower * mouseMultiplier);
                }
            }
        }
    }
}