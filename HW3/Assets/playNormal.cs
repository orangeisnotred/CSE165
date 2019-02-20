using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playNormal : MonoBehaviour
{
	bool hit = false;
	void OnTriggerEnter(Collider other)
	{
        Debug.Log("Enter");
		hit = true;
        // if (other.gameObject.tag == "current")
        // {
            // Parser.lastCpPos = other.gameObject.transform.position; 
            // Destroy(other.gameObject);
			// Got = true;
			
			
        // }
        // if(other.gameObject.tag == "collision")
        // {
            // transform.parent.position = Parser.lastCpPos;
            // CountDown.timeLeft = 3.0f;
			// Crash = true;
			// //Vector3 relativePos = Parser.currentCpPos - transform.position;
			// //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
			// //transform.rotation = rotation;
        // }
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(hit)
		{
			print("get");
		}
		
        
    }
}
