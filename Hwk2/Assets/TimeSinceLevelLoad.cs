using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeSinceLevelLoad : MonoBehaviour {

    public Text timeText;
    // public float levelDuration = 999999999f;
    float time;
    
    void Start () {
        timeText = gameObject.GetComponent<Text>();
	}
    
	void Update () {
        time = (float) Time.timeSinceLevelLoad;
        // if (time >= levelDuration){
            // Invoke("EndOfLevel", 3);
        // }
        // if (Time.timeSinceLevelLoad < 30f){
            timeText.text = "TIME: " + time.ToString("0.0");
        // } else {
            // Time.timeScale = 1f;
            // timeText.text = "FINISH!";
        // }
	}
    
    void EndOfLevel(){
        {
            Indestructable.instance.prevSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(3);
        }
    }
}
