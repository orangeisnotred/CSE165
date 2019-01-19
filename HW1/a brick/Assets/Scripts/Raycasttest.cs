using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasttest : MonoBehaviour {
    public Camera cam;
    public GameObject cube;
    public float distanceToSee;
    public string ObjectName;
    private Color highlightColor;
    Material originalMaterial, tempMaterial;
    Renderer rend = null;
    Color original;
    Transform currentBrick;
    Transform wall; //relation between head and wall
    Vector3 initialDistance;
    Vector3 currHeadPostion;
    float temptime;
    float temphead;
    bool locked = false;
    // Use this for initialization
    int x = 3;
    float r = 3;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit = new RaycastHit();
        Renderer currRend;
      
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.yellow);

        if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward) * 10, out hit, 5000))
        {
            if (hit.transform.tag == "brick")
            {
                
                
            


                if (currentBrick != hit.transform) //&& !locked) //if new brick is looked at and not locked
                {
                    
                    currentBrick = hit.transform;
                    temptime = Time.time;
                   // Debug.Log("new brick" + temptime);
                    
                
                }
                if (Time.time - temptime < 2)
                {
                    //wall = currentBrick.position;
                    //wall.y = transform.postion.y;
                    //initialDistance = transform.position - wall;
                    
                    currHeadPostion = transform.position;
                }


                
                if (Time.time - temptime >= 2)// || locked) //if looking at the same brick for 3 seconds
                {
                    //Vector3 newDistance = transform.position - wall;
                    //Vector3 centerWall = new Vector3(0, hit.transform.y, 0);
                    //Vector3 radialVector = hit.transform.position - centerWall;

                    float Rad = Mathf.Atan(hit.transform.position.x / hit.transform.position.z);
                    
                    float distance = Vector3.Distance(currHeadPostion, transform.position);
                    Debug.Log("currHeadPostion" + currHeadPostion);
                    Debug.Log("HeadPostion" + transform.position);
                    Debug.Log("distance" + distance);
                    if (Vector3.Distance(currHeadPostion, hit.transform.position) > Vector3.Distance(transform.position, hit.transform.position))
                    {
                        hit.transform.position = new Vector3((r + distance * 3) * Mathf.Sin(Rad), hit.transform.position.y, (r + distance * 3) * Mathf.Cos(Rad));
                    }
                    if (Vector3.Distance(currHeadPostion, hit.transform.position) < Vector3.Distance(transform.position, hit.transform.position))
                    {
                        hit.transform.position = new Vector3((r - distance * 3) * Mathf.Sin(Rad), hit.transform.position.y, (r - distance * 3) * Mathf.Cos(Rad));
                    }
                    //if (newDistance < intialDistance)
                    //{
                    //    hit.tranform.position =  
                    //}

                    locked = true;
                    rend = hit.collider.gameObject.GetComponent<Renderer>();
                    original = rend.material.color;
                    rend.material.color = Color.green;
                    //hit.transform.position = new Vector3(currHead.x, currHead.y, currHead.z);
                    
                    


                    

                }

               

                //hit.transform.position = new Vector3(2, x, 0);
                //x++;
               
               
            }
           
        }

    }

    
}
