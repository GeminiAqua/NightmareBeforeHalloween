using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour {
    [SerializeField] private Image imageToUse;
    [SerializeField] private bool useThisImage = false;
    [SerializeField] private bool useFadeCycle = true;
    [SerializeField] private float timeMultiplier;
    [SerializeField] private float startDelay = 0;
    private void Start()
    {
        if (useThisImage)
        {
            imageToUse = GetComponent<Image>();
        }
        if (useFadeCycle){
            Invoke("startFadeCycle", startDelay);
        }
    }
    
    private void startFadeCycle(){
        StartCoroutine(FadeOutText(timeMultiplier, imageToUse));
    }
    
    private IEnumerator FadeInText(float timeSpeed, Image text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * timeSpeed));
            yield return null;
        }
        StartCoroutine(FadeOutText(timeMultiplier, imageToUse));
    }
    
    private IEnumerator FadeOutText(float timeSpeed, Image text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * timeSpeed));
            yield return null;
        }
        StartCoroutine(FadeInText(timeMultiplier, imageToUse));
    }
    
    public void FadeInText(float timeSpeed = -1.0f)
    {
        if (timeSpeed <= 0.0f)
        {
            timeSpeed = timeMultiplier;
        }
        StartCoroutine(FadeInText(timeSpeed, imageToUse));
    }
    
    public void FadeOutText(float timeSpeed = -1.0f)
    {
        if (timeSpeed <= 0.0f)
        {
            timeSpeed = timeMultiplier;
        }
        StartCoroutine(FadeOutText(timeSpeed, imageToUse));
    }
}