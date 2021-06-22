using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowSliderValue : MonoBehaviour
{
    private TextMeshProUGUI textValue;
    // Start is called before the first frame update
    void Start()
    {
        textValue = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowValue(float sliderValue)
    {
        textValue.text = sliderValue.ToString();
    }
}
