using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Runtime.InteropServices;
//using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public InputField inputField;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI correctBases;
    public TextMeshProUGUI percentage;
    public Slider lengthSlider;
    public Button nextButton;
    public Button startButton;
    private PostProcessController postProcess;
    private int score;
    private float percentScore;
    public int sequenceLength;
    public bool inGame;
    private SpawnLights spawnLights;
    public GameObject inGameUI;
    public GameObject menuUI;
    public GameObject resultUI;
    public GameObject instructionsUI;
    public GameObject creditsUI;
    public string sequencedSeq;
    public InputField playerName;
    public string playerNameString;
    private string playerScore;
    //private GetData getDataPlugin;
    //public string currentLanguage;
    //public PostProcessVolume postProcess;
    //private Bloom bloom;
    // Start is called before the first frame update
    void Start()
    {
        RetrieveLength();
        spawnLights = GameObject.Find("SpawnManager").GetComponent<SpawnLights>();
        postProcess = GameObject.Find("Global Volume").GetComponent<PostProcessController>();
        //postProcess = gameObject.GetComponent<PostProcessVolume>();
        //postProcess.profile.TryGetSettings(out bloom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOver()
    {
        calculateScore(spawnLights.sequence);
        resultUI.gameObject.SetActive(true);
        inputField.interactable = false;
        //gameOverText.gameObject.SetActive(true);
        //correctBases.gameObject.SetActive(true);
        //percentage.gameObject.SetActive(true);
        //nextButton.gameObject.SetActive(true);
        postProcess.enableBloom();
        postProcess.enableDepth();
        sequencedSeq = spawnLights.sequence;
        playerNameString = playerName.text.ToString();
        playerScore = $"{score.ToString()}/{sequenceLength.ToString()}";
        //try
        //{
        GetData.GetGameData(playerNameString, playerScore);
        //}
        //catch
        //{
        //    Debug.LogWarning("Not connected functions: GetGameData(string, string) from Unity to JavaScript equivalent.");
        //}
        //bloom.enabled.value = true;
    }

    public void SetToUpper()
    {
        //var text = inputField.text.ToString().ToUpper();
        inputField.text = inputField.text.ToString().ToUpper();
        //Debug.Log(text);
    }


    private void calculateScore(string sequence)
    {
        var userSequence = inputField.text.ToString();
        var seqLen = sequence.Length;

        if(userSequence.Length > seqLen)
        {
            userSequence = userSequence.Substring(0, seqLen);
        }
        if(userSequence.Length < seqLen)
        {
            sequence = sequence.Substring(0, userSequence.Length);
        }

        for(int i = 0; i<sequence.Length; i++)
        {
            if(sequence[i] == userSequence[i])
            {
                score++;
            }
            else
            {
                continue;
            }
        }
        percentScore = (float)score / (float)seqLen * 100.0f;
        Debug.Log(score + "/" + seqLen);
        Debug.Log(percentScore);
        correctBases.text = correctBases.text + " " + score;
        percentage.text = percentage.text + " " + Mathf.Round(percentScore * 100f)/100 + "%";
    }

    public void RestartGame()
    {
        postProcess.disableBloom();
        postProcess.disableDepth();
        Invoke("ReloadScene", 1.0f);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RetrieveLength()
    {
        sequenceLength = (int)lengthSlider.value;
    }

    public void startClick()
    {
        inGame = true;
        //menuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        spawnLights.Invoke("StartGame", 1);
    }

    public void ShowInstructions()
    {
        postProcess.enableBloom();
        postProcess.enableDepth();
        menuUI.GetComponentInChildren<Button>().interactable = false;
        menuUI.GetComponentInChildren<Slider>().interactable = false;
        menuUI.GetComponentInChildren<InputField>().interactable = false;
        GameObject.Find("StartGame").GetComponent<Button>().interactable = false;
        GameObject.Find("InfoName").GetComponent<Button>().interactable = false;
        GameObject.Find("CreditsButton").GetComponent<Button>().interactable = false;
        instructionsUI.SetActive(true);
    }

    public void HideInstructions()
    {
        postProcess.disableBloom();
        postProcess.disableDepth();
        menuUI.GetComponentInChildren<Button>().interactable = true;
        menuUI.GetComponentInChildren<Slider>().interactable = true;
        menuUI.GetComponentInChildren<InputField>().interactable = true;
        GameObject.Find("StartGame").GetComponent<Button>().interactable = true;
        GameObject.Find("InfoName").GetComponent<Button>().interactable = true;
        GameObject.Find("CreditsButton").GetComponent<Button>().interactable = true;
        instructionsUI.SetActive(false);
    }

    public void ShowCredits()
    {
        postProcess.enableBloom();
        postProcess.enableDepth();
        menuUI.GetComponentInChildren<Button>().interactable = false;
        menuUI.GetComponentInChildren<Slider>().interactable = false;
        menuUI.GetComponentInChildren<InputField>().interactable = false;
        GameObject.Find("StartGame").GetComponent<Button>().interactable = false;
        GameObject.Find("InfoName").GetComponent<Button>().interactable = false;
        GameObject.Find("CreditsButton").GetComponent<Button>().interactable = false;
        creditsUI.SetActive(true);
    }

    public void HideCredits()
    {
        postProcess.disableBloom();
        postProcess.disableDepth();
        menuUI.GetComponentInChildren<Button>().interactable = true;
        menuUI.GetComponentInChildren<Slider>().interactable = true;
        menuUI.GetComponentInChildren<InputField>().interactable = true;
        GameObject.Find("StartGame").GetComponent<Button>().interactable = true;
        GameObject.Find("InfoName").GetComponent<Button>().interactable = true;
        GameObject.Find("CreditsButton").GetComponent<Button>().interactable = true;
        creditsUI.SetActive(false);
    }

    //[DllImport("__Internal")]
    //private static extern void GetGameData(string player, string score);
}
