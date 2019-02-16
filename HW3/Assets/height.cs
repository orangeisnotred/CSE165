using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class height : MonoBehaviour
{
    // Start is called before the first frame update
	float heightDiff;
	GameObject gameObject;
	
    void Start()
    {
		gameObject = GameObject.Find("/Leap Rig/Main Camera");
        
    }

    // Update is called once per frame
    void Update()
    {
		heightDiff =-gameObject.GetComponent<wayfingding2D>().heightDiff;
		string height = heightDiff.ToString("N3");
		transform.GetComponent<Text>().text = "H_diff: "+height;
        
       
    }
}
