using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EmptyHPBarScript : MonoBehaviour {

    public float HP;
	// Use this for initialization
	void Start () {
		HP = gameObject.GetComponent<Image>().fillAmount;
	}
	
	// Update is called once per frame
	void Update () {
        HP = gameObject.GetComponent<Image>().fillAmount;
		if (HP <= 0f){
            Invoke("EndOfLevel", 2);
        }
	}
    
    void EndOfLevel(){
        Indestructable.instance.prevSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(2);
    }
}
