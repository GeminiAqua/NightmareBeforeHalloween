using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indestructable : MonoBehaviour {

	public static Indestructable instance = null;

    public int prevSceneIndex = 0;
    public int savedLevel = 1;

    void Awake() {
        // Set instance if doesn't exist
        if( !instance )
            instance = this;
        else { // prevent duplicate
            Destroy(this.gameObject) ;
            return;
        }
        DontDestroyOnLoad(this.gameObject) ;
    }
    
    public int getPrevSceneIndex(){
        return prevSceneIndex;
    }
    
    public int getSavedLevel(){
        return savedLevel;
    }
}
