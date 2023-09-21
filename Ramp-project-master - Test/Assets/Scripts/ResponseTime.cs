﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ResponseTime : MonoBehaviour
{

    private System.Collections.Generic.List<float> timers;
    private bool updateTimer = false;
    public float levelTimer = 0.0f;
    public float WaitTimer = 0.0f;
    public string Trial = null;
    public int TrialNum = 1;
    public int counter1 = 0;
    public int trialminusprac;
    public int trueblock;

    public static float Arm = 0.0f;
    public GameObject Canvas;
    public GameObject Canvas2;
    public GameObject Canvas3;
    public GameObject TrialStart;
    public GameObject ExperimentStart;
    public GameObject PracticeBreak;
    public GameObject Wait;
    public GameObject ExpFinish;
    public GameObject Break;
    public GameObject subjectnum;
    public GameObject movers;
    public GameObject NextTrial;
   
   // public GameObject Distancefromp;

    //public float ArmLength = 0.0f;
    private bool visible = true;
    public bool TestStart = false;
    public bool practice = false;
    public bool recording = false;
    public bool posrecording = false;
    public bool ParticipantReady;
    public string folder = "C:\\Users\\12703\\Documents\\VRData\\Falling Study\\";
    // public string folder = "C:\\Users\\PACLab\\Documents\\VRData\\RampData\\";


    //private bool isTiming = false;
    //private float timeTillKeyisPressed = 0;
    private Level2 Level2;
    private mover mover;
    private Variables Variables;
    private Order Order;
    private bool KeysEnabled = false;
    


    void Awake()
    {

       // mover = Distancefromp.GetComponent<mover>();
        Level2 = subjectnum.GetComponent<Level2>();
        // Variables = Part2.GetComponent<Variables>();//mover = movers.GetComponent<mover>();
        mover = GameObject.FindGameObjectWithTag("Player").GetComponent<mover>();
        // Arm = ArmLength;
    }






    // Use this for initialization
    void Start()
    {
        ExperimentStart.SetActive(visible);
        TrialStart.SetActive(!visible);
        updateTimer = true;
        PracticeBreak.SetActive(!visible);
        levelTimer = 00.0f;
        WaitTimer = 00.0f;
        //isHiding = true;
        ExpFinish.SetActive(!visible);
        NextTrial.SetActive(!visible);
        Wait.SetActive(!visible);
        Canvas3.SetActive(!visible);
        Canvas2.SetActive(!visible);
    }





    // Update is called once per frame
    void Update()
    {
        trueblock = Level2.Block - 1;// These are here because the first block of 15 trials are for practice and are not recorded
        trialminusprac = Level2.Trial - 15;
        mover = GameObject.FindGameObjectWithTag("Player").GetComponent<mover>();
        Variables = GameObject.FindGameObjectWithTag("UI").GetComponent<Variables>();
        Order = GameObject.FindGameObjectWithTag("UI").GetComponent<Order>();
        

#pragma warning disable CS0618 // Type or member is obsolete
        Trial = Application.loadedLevelName;
#pragma warning restore CS0618 // Type or member is obsolete





        if (TestStart == true)
        {

            if (recording == true)
            {


                if (KeysEnabled == true)
                {

                    
                    if (updateTimer) //Starts the timer when the scene starts.
                    { WaitTimer += Time.deltaTime * 1; }





                    if (WaitTimer > 2.0f)

                    {

                        levelTimer += Time.deltaTime * 1;
                        Canvas.SetActive(!visible);
                        Canvas2.SetActive(!visible);
                        Wait.SetActive(!visible);
                        NextTrial.SetActive(!visible);

                        if (Level2.Block > 1)
                        {
                            posrecording = true;
                            Debug.Log("PositionRecording");
                        }



                        if (OVRInput.GetDown(OVRInput.Button.One))//Button (X) on the touch controller

                        {

                            counter1 = counter1 + 1;
                            TrialNum = TrialNum + 1;
                            Canvas.SetActive(visible);
                         
                                posrecording = false;
                                StreamWriter sw = File.AppendText(folder + "ParticipantData" + Variables.participant + ".csv");// This is where the data will be written
                                sw.WriteLine(Variables.participant + "," + Trial + "," + trialminusprac + "," + trueblock + "," + Variables.hand + "," + Variables.arm + "," + mover.scene_name + "," + Order.Condition + "," + "Y" + "," + (levelTimer));//writes the current scene, the yes or no response, and the time since the level started to the file in the path above. 
                                sw.Close();
                            

                            Debug.Log(Trial);//Confirms current scene
                            Debug.Log("No");
                            WaitTimer = 00.0f;
                            levelTimer = 00.0f;
                            updateTimer = true;
                            KeysEnabled = false;
                            ParticipantReady = false;
                            if (Level2.Block <= 4)
                            {
                                
                                if (TrialNum == 8)// this should be changed with the max number of trials
                                {
                                    TrialNum = 1; Debug.Log("t1");
                                    TestStart = false;// sets a break between blocks of trials
                                }
                            }

                        }

                        if (OVRInput.GetDown(OVRInput.Button.Three))//Tells unity which button to listen for. In this case (A)

                        {

                            counter1 = counter1 + 1;
                            TrialNum = TrialNum + 1;
                            Canvas.SetActive(visible);
                           
                                posrecording = false;
                                StreamWriter sw = File.AppendText(folder + "ParticipantData" + Variables.participant + ".csv"); // This is where the data will be written
                                sw.WriteLine(Variables.participant + "," + Trial + "," + trialminusprac + "," + trueblock + "," + Variables.hand + "," + Variables.arm + "," + mover.scene_name + "," + Order.Condition + "," + "N" + "," + (levelTimer));//writes the current scene, the yes or no response, and the time since the level started to the file in the path above. 
                                sw.Close();
                         

                            Debug.Log(Trial);//Confirms current scene
                            Debug.Log("Yes");//Confirms button press in the debug log. 
                            WaitTimer = 00.0f;
                            levelTimer = 00.0f;
                            updateTimer = true;//updateTimer = true;//Resets the timer
                            KeysEnabled = false;
                            ParticipantReady = false;
                            if (Level2.Block <= 4)
                            {
                                if (TrialNum == 8)
                                {
                                    TrialNum = 1; Debug.Log("t1");
                                    TestStart = false;
                                }
                            }
                        }
                    }
                    if (Level2.Block <= 1)
                    {
                        
                        //if (counter1 == 7) { practice = true;  }
                        //if (counter1 == 14) { practice = true;  }

                    }
                }

                if (KeysEnabled == false)
                {
                    if (updateTimer) //Starts the timer when the scene starts.
                    {
                        WaitTimer += Time.deltaTime * 1;
                    }
                }



                if (WaitTimer > 1.0f)

                {
                    Wait.SetActive(!visible);
                    Canvas.SetActive(visible);
                    Canvas2.SetActive(visible);
                    NextTrial.SetActive(visible);
                }


                if (WaitTimer > 2.0f)
                {
                    KeysEnabled = true;
                    Canvas.SetActive(!visible);
                    Canvas2.SetActive(!visible);
                    Wait.SetActive(!visible);
                    NextTrial.SetActive(!visible);
                }

                if (Level2.Testend == true)
                {
                    recording = false;
                }

            }

            if (ParticipantReady == false)
            {
                recording = false;
                Canvas.SetActive(visible);
                Break.SetActive(visible);
                if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
                {
                    
                    WaitTimer = 0.0f;
                    Wait.SetActive(visible);
                    Break.SetActive(!visible);
                    TrialStart.SetActive(!visible);
                    NextTrial.SetActive(!visible);
                    PracticeBreak.SetActive(!visible);

                    updateTimer = true;
                    recording = true;
                    ParticipantReady = true;

                }
            }
            if (practice == true)
            {
                
                Canvas.SetActive(visible);
                Break.SetActive(!visible);
                PracticeBreak.SetActive(visible);
                if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
                {
                    counter1 = counter1 + 1;
                    WaitTimer = 0.0f;
                    Canvas.SetActive(!visible);
                    TrialStart.SetActive(!visible);
                    NextTrial.SetActive(!visible);
                    PracticeBreak.SetActive(!visible);
                    
                    updateTimer = true;
                    recording = true;
                    practice = false;

                }
            }
        }
        if (TestStart == false)
        {

            Debug.Log("false");
            updateTimer = false;
            Canvas.SetActive(visible);

           
            if ((Level2.Block == 1) || (Level2.Block == 2) || (Level2.Block == 3) || (Level2.Block == 4))
            {
                TrialStart.SetActive(visible);
                if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))

                {
                    recording = true;
                    
                    
                    updateTimer = true;
                    WaitTimer = 0.0f;
                    TrialStart.SetActive(!visible);
                    NextTrial.SetActive(!visible);
                    PracticeBreak.SetActive(!visible);

                                     
                        Level2.thumbstick = true;
                        //Level2.Block = Level2.Block + 1;
                    
                    TestStart = true;
                    ParticipantReady = true;
                }
            }
           

            if (Level2.Block == 1)
                
            {
                TrialStart.SetActive(visible);



                if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
                {

                    StreamWriter sw = File.AppendText(folder + "ParticipantData" + Variables.participant + ".csv");// This is where the data will be written
                    sw.WriteLine("PARTICIPANT" + "," + "SCENE" + "," + "TRIAL" + "," + "BLOCK" + "," + "HANDDOM" + "," + "ARMLENGTH" + "," + "CONDITION" + "," + "ORDER" + "," + "RESPONSE" + "," + "RESPONSETIME");//writes the current scene, the yes or no response, and the time since the level started to the file in the path above. 
                    sw.Close();
                    Level2.thumbstick = true;
                    WaitTimer = 0.0f;
                    
                    ExperimentStart.SetActive(!visible);
                    TrialStart.SetActive(!visible);
                    NextTrial.SetActive(!visible);
                    //Level2.Block = Level2.Block + 1;
                    updateTimer = true;
                    TestStart = true;
                    ParticipantReady = true;
                }
            }
           
            //if (Level2.Block == 5)
            //{

              //  Canvas.SetActive(!visible);

            //}

        }
                        
    }

}



    

