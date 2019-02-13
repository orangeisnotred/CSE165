using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    Quaternion fingerRot;
    GameObject LeftHand;
    void Start()
    {
       
      
    }

    // Update is called once per frame
    void Update()
    {
        LeftHand = GameObject.Find("Left Interaction Hand Contact Bones");
        if (LeftHand)
        {
            fingerRot = LeftHand.transform.GetChild(5).rotation;
            Debug.Log(fingerRot.eulerAngles.x);
            if (fingerRot.eulerAngles.x < 150)
            {
                Vector3 pos = transform.position;
                pos.z += .05f;

                transform.position = pos;
            }
        }

    }
}
