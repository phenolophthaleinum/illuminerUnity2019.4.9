using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
//using UnityEngine.Rendering.PostProcessing;

public class PostProcessController : MonoBehaviour
{
    private Volume postProcess;
    private Bloom bloom;
    private DepthOfField depthOfField;
    // Start is called before the first frame update
    void Start()
    {
        postProcess = GetComponent<Volume>();
        postProcess.profile.TryGet(out bloom);
        postProcess.profile.TryGet(out depthOfField);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableBloom()
    {
        bloom.active = true;
        bloom.intensity.value = 0.0f;
        LeanTween.value(0f, 10.37f, 0.7f).setOnUpdate((float value) =>
        {
            float inter = bloom.intensity.value;
            inter = value;
            bloom.intensity.value = inter;
        }).setEase(LeanTweenType.easeSpring);
    }

    public void disableBloom()
    {
        LeanTween.value(10.37f, 0.0f, 0.7f).setOnUpdate((float value) =>
        {
            float inter = bloom.intensity.value;
            inter = value;
            bloom.intensity.value = inter;
        }).setEase(LeanTweenType.easeSpring).setOnComplete(() => bloom.active = false);
        //bloom.active = false;
    }

    public void enableDepth()
    {
        depthOfField.active = true;
        //depthOfField.focusDistance.value = 15.0f;
        LeanTween.value(1f, 165f, 0.7f).setOnUpdate((float value) =>
        {
            float inter = depthOfField.focalLength.value;
            inter = value;
            depthOfField.focalLength.value = inter;
        }).setEase(LeanTweenType.easeSpring);
    }
    public void disableDepth()
    {
        LeanTween.value(165f, 1f, 0.7f).setOnUpdate((float value) =>
        {
            float inter = depthOfField.focalLength.value;
            inter = value;
            depthOfField.focalLength.value = inter;
        }).setEase(LeanTweenType.easeSpring).setOnComplete(() => depthOfField.active = false);
        //depthOfField.active = false;
    }

}
