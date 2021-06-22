using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light lightComponent;
    private float fadeOut = 0.0f;
    private float birthTime = 0.3f;
    private float transitionTime = 0.5f;
    private bool lerping = true;
    private float livingTime = 4.0f;
    public float maxIntensity;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
        lightComponent.intensity = 0.0f;
        LeanTween.value(0.0f, maxIntensity, birthTime).setOnUpdate((float value) =>
        {
            float inter = lightComponent.intensity;
            inter = value;
            lightComponent.intensity = inter;
        }).setEase(LeanTweenType.easeInQuad);
        Invoke("TweenFadeOut", 4);
        //Invoke("TimedDestroy", 4.5f);
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //livingTime -= Time.deltaTime;
        //if(livingTime >= birthTime)
        //    lightComponent.intensity = Mathf.Lerp(lightComponent.intensity, maxIntensity, Time.deltaTime / birthTime);
        //if (livingTime <= 0)
        //{
        //    lightComponent.intensity = Mathf.Lerp(lightComponent.intensity, fadeOut, Time.deltaTime / transitionTime);
        //}
        //if (livingTime <= -2)
        //    Destroy(gameObject);
        //if(lerping)
        //{
        //    transitionTime -= Time.deltaTime;
        //    lightComponent.intensity = Mathf.Lerp(lightComponent.intensity, fadeOut, transitionTime);
        //    if (transitionTime <= 0)
        //    {
        //        lerping = false;
        //    }
        //}
        //lightComponent.intensity = Mathf.Lerp(lightComponent.intensity, fadeOut, transitionTime);
    }

    void TweenFadeOut()
    {
        LeanTween.value(maxIntensity, fadeOut, transitionTime).setOnUpdate((float value) =>
        {
            float inter = lightComponent.intensity;
            inter = value;
            lightComponent.intensity = inter;
        }).setEase(LeanTweenType.easeInQuad).setOnComplete(() => Destroy(gameObject));
    }

    //void LightControl()
    //{
    //    lightComponent = GetComponent<Light>();
    //    lightComponent.intensity = 0.0f;
    //    LeanTween.value(0.0f, maxIntensity, birthTime).setOnUpdate((float value) =>
    //    {
    //        float inter = lightComponent.intensity;
    //        inter = value;
    //        lightComponent.intensity = inter;
    //    }).setEase(LeanTweenType.easeInQuad);
    //    Invoke("TweenFadeOut", 4);
    //}
}
