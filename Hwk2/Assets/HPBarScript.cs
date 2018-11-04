using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour {

	[SerializeField] float fillRatio;
    
    [SerializeField] Image content;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        updateBar();
	}
    
    private void updateBar(){
        content.fillAmount = fillRatio;
    }
}
