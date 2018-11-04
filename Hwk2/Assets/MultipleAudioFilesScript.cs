using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAudioFilesScript : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip startingClip;
    public AudioClip clip2;

    
	void Start () {
		audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot (startingClip);
	}
	
    void playClip2(){
        audioSource.PlayOneShot(clip2);
    }
}
