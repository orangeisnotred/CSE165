using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseMode : MonoBehaviour
{
	GameObject RightHand;
	GameObject RightHandIndex;
	bool hit = false;
	int c = 1;
	GameObject ColliderObj;
	CapsuleCollider collider;
    // Start is called before the first frame update
	
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
	
    void Start()
    {
         RightHand = GameObject.Find("Right Interaction Hand Contact Bones");
		 RightHandIndex = RightHand.transform.GetChild(5).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
		RightHand = GameObject.Find("Right Interaction Hand Contact Bones");
		RightHandIndex = RightHand.transform.GetChild(5).gameObject;
		// if ((RightHandIndex!=null) & (c==1))
		// {
			// // GameObject prefab = Resources.Load("Collider") as GameObject;
			// // ColliderObj = Instantiate(prefab) as GameObject;
			// // ColliderObj.transform.parent = RightHandIndex.transform;
			// // ColliderObj.gameObject.GetComponent<SphereCollider>().size = new Vector3(0.1f, 0.1f, 0.1f);
			
			
			// collider = RightHandIndex.gameObject.GetComponent<CapsuleCollider>();

			// // collider.size = new Vector3(0.1f, 0.1f, 0.1f);
			// collider.isTrigger = true;
			// c = 0;
		// }
		
		
		
		
		if(hit)
		{
			print("get");
		}
		
		
		

        
    }
}
