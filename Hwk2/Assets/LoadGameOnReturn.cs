using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameOnReturn : MonoBehaviour {

    public int sceneIndex;
    
	// This is DEPENDENT ON SCENE INDEX; I SET MY GAME SCENE TO 1
    void Update(){
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)){
            Indestructable.instance.prevSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(1);
        }
    }
}
