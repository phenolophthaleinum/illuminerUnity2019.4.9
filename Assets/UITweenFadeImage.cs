using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UITweenFadeImage : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        //canvasGroup = gameObject.GetComponent<CanvasGroup>();
        image = gameObject.GetComponent<Image>();
        //canvasGroup.alpha = 0f;
        //LeanTween.alphaCanvas(canvasGroup, 1.0f, 0.7f).setFrom(0f).setEase(LeanTweenType.easeSpring);
        LeanTween.value(gameObject, 0f, 1.0f, 0.7f).setOnUpdate((float value) =>
        {
            Color c = image.color;
            c.a = value;
            image.color = c;
        }).setEase(LeanTweenType.easeSpring);
        //LeanTween.alphaVertex(gameObject, 1.0f, 0.7f).setFrom(0f).setEase(LeanTweenType.easeSpring);
        //LeanTween.alphaText(rt, 1.0f, 0.7f).setFrom(0f).setEase(LeanTweenType.easeSpring);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeOut()
    {
        LeanTween.value(gameObject, 1.0f, 0.0f, 0.7f).setOnUpdate((float value) =>
        {
            Color c = image.color;
            c.a = value;
            image.color = c;
        }).setEase(LeanTweenType.easeOutSine);
    }
}
