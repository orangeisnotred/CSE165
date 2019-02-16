using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    Quaternion fingerRot;
    GameObject LeftHand;
    GameObject RightHand;
    GameObject Tracker;
    Transform LeftPalm;
    Transform RightPinky;
    Vector3 initialPos;
    Quaternion initialRot;
    Quaternion newRot;
    bool stored = false;
	
	
	Vector3 rot_pre;
	Vector3 rot_now;
	float pitch_pre;
	float pitch_now;
	public AudioClip MotorClip;
	public AudioSource MotorSource;
	bool MotorSound = false;
	float t;
	
    void Start()
    {
		rot_pre = (transform.localRotation).eulerAngles;
		MotorSource.clip = MotorClip;

    }

    // Update is called once per frame
    void Update()
    {
		
		
		
        LeftHand = GameObject.Find("Left Interaction Hand Contact Bones");
        LeftPalm = LeftHand.transform.GetChild(15);
        RightHand = GameObject.Find("Right Interaction Hand Contact Bones");
        RightPinky = RightHand.transform.GetChild(14);
       

        if (LeftHand && RightHand && CountDown.CanMove)
        {
            fingerRot = RightHand.transform.GetChild(5).localRotation;
            // Debug.Log(fingerRot.eulerAngles.x);
            if (fingerRot.eulerAngles.x < 150)
            {
                if (!stored)
                {

                    initialPos.x = LeftPalm.transform.localPosition.x;
                    initialPos.y = LeftPalm.transform.localPosition.y;
                    initialPos.z = LeftPalm.transform.localPosition.z;
                    initialRot.Set(LeftPalm.transform.localRotation.x, LeftPalm.transform.localRotation.y, LeftPalm.transform.localRotation.z, LeftPalm.transform.localRotation.w);

                    GameObject prefab = Resources.Load("Tracker") as GameObject;
                    Tracker = Instantiate(prefab) as GameObject;
                    Tracker.transform.parent = GameObject.Find("Left Interaction Hand Contact Bones").transform;
                    Tracker.transform.position = new Vector3(LeftPalm.transform.position.x, LeftPalm.transform.position.y, LeftPalm.transform.position.z);
                    //Tracker.transform.localPosition = new Vector3(initialPos.x, initialPos.y, initialPos.z);


                    stored = true;
                }
                newRot.Set(LeftPalm.transform.localRotation.x, LeftPalm.transform.localRotation.y, LeftPalm.transform.localRotation.z, LeftPalm.transform.localRotation.w);

                Quaternion diff = newRot * Quaternion.Inverse(initialRot);
                //Vector3 pos = transform.position;
                //pos.z += .05f;

                //  transform.position = pos;

                Quaternion finRot = (Quaternion.Slerp(transform.rotation, transform.rotation * diff, 0.01f));
                transform.rotation = finRot;

                //////////////////POSITION///////////////////
                Vector3 pos;
                Vector3 pos2;
                Vector3 pos3 = LeftPalm.transform.localPosition;
                Quaternion diff2 = LeftPalm.transform.rotation * Quaternion.Inverse(LeftPalm.transform.localRotation);


                pos = LeftPalm.transform.localPosition - initialPos;

                pos = Vector3.Normalize(pos);


                pos = diff2 * (pos * (30 * (RightPinky.localRotation.eulerAngles.x / 150)));

                pos2 = transform.position;

                pos2 = pos2 + (pos * Time.deltaTime);

                transform.position = pos2;
				
				Vector3 temp = pos * Time.deltaTime;
				
				rot_now = (transform.localRotation).eulerAngles;
				if(Mathf.Abs(rot_now.x - rot_pre.x)>=0.4 && Mathf.Max(temp.x,temp.y,temp.z)>0.4 && !MotorSound)
				{
					MotorSource.Play();
					MotorSound = true;
					t = Time.time;
				}
				if(Time.time - t >10)
				{
					MotorSound = false;
				}
				
				
				Debug.Log("Pitch: "+(rot_now - rot_pre));
				//Debug.Log("V: "+(pos * Time.deltaTime));

				rot_pre = rot_now;


            }
            else
            {
                Destroy(Tracker);
                stored = false;
            }
        }

    }
}


