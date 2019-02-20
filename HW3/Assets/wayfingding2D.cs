using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayfingding2D : MonoBehaviour
{
	GameObject airplane;
	GameObject[] nextCP;
	GameObject checkpoint;
	Vector3 playerForwardDir;
	Vector3 playerToNextCPDir;
	bool instantiatePoint = true;
	public float heightDiff;
	
	float distance;
	Vector3 PreviousPosition;
	float disForV;
	//private var gameObjects : GameObject[];
	
    // Start is called before the first frame update
    void Start()
    {
        // airplane = GameObject.Find("/Canvas/airplane");
		PreviousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {	
		Vector3 playerForwardDir = transform.TransformDirection( Vector3.forward);
		nextCP = GameObject.FindGameObjectsWithTag("current");  
		Vector3 playerToNextCPDir = nextCP[0].transform.position - transform.position;
		heightDiff = playerToNextCPDir.y;
		playerToNextCPDir.y = 0;
		playerForwardDir.y = 0;

		
		GameObject Base = GameObject.Find("/engineering-campus");

		Quaternion diff_gl = transform.rotation * Quaternion.Inverse(Base.transform.rotation);
		Vector3 localToCPDir = Quaternion.Inverse(diff_gl) * playerToNextCPDir;
		localToCPDir.y = 0;
		
		
		GameObject checkpoint = GameObject.Find("/WayFinding2/bg/checkpoint");
		float normalilze = Mathf.Sqrt(localToCPDir.x*localToCPDir.x+localToCPDir.z*localToCPDir.z);
		checkpoint.transform.localPosition = new Vector3(localToCPDir.x/normalilze*45f,localToCPDir.z/normalilze*45f,0);
		
		distance = Vector3.Distance(nextCP[0].transform.position,transform.position);
		Debug.Log(distance);
		if (distance >170)
		{
			checkpoint.transform.localPosition = new Vector3(localToCPDir.x/normalilze*45f,localToCPDir.z/normalilze*45f,0);
		}	
		else
		{
			checkpoint.transform.localPosition = new Vector3(localToCPDir.x/normalilze*45f/170*distance,localToCPDir.z/normalilze*45f/170*distance,0);
		}
		
		
		disForV = Vector3.Distance(transform.position,PreviousPosition);
		Debug.Log("THHHHHHIS: "+disForV);
		GetComponent<AudioSource>().pitch = 0.1f + disForV*0.5f;
		PreviousPosition = transform.position;
		
		
		//nextCP = GameObject.Find("/checkpoint"+(lineCount-2).ToString());
		// if (instantiatePoint)
		// {
			// GameObject prefab1 = Resources.Load("checkpoint") as GameObject;
			// //checkpoint = Instantiate(prefab1) as GameObject;
			// GameObject enemy = GameObject.Instantiate(prefab1, Vector3.zero, Quaternion.identity) as GameObject;
			// //Debug.Log(enemy);
			// GameObject WayFinding2 = GameObject.Find("/WayFinding2");
			// enemy.transform.parent = WayFinding2.transform;
			// //enemy.transform.SetParent("WayFinding2");
			// //gameObjects = FindObjectsOfType(GameObject) as GameObject[];
			// instantiatePoint = false;
		// }
			
		

		
    
	    // for (int i=0; i < gameObjects.length; i++)
		// {
			// if(gameObjects[i].name.Contains("checkpoint"))
			// {
				// Debug.Log(gameObjects[i] + "  : " + i);
			// }
		// }
		
    }
}
