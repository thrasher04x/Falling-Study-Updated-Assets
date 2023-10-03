﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class mover : MonoBehaviour
{
    public Scene m_Scene;
    public string scene_name;
    private Level2 Level2;
    private ResponseTime ResponseTime;
    private Variables Variables;
    // public float DistanceZ = 0.0f; //This variable tells the stimulus how much to move.
    //public string Stimpos; // This variable holds the PI number. You can change this in the inspector after adding it as a component for each stimulus.

    public float Shoulder;
    Vector3 tempPos; // Needed for moving the stimulus.

    void Awake()
    {
        Variables = GameObject.FindGameObjectWithTag("UI").GetComponent<Variables>(); //This pulls the variables from the variables script. It's a handy way to call variables from objects without manualy telling unity where to look for the corisponding script every time a new scene loads. 
    }

    private void Start()
    {
        Shoulder = Variables.shoulder; 
    //    DistanceZ = Stimpos * Variables.arm;
    }

    void Update()
    {
        m_Scene = SceneManager.GetActiveScene();
        scene_name = m_Scene.name;   
        /*tempPos = transform.position;
        tempPos.z = DistanceZ;
        tempPos.y = Shoulder;
        transform.position = tempPos; // This does the actual stimulus moving.*/
    }
}