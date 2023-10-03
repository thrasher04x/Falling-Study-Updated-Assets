BEFORE OPENING THE PROJECT MAKE SURE YOU ARE RUNING UNITY VERSION 2018.2.20f1 OR BELOW.



THE SCRIPTS “PositionData”, “ClickerTicker”, AND “ResponseTime” REQUIRE YOU TO CHANGE THE DESTINATION FOLDERS. CHANGE THE PUBLIC STRING 

“folder” IN EACH OF THE SCRIPTS TO YOUR DESIRED FOLDER PATH BEFORE RUNNING THE PROGRAM. AFTER THIS HAS BEEN CHANGED ONCE, YOU WILL NOT NEED

TO CHANGE IT AGAIN. 



DO NOT HAVE EXCEL OPEN



Distances- 0 meters (near), 3 meters (mid), and 6 meters (far).



When starting the experiment begin on the "setup" scene- units are in meters. 

Run from unity.

- While they are doing this you can prepare the VR:



	- Make sure the correct project is open. (e.g., Hannah's project 02)



	- Press the play button at the top of Unity to initialize the project.  



	- Press the variables button







Invite the participant to stand in the experimental area and take the necessary measurements (e.g., eye height, shoulder height, arm length)



	- Enter the measurements in meters. Enter handedness and which order of conditions they are in (e.g., 1,2,3). 



0 is the practice trials

1 is Far

2 is Mid

3 is Near



Read the experimental instructions verbatim and demonstrate the pose to be held throughout the experiment. Show the participant the head mounted display (HMD).



Allow the participant to put on the HMD and help them fit it properly. (It should be comfortable but not too loose)



Make sure the image is clear (not blurry) by adjusting the knobs at the bottom of the HMD. 



Make sure they are standing with enough room in the lab space.



Press R to center them in the virtual space. This will zero out the x-y-z coordinates of the headset.



The X button is NO

The A button is YES

Use the thumbstick to change scenes while the black screen is present 



Once the experiment is over, press the play button again in Unity. 



Scripts: 



ClickerTicker- This script records an error whenever the Z key is pressed down. It also re-centers the participant in the environment when the R key is pressed down.



Level2- This script controls how many scenes are in each block and is responsible for randomly choosing the next scene after each trial. 



mover- This script should be attached to the stimulus and is responsible for placing that stimulus in relation to the participants arm length.



Order- Is referenced by the ResponseTime script to record the order of positions the participant would stand in.



PositionData- Records Data about what trial the participant is in with relation to the position and rotation of the headset.



ResponseTime- records the current scene, the yes or no response, and other relevant information. It is also responsible for controlling how many blocks of trials are presented.



Variables- contains the data entered at the setup screen



