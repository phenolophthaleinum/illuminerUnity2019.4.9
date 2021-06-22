using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using System.Timers;
using MEC;

public class SpawnLights : MonoBehaviour
{
    public GameObject lightPrefab;
    public GameObject plate;
    private Light lightComponent;
    private float spawnRange = 3.7f;
    public string sequence;
    private float difficultyFactor = 0.96f;
    private int letterCounter = 0;
    private double intervalTime = 2.0f;
    private float maxInterval = 1.5f;
    private float minInterval = 0.5f;
    private string testseq;
    private GameManager gameManager;
    private static System.Random random = new System.Random();
    //private Timer timer = new Timer();
    private IEnumerator coroutine;
    //private char currentLetter;
    private int letterIndex = -1;
    private Dictionary<char, Color> coloursDict = new Dictionary<char, Color>(){ {'A', new Color(0, 0, 255, 255) },
                                                                                    {'T', new Color(255, 255, 0, 255) },
                                                                                    {'C', new Color(255, 0, 0, 255) },
                                                                                    {'G', new Color(0, 255, 0, 255) }};
    private List<GameObject> lightsList = new List<GameObject>();
    private bool display = false;
    private double timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = -1;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //GenerateSequence(gameManager.sequenceLength);
        //StartCoroutine(DisplayCoroutine());
    }

    IEnumerator<float> DisplayCoroutine()
    {
        //WaitForSecondsRealtime wait = new WaitForSecondsRealtime(2.0f);
        //WaitForSeconds wait = new WaitForSeconds(2.0f);
        //yield return new WaitForSecondsRealtime(intervalTime);
        foreach (var letter in sequence)
        {
            //wait = new WaitForSecondsRealtime((float)intervalTime);
            //wait = new WaitForSeconds((float)intervalTime);
            //Debug.Log(letter);
            //testseq += letter;
            letterCounter++;
            //lightComponent = lightPrefab.GetComponent<Light>();
            //lightComponent.color = colours[Random.Range(0, colours.Length)];
            //lightComponent.color = coloursDict[letter];
            GameObject prefabInstance = Instantiate(lightPrefab, GenerateSpawnPosition(), lightPrefab.transform.rotation);
            Light instancedLightComponent = prefabInstance.GetComponent<Light>();
            instancedLightComponent.color = coloursDict[letter];
            //intervalTime = calculateInterval(letterCounter);
            //if (letterCounter > 5)
            //{
            //    if (intervalTime <= 0.5f)
            //    {
            //        intervalTime = 0.5f;
            //    }
            //    else
            //    {
            //        intervalTime = intervalTime - difficultyFactor;

            //    }
            //}
            //yield return new WaitForSecondsRealtime(intervalTime);
            Debug.Log("Curent interval: " + intervalTime);
            //yield return new WaitForSecondsRealtime(intervalTime);
            //yield return wait;
            intervalTime = calculateInterval(letterCounter);
            yield return Timing.WaitForSeconds((float)intervalTime);
        }
        //yield return new WaitForSecondsRealtime(intervalTime);
        gameManager.Invoke("ShowGameOver", 4);
        //Debug.Log(testseq);
    }

    IEnumerator DisplayCoroutine2()
    {
        //WaitForSecondsRealtime wait = new WaitForSecondsRealtime(2.0f);
        //WaitForSeconds wait = new WaitForSeconds(2.0f);
        //yield return new WaitForSecondsRealtime(intervalTime);
        //wait = new WaitForSecondsRealtime((float)intervalTime);
        //wait = new WaitForSeconds((float)intervalTime);
        //Debug.Log(letter);
        //testseq += letter;
        foreach (var light in lightsList)
        {
            light.SetActive(true);
            letterCounter++;
            Debug.Log(letterCounter);
            Debug.Log("Curent interval: " + intervalTime);
            //yield return new WaitForSecondsRealtime(intervalTime);
            intervalTime = calculateInterval(letterCounter);
            yield return new WaitForSeconds((float)intervalTime);
        }
        gameManager.Invoke("ShowGameOver", 4);
        //lightComponent = lightPrefab.GetComponent<Light>();
        //lightComponent.color = colours[Random.Range(0, colours.Length)];
        //lightComponent.color = coloursDict[letter];
        //GameObject prefabInstance = Instantiate(lightPrefab, GenerateSpawnPosition(), lightPrefab.transform.rotation);
        //Light instancedLightComponent = prefabInstance.GetComponent<Light>();
        //instancedLightComponent.color = coloursDict[letter];
        //intervalTime = calculateInterval(letterCounter);
        //if (letterCounter > 5)
        //{
        //    if (intervalTime <= 0.5f)
        //    {
        //        intervalTime = 0.5f;
        //    }
        //    else
        //    {
        //        intervalTime = intervalTime - difficultyFactor;

        //    }
        //}
        //yield return new WaitForSecondsRealtime(intervalTime);
        Debug.Log("Curent interval: " + intervalTime);
    //yield return new WaitForSecondsRealtime(intervalTime);
        intervalTime = calculateInterval(letterCounter);
        yield return new WaitForSeconds((float)intervalTime);
        //yield return new WaitForSecondsRealtime(intervalTime);
        //gameManager.Invoke("ShowGameOver", 4);
        //Debug.Log(testseq);
    }

    public void DisplayLights()
    {
        letterIndex++;
        letterCounter++;
        intervalTime = calculateInterval(letterCounter);
        char currentLetter = sequence[letterIndex];
        GameObject prefabInstance = Instantiate(lightPrefab, GenerateSpawnPosition(), lightPrefab.transform.rotation);
        Light instancedLightComponent = prefabInstance.GetComponent<Light>();
        instancedLightComponent.color = coloursDict[currentLetter];
        //lightComponent = lightPrefab.GetComponent<Light>();
        //lightComponent.color = colours[Random.Range(0, colours.Length)];
        //lightComponent.color = coloursDict[currentLetter];
        //Instantiate(lightPrefab, GenerateSpawnPosition(), lightPrefab.transform.rotation);
        if (!(letterCounter >= sequence.Length))
            Invoke("DisplayLights", (float)intervalTime);
        //if (letterCounter > 5)
        //{
        //    if (intervalTime <= 0.5f)
        //    {
        //        intervalTime = 0.5f;
        //    }
        //    else
        //    {
        //        intervalTime = intervalTime - difficultyFactor;

        //    }
        //}
        Debug.Log("Curent interval: " + intervalTime);
        if (letterCounter == sequence.Length)
            gameManager.Invoke("ShowGameOver", 4);
        //yield return new WaitForSeconds(intervalTime);
    }

    void SpawnLight()
    {
        char currentLetter = sequence[letterIndex];
        lightComponent = lightPrefab.GetComponent<Light>();
        //lightComponent.color = colours[Random.Range(0, colours.Length)];
        lightComponent.color = coloursDict[currentLetter];
        Instantiate(lightPrefab, GenerateSpawnPosition(), lightPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (display)
        {
            timer += Time.deltaTime;

            if(timer >= intervalTime)
            {
                lightsList[letterCounter].SetActive(true);
                letterCounter++;
                Debug.Log("Curent interval: " + intervalTime);
                timer = timer - intervalTime;
                intervalTime = calculateInterval(letterCounter); 
            }

            if( letterCounter == sequence.Length)
            {
                gameManager.Invoke("ShowGameOver", 4);
                display = false;
            }
        }
        //GenerateSequence(gameManager.sequenceLength);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = UnityEngine.Random.Range(-spawnRange + plate.transform.position.x, spawnRange + plate.transform.position.x);
        float spawnPosY = UnityEngine.Random.Range(-spawnRange + plate.transform.position.y, spawnRange + plate.transform.position.y);
        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, lightPrefab.transform.position.z);
        return spawnPosition;
    }

    private double calculateInterval(int nucNumber)
    {
        return System.Math.Round((Mathf.Pow(difficultyFactor, nucNumber)) * maxInterval + minInterval, 2);
    }

    private void GenerateSequence(int length)
    {
        const string nucleotide = "ATGC";
        sequence = new string(Enumerable.Repeat(nucleotide, length).Select(s => s[random.Next(s.Length)]).ToArray());
        Debug.Log(length);
        Debug.Log(sequence);
        //foreach (var letter in sequence)
        //{
        //    GameObject prefabInstance = (GameObject)Instantiate(lightPrefab, GenerateSpawnPosition(), lightPrefab.transform.rotation);
        //    Light instancedLightComponent = prefabInstance.GetComponent<Light>();
        //    instancedLightComponent.color = coloursDict[letter];
        //    prefabInstance.SetActive(false);
        //    lightsList.Add(prefabInstance);
        //}

    }

    public void StartGame()
    {
        GenerateSequence(gameManager.sequenceLength);
        //display = true;
        //DisplayLights();
        //StartCoroutine(DisplayCoroutine2());
        StopAllCoroutines();
        //coroutine = DisplayCoroutine();
        //StartCoroutine(coroutine);
        Timing.RunCoroutine(DisplayCoroutine());
    }
}
