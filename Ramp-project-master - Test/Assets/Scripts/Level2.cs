﻿using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class Level2 : MonoBehaviour
{
    protected const int MAX = 28;//Total number of trials 
    public List<int> scenesPrac = new List<int>();
    public List<int> scenesFar = new List<int>();
    public List<int> scenesMid = new List<int>();
    public List<int> scenesNear = new List<int>();
    public int Block;
    public int Chunk;
    public string Handedness;
    public bool KeysEnabled = false;
    private bool yes;
    private bool visible = true;
    public float WaitTimer = 0.0f;
    private bool updateTimer = false;
    public bool TestStart = false;
    public bool Testend = false;
    public bool thumbstick = false;
    public float Distance = 0.0f;
    public float Distance2 = 10.0f;
    public float Distance3 = 0.0f;
    public GameObject Canvas3;
    public GameObject ExpFinish;
    public GameObject controller;
    public int Trial;
    private ResponseTime ResponseTime;
    private Order Order;
    Vector3 tempPos;
    Vector3 tempPos2;
    Vector3 tempPos3;
   

    void Start()

    {   
        updateTimer = true;
        WaitTimer = 00.0f;
       
    }
    void Update()
    {
        ResponseTime = GameObject.FindGameObjectWithTag("ResponseTime").GetComponent<ResponseTime>();
        Order = GameObject.FindGameObjectWithTag("UI").GetComponent<Order>();
        if (ResponseTime.recording == true)
        {
            if (Testend == false)
            {
                if (TestStart == true)
                {

                    if (KeysEnabled == true)
                    {
                        if (updateTimer) //Starts the timer when the scene starts.
                        {
                            WaitTimer += Time.deltaTime * 1;
                        }
                        if (WaitTimer > 2.0f)// allows the participant to make a decition after 2 seconds

                        {
                            //tempPos2 = transform.position; tempPos2.z = Distance2; transform.position = tempPos2; // moves the participant in front of the stimulus
                            if (OVRInput.GetDown(OVRInput.Button.One) || (OVRInput.GetDown(OVRInput.Button.Three)))
                            {
                                Debug.Log(Trial);
                                Trial++;
                                //tempPos = transform.position; tempPos.z = Distance; transform.position = tempPos;// moves the participant to the loading stage
                                WaitTimer = 0.0f;
                                updateTimer = true;
                                if (Order.Condition == 0)
                                {


                                    if (scenesPrac.Count == 0)
                                    {
                                        Chunk = Chunk + 1;
                                        if (Block <= 4)
                                        { Block = Block + 1; }
                                        TestStart = false;
                                    }
                                    // Get a random index from the list of remaining level 
                                    int randomIndex = Random.Range(0, scenesPrac.Count);
                                    int level = scenesPrac[randomIndex];
                                    scenesPrac.RemoveAt(randomIndex); // Removes the level from the list                       
                                    SceneManager.LoadScene(level);
                                }
                                if (Order.Condition == 1)
                                {

                                
                                    if (scenesFar.Count == 0) 
                                    {                                  
                                        if (Chunk > 3) // Loads the ending scene when the disired blocks of trials have been run
                                            {
                                            SceneManager.LoadScene("End");
                                            Testend = true;
                                            ResponseTime.recording = false;
                                            }
                                        if (Block >= 4) // Loads the ending scene when the disired blocks of trials have been run
                                        {
                                            Chunk = Chunk + 1;
                                            Block = 1;
                                                                                   
                                        }
                                        if (Block <= 4)
                                        { Block = Block + 1; } 
                                    TestStart = false;                                    
                                    }
                                 //Get a random index from the list of remaining level 
                                int randomIndex = Random.Range(0, scenesFar.Count);
                                int level = scenesFar[randomIndex];
                                scenesFar.RemoveAt(randomIndex); // Removes the level from the list                       
                                SceneManager.LoadScene(level);
                                }
                                if (Order.Condition == 2)
                                {


                                    if (scenesMid.Count == 0)
                                    {
                                        if (Chunk > 3) // Loads the ending scene when the disired blocks of trials have been run
                                        {
                                            SceneManager.LoadScene("End");
                                            Testend = true;
                                            ResponseTime.recording = false;
                                        }
                                        if (Block >= 4) // Loads the ending scene when the disired blocks of trials have been run
                                        {
                                            Chunk = Chunk + 1;
                                            Block = 1;
                                           
                                        }
                                        if (Block <= 4)
                                        { Block = Block + 1; }
                                        TestStart = false;
                                    }
                                    // Get a random index from the list of remaining level 
                                    int randomIndex = Random.Range(0, scenesMid.Count);
                                    int level = scenesMid[randomIndex];
                                    scenesMid.RemoveAt(randomIndex); // Removes the level from the list                       
                                    SceneManager.LoadScene(level);
                                }
                                if (Order.Condition == 3)
                                {


                                    if (scenesNear.Count == 0)
                                    {
                                        if (Chunk > 3) // Loads the ending scene when the disired blocks of trials have been run
                                        {
                                            SceneManager.LoadScene("End");
                                            Testend = true;
                                            ResponseTime.recording = false;
                                        }
                                        if (Block >= 4) // Loads the ending scene when the disired blocks of trials have been run
                                        {
                                            Block = 1;
                                            Chunk = Chunk + 1;
                                            
                                           
                                        }
                                        if (Block <= 4)
                                        { Block = Block + 1; }
                                        TestStart = false;
                                    }
                                    // Get a random index from the list of remaining level 
                                    int randomIndex = Random.Range(0, scenesNear.Count);
                                    int level = scenesNear[randomIndex];
                                    scenesNear.RemoveAt(randomIndex); // Removes the level from the list                       
                                    SceneManager.LoadScene(level);
                                }
                            }
                        }
                    }

                    if (KeysEnabled == false)
                    {
                        if (updateTimer) //Starts the timer when the scene starts.
                        { WaitTimer += Time.deltaTime * 1; }
                    }
                    if (WaitTimer > 2.0f)
                    {
                        KeysEnabled = true;
                    }

                }

                if (TestStart == false)
                {
                    updateTimer = false;
                    if (Chunk == 4)
                    {
                        SceneManager.LoadScene("End");
                        Canvas3.SetActive(visible);
                        ExpFinish.SetActive(visible);
                        Testend = true;
                    }
                    if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
                    {
                        thumbstick = true;
                    }
                }
            }              
            if (thumbstick == true)
            {
                //tempPos = transform.position; tempPos.z = Distance; transform.position = tempPos;
                WaitTimer = 0.0f;
                if (Order.Condition == 0)
                {
                    scenesPrac = new List<int>(Enumerable.Range(1, 7));

                    int randomIndex = Random.Range(0, scenesPrac.Count);
                    int level = scenesPrac[randomIndex];
                    scenesPrac.RemoveAt(randomIndex); // Removes the level from the list

                    SceneManager.LoadScene(level);
                    updateTimer = true;
                    TestStart = true;
                    thumbstick = false;
                }
                if (Order.Condition == 1)
                    {
                    scenesFar = new List<int>(Enumerable.Range(1, 7));

                    int randomIndex = Random.Range(0, scenesFar.Count);
                    int level = scenesFar[randomIndex];
                    scenesFar.RemoveAt(randomIndex); // Removes the level from the list
                
                    SceneManager.LoadScene(level);
                    updateTimer = true;
                    TestStart = true;
                    thumbstick = false;
                }
                if (Order.Condition == 2)
                {
                    scenesMid = new List<int>(Enumerable.Range(8, 7));

                    int randomIndex = Random.Range(0, scenesMid.Count);
                    int level = scenesMid[randomIndex];
                    scenesMid.RemoveAt(randomIndex); // Removes the level from the list

                    SceneManager.LoadScene(level);
                    updateTimer = true;
                    TestStart = true;
                    thumbstick = false;
                }
                if (Order.Condition == 3)
                {
                    scenesNear = new List<int>(Enumerable.Range(15, 7));

                    int randomIndex = Random.Range(0, scenesNear.Count);
                    int level = scenesNear[randomIndex];
                    scenesNear.RemoveAt(randomIndex); // Removes the level from the list

                    SceneManager.LoadScene(level);
                    updateTimer = true;
                    TestStart = true;
                    thumbstick = false;
                }
                
            }
        }
    }
}

 
                

    

