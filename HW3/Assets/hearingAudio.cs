using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearingAudio : MonoBehaviour
{
	GameObject CurrentCheckPoint;
	float dis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		 CurrentCheckPoint = GameObject.FindGameObjectsWithTag("current")[0];
         dis = Vector3.Distance(CurrentCheckPoint.transform.position,transform.position);
		 if (dis<=530)
		 {	
			
			 GetComponent<AudioSource>().enabled = true;
			 // CurrentCheckPoint.GetComponent<AudioListener>().enabled = true;
		 }
		 else
		 {
			 GetComponent<AudioSource>().enabled = false;
		 }
		 
		 GameObject leftEar = GameObject.Find("/Leap Rig/Main Camera/leftEar");
		 GameObject rightEar = GameObject.Find("/Leap Rig/Main Camera/rightEar");
		 
		 // leftEar.transform.localPosition = new()
		 
		 float LEtoNCP = Vector3.Distance(CurrentCheckPoint.transform.position,leftEar.transform.position);
		 float REtoNCP = Vector3.Distance(CurrentCheckPoint.transform.position,rightEar.transform.position);
		 
		 
		 if (LEtoNCP <REtoNCP)
		 {
			  GetComponent<AudioSource>().panStereo = -0.1f * (REtoNCP - LEtoNCP);
		 }
		 else if (LEtoNCP > REtoNCP)
		 {
			 GetComponent<AudioSource>().panStereo = 0.1f * (LEtoNCP - REtoNCP);
		 }
		 else
		 {
			  GetComponent<AudioSource>().panStereo = 0;
		 }

		// print(dis);
		
		if (dis<=530)
		{
			GetComponent<AudioSource>().volume =  0.6f * (1-dis/530);
		}
		else
		{
			GetComponent<AudioSource>().volume =  0;
		}
    }
}
