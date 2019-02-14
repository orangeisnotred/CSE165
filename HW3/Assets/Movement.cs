using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    Quaternion fingerRot;
    GameObject LeftHand;
    GameObject RightHand;
    Transform LeftPalm;
    Transform RightPinky;
    Vector3 initialPos;
    Quaternion initialRot;
    Quaternion newRot;
    bool stored = false;
    void Start()
    {
       
      
    }

    // Update is called once per frame
    void Update()
    {
		
		LeftHand = GameObject.Find("Left Interaction Hand Contact Bones");
		if (LeftHand != null)
			LeftPalm = LeftHand.transform.GetChild(LeftHand.transform.childCount - 1);
		
		RightHand = GameObject.Find("Right Interaction Hand Contact Bones");
		if (RightHand != null)
			RightPinky = RightHand.transform.GetChild(LeftHand.transform.childCount - 2);
        //Debug.Log(RightPinky.localRotation.eulerAngles.x);
        if (LeftHand && RightHand)
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

                
                pos = diff2 * (pos * (30 * (RightPinky.localRotation.eulerAngles.x/150)));

                pos2 = transform.position;

                pos2 = pos2 + (pos * Time.deltaTime);
               
                transform.position = pos2;

            


            }
            else
            {
                stored = false;
            }
        }

    }
}




////////////////////////////////              WALKING            /////////////////////////////
//        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > 0.0f && continuousMotion)
//        {
//            if (!stored)
//            {
//                initialPos.x = transform.localPosition.x;
//                initialPos.z = transform.localPosition.z;
//                if (superman)
//                {
//                    initialPos.y = transform.localPosition.y;
//                }
//                initialRot.Set(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w);
//                stored = true;
//            }
           
//            newRot.Set(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w);
            
//            Quaternion diff = newRot * Quaternion.Inverse(initialRot);




//Debug.Log(diff.eulerAngles.y);


//            Quaternion finRot = (Quaternion.Slerp(transform.root.transform.rotation, transform.root.transform.rotation * diff, 0.01f));
//transform.root.transform.rotation = finRot;
//            if (!superman)
//            {
//                transform.root.transform.rotation = Quaternion.Euler(new Vector3(0f, transform.root.transform.rotation.eulerAngles.y, 0f));
//            }
   

//            //////////////////POSITION///////////////////
//            Vector3 pos;
//Vector3 pos2;
//Vector3 pos3 = transform.localPosition;
//Quaternion diff2 = transform.rotation * Quaternion.Inverse(transform.localRotation);


//pos = transform.localPosition - initialPos;
  
//            pos = diff2* (pos* 10);
            
//            pos2 = transform.root.transform.position;
            
//            pos2 = pos2 + (pos* Time.deltaTime); 
//            if(!superman)
//            pos2.y = transform.root.transform.position.y;
//            transform.root.transform.position = pos2;

//        }
