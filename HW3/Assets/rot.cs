using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rot : MonoBehaviour
{
	Vector3 rot_pre;
	Vector3 rot_now;
	GameObject Leap;
    // Start is called before the first frame update
    void Start()
    {
		Leap = GameObject.Find("/Leap Rig");
        rot_pre = (Leap.transform.localRotation).eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
		
		rot_now = (Leap.transform.localRotation).eulerAngles;

		
		transform.GetComponent<Text>().text = "pitch: "+(rot_now - rot_pre).ToString();
    
		Debug.Log("Pitch: "+(rot_now - rot_pre));
		//Debug.Log("V: "+(pos * Time.deltaTime));

		rot_pre = rot_now;
		
    } 
}
