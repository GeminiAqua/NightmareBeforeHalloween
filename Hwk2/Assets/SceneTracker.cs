using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour {

	public int sceneIndex;
    
    public void LoadScene(int sceneNumber) {
        Indestructable.instance.prevSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneNumber);
    }
    
    void Update(){
        if ( (SceneManager.GetActiveScene().name == "GameScene") && (Time.timeScale > 1)){
            Cursor.visible = false;
        } else {
            Cursor.visible = true;
        }
    }
}
