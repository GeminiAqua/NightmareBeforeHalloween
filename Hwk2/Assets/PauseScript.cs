using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    public float currentTimeScale = 1;
    public bool isPaused;
    public AudioSource audioSource;
    public CanvasGroup window;
    public Canvas UIWindow; // assign regular UI
    public CanvasGroup UICanvasGroup;
	
    void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
        window = GetComponent<CanvasGroup>();
        window.alpha=0;
        window.interactable = false;
        UICanvasGroup = UIWindow.GetComponent<CanvasGroup>();
    }

	void Update () {
        checkPause();
	}
    
    void checkPause(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!isPaused){
                pause();
                audioSource.Play();
            } else{
                unpause();
                audioSource.Play();
            }
        }
    }
    
    public void pause(){
        window.alpha=1;
        window.interactable = true;
        isPaused = true;
        
        UICanvasGroup.alpha = 0.1f;
        
        currentTimeScale = Time.timeScale; // save currentTime Scale
        Time.timeScale = 0f;
    }
    
    public void unpause(){
        window.alpha=0;
        window.interactable = false;
        isPaused = false;
        
        UICanvasGroup.alpha = 1;
        
        Cursor.visible = false;

        Time.timeScale = currentTimeScale;
    }
    
}
