using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UITweenFade : MonoBehaviour
{
    RectTransform rt;
    //CanvasGroup canvasGroup;
    TextMeshProUGUI text;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        //canvasGroup = gameObject.GetComponent<CanvasGroup>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
        image = gameObject.GetComponent<Image>();
        //canvasGroup.alpha = 0f;
        //LeanTween.alphaCanvas(canvasGroup, 1.0f, 0.7f).setFrom(0f).setEase(LeanTweenType.easeSpring);
        rt = GetComponent<RectTransform>();
        LeanTween.value(gameObject, 0f, 1.0f, 0.7f).setOnUpdate((float value) =>
        {
            Color c = text.color;
            c.a = value;
            text.color = c;
            //image.color = c;
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
            Color c = text.color;
            c.a = value;
            text.color = c;
            //image.color = c;
        }).setEase(LeanTweenType.easeOutSine);
    }
}
