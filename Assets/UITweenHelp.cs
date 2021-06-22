using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UITweenHelp : MonoBehaviour
{
    public GameObject mainPanel;
    public float initialValuePanel;
    public float finalValuePanel;
    public GameObject pushables;
    public float initialValuePushables;
    public float finalValuePushables;
    public GameObject helpPanel;
    public float initialValueHelpPanel;
    public float finalValueHelpPanel;
    public GameObject helpText;
    public float initialValueText;
    public float finalValueText;
    public GameObject pushables2;
    public float initialValuePushables2;
    public float finalValuePushables2;
    RectTransform mainPanelImage;
    RectTransform pushablesRect;
    RectTransform helpPanelRect;
    RectTransform pushables2Rect;
    TextMeshProUGUI helpTextMesh;
    private bool clicked = false;
    private bool noPanel = false;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            mainPanelImage = mainPanel.GetComponent<RectTransform>();
        }
        catch
        {
            noPanel = true;
        }
        pushablesRect = pushables.GetComponent<RectTransform>();
        pushables2Rect = pushables2.GetComponent<RectTransform>();
        helpPanelRect = helpPanel.GetComponent<RectTransform>();
        helpTextMesh = helpText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HelpHandler()
    {
        if (!clicked)
        {
            MoveElements();
            Invoke("Clicked", 0.6f);
        }
        if (clicked)
        {
            RevertElements();
            Invoke("NotClicked", 0.6f);
        }
    }

    public void MoveElements()
    {
        helpTextMesh.color = new Color(helpTextMesh.color.r, helpTextMesh.color.g, helpTextMesh.color.b, 0f);
        helpText.SetActive(true);
        if(!noPanel)
        {
            LeanTween.value(initialValuePanel, finalValuePanel, 0.5f).setOnUpdate((float value) =>
            {
                float inter = mainPanelImage.offsetMin.x;
                inter = value;
                mainPanelImage.offsetMin = new Vector2(mainPanelImage.offsetMin.x, inter);
            }).setEase(LeanTweenType.easeSpring);
        }
        LeanTween.value(initialValuePushables, finalValuePushables, 0.5f).setOnUpdate((float value) =>
        {
            float inter = pushablesRect.localPosition.y;
            inter = value;
            pushablesRect.localPosition = new Vector3(pushablesRect.localPosition.x, inter, pushablesRect.localPosition.z);
        }).setEase(LeanTweenType.easeSpring);
        LeanTween.value(initialValuePushables2, finalValuePushables2, 0.5f).setOnUpdate((float value) =>
        {
            float inter = pushables2Rect.localPosition.y;
            inter = value;
            pushables2Rect.localPosition = new Vector3(pushables2Rect.localPosition.x, inter, pushables2Rect.localPosition.z);
        }).setEase(LeanTweenType.easeSpring);
        LeanTween.value(initialValueHelpPanel, finalValueHelpPanel, 0.5f).setOnUpdate((float value) =>
        {
            float inter = helpPanelRect.offsetMin.x;
            inter = value;
            helpPanelRect.offsetMin = new Vector2(helpPanelRect.offsetMin.x, inter);
        }).setEase(LeanTweenType.easeSpring);
        LeanTween.value(initialValueText, finalValueText, 0.5f).setOnUpdate((float value) =>
        {
            Color c = helpTextMesh.color;
            c.a = value;
            helpTextMesh.color = c;
        }).setEase(LeanTweenType.easeSpring);
        //mainPanelImage.offsetMin = new Vector2(mainPanelImage.offsetMin.x, 100f);
    }

    public void RevertElements()
    {
        if(!noPanel)
        {
            LeanTween.value(finalValuePanel, initialValuePanel, 0.5f).setOnUpdate((float value) =>
            {
                float inter = mainPanelImage.offsetMin.x;
                inter = value;
                mainPanelImage.offsetMin = new Vector2(mainPanelImage.offsetMin.x, inter);
            }).setEase(LeanTweenType.easeSpring);
        }
        LeanTween.value(finalValuePushables, initialValuePushables, 0.5f).setOnUpdate((float value) =>
        {
            float inter = pushablesRect.localPosition.y;
            inter = value;
            pushablesRect.localPosition = new Vector3(pushablesRect.localPosition.x, inter, pushablesRect.localPosition.z);
        }).setEase(LeanTweenType.easeSpring);
        LeanTween.value(finalValuePushables2, initialValuePushables2, 0.5f).setOnUpdate((float value) =>
        {
            float inter = pushables2Rect.localPosition.y;
            inter = value;
            pushables2Rect.localPosition = new Vector3(pushables2Rect.localPosition.x, inter, pushables2Rect.localPosition.z);
        }).setEase(LeanTweenType.easeSpring);
        LeanTween.value(finalValueHelpPanel, initialValueHelpPanel, 0.5f).setOnUpdate((float value) =>
        {
            float inter = helpPanelRect.offsetMin.x;
            inter = value;
            helpPanelRect.offsetMin = new Vector2(helpPanelRect.offsetMin.x, inter);
        }).setEase(LeanTweenType.easeSpring);
        LeanTween.value(finalValueText, initialValueText, 0.3f).setOnUpdate((float value) =>
        {
            Color c = helpTextMesh.color;
            c.a = value;
            helpTextMesh.color = c;
        }).setEase(LeanTweenType.easeSpring);
    }

    void Clicked()
    {
        clicked = true;
    }

    void NotClicked()
    {
        helpText.SetActive(false);
        clicked = false;
    }
}
