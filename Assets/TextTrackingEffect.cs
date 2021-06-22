using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MEC;

public class TextTrackingEffect : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private string textToDisplay;
    public string hexTrackColour;
    public Color32 destinatedColour;
    public float trackingTime;
    public float letterAppearTime;
    public int trackingStep;
    private bool first = true;
    // Start is called before the first frame update
    //void Start()
    //{
    //    textMesh = gameObject.GetComponent<TextMeshProUGUI>();
    //    textToDisplay = textMesh.text;
    //    textMesh.text = null;
    //    Timing.RunCoroutine(TrackLettersIn());
    //}

    void OnEnable()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        if(first)
        {
            textToDisplay = textMesh.text;
            first = false;
        }
        textMesh.text = null;
        Timing.RunCoroutine(TrackLettersIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator<float> TrackLettersIn()
    {
        int letterCounter = 0;
        foreach(var letter in textToDisplay)
        { //FFD600
            //FFFFFF
            //new Color32(148, 255, 148, 255);
            letterCounter++;
            string insert = $"<color=#{hexTrackColour}>{letter}</color>";
            textMesh.text = textMesh.text + insert;
            //textMesh.color = new Color32(255, 214, 0, 255);
            if (letterCounter >= trackingStep)
            {
                yield return Timing.WaitForSeconds(trackingTime);
                textMesh.text = textMesh.text.Replace($"<color=#{hexTrackColour}>", "");
                textMesh.text = textMesh.text.Replace("</color>", "");
                textMesh.color = destinatedColour;
                letterCounter = 0;
            }
            //if (letter == textToDisplay.Length)
            //{
            //    yield return Timing.WaitForSeconds(trackingTime);
            //    textMesh.text = textMesh.text.Replace("<color=#FFD600>", "");
            //    textMesh.text = textMesh.text.Replace("</color>", "");
            //    textMesh.color = destinatedColour;
            //}
            yield return Timing.WaitForSeconds(letterAppearTime);
        }
        textMesh.text = textMesh.text.Replace($"<color=#{hexTrackColour}>", "");
        textMesh.text = textMesh.text.Replace("</color>", "");
        textMesh.color = destinatedColour;
    }
    
    public void StopTracking()
    {
        Timing.KillCoroutines();
    }
}
