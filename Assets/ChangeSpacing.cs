using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeSpacing : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        LeanTween.value(0f, 16f, 0.7f).setOnUpdate((float value) =>
        {
            float inter = textMesh.characterSpacing;
            inter = value;
            textMesh.characterSpacing = inter;
        }).setEase(LeanTweenType.easeSpring);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBackwards()
    {
        LeanTween.value(16f, 0f, 0.7f).setOnUpdate((float value) =>
        {
            float inter = textMesh.characterSpacing;
            inter = value;
            textMesh.characterSpacing = inter;
        }).setEase(LeanTweenType.easeSpring);
    }
}
