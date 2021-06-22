using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UITweenMove : MonoBehaviour
{
    //public Vector3 startPosition;
    public Vector3 endPosition;
    RectTransform rt;
    Vector3 offScreenLeftPosition;
    Vector3 offScreenRightPosition;
    Vector3 offScreenUpPosition;
    Vector3 offScreenDownPosition;
    Vector3 centerPosition;
    //public UnityEvent callback;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        endPosition = rt.localPosition;
        centerPosition = new Vector3(0, 0, 0);
        offScreenLeftPosition = new Vector3(-Screen.width, endPosition.y, 0);
        offScreenRightPosition = new Vector3(Screen.width, endPosition.y, 0);
        offScreenUpPosition = new Vector3(endPosition.x, Screen.height, 0);
        offScreenDownPosition = new Vector3(endPosition.x, -Screen.height, 0);
        rt.localPosition = offScreenLeftPosition;

        //transform.localPosition = startPosition;
        //LeanTween.move(rt, centerPosition, 0.7f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.move(rt, endPosition, 0.7f).setEase(LeanTweenType.easeInOutCubic);
    }

    public void hide()
    {
        LeanTween.cancel(gameObject);
        //rt.localPosition = centerPosition;
        rt.localPosition = endPosition;
        LeanTween.move(rt, offScreenLeftPosition, 0.7f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(() => { gameObject.SetActive(false); });
    }

    private void OnDisable()
    {
        Debug.Log("TweezeOut");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
