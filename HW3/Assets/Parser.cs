using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class Parser : MonoBehaviour
{
    // Start is called before the first frame update
    float xPos;
    float yPos;
    float zPos;
	int lineCount;
	
	bool Got = false;
	float t;
	GameObject gotIt;
	GameObject canvas;
	GameObject Finish;
	public static Quaternion initrotation;
	public static Quaternion rot;

    public static Vector3 lastCpPos;
	public static Vector3 currentCpPos;
	GameObject nextCP;
	
	Vector3[] checkPoints;
	public Vector3[] newcheckPoints;
    GameObject CheckPoint;
	private LineRenderer laserLine;
	
	public static bool Finished=false;
	public static bool Stop=false;
	
	

    void Start()
    {	
		/// the files are in HW3 folder. One level up than Assert
		lineCount = File.ReadAllLines("sample_short.txt").Length;
		//Debug.Log(lineCount);
		checkPoints = new Vector3[lineCount];
		laserLine = GetComponent<LineRenderer>();
		//Debug.Log(lineCount);
        try
        {
            using (StreamReader sr = new StreamReader("sample_short.txt"))
            {
                string line;
				int i = lineCount -1;
                while ((line = sr.ReadLine()) != null)
                {



                    string[] coordStrings = line.Split(' ');
                    xPos = float.Parse(coordStrings[0]) * .0254f;
                    yPos = float.Parse(coordStrings[1]) * .0254f;
                    zPos = float.Parse(coordStrings[2]) * .0254f;

                    if (i != lineCount - 1)
                    {
                        GameObject prefab = Resources.Load("Sphere") as GameObject;
                        CheckPoint = Instantiate(prefab) as GameObject;

                        CheckPoint.transform.position = new Vector3(xPos, yPos, zPos);



                        CheckPoint.name = "checkpoint" + i.ToString();
                        CheckPoint.tag = "checkpoint";
                    }

                    if (i == lineCount -1)
                    {
                        lastCpPos = new Vector3(xPos, yPos, zPos);
                        //CheckPoint.tag = "current";
                    }
                    
					
					checkPoints[i] = new Vector3(xPos,yPos,zPos);
					i -= 1;
					


                    //Console.WriteLine(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
		

		transform.position = checkPoints[lineCount - 1];
		
		
		////////////////////// Look
		// // Vector3 relativePos = checkPoints[lineCount - 2] - transform.position;

        // // // the second argument, upwards, defaults to Vector3.up
        // // initrotation = Quaternion.LookRotation(relativePos, Vector3.up);
		// // GameObject gameObject = GameObject.Find("/Leap Rig/Main Camera");
        // // transform.rotation = initrotation;
		// // //rot = initrotation * Quaternion.Inverse(gameObject.transform.rotation);
		
		
		
		checkPoints[lineCount - 1].y =  transform.position.y - 1.2f;

		
		laserLine.positionCount = lineCount;
		
		


    }

    // Update is called once per frame
    void Update()
    {
		
		
		//if(Mathf.Abs(pitch_now - pitch_pre)>
		
		//Debug.Log(transform.rotation);
		/////////////////////////////// WayFinding one//////////////////////////
		nextCP = GameObject.Find("/checkpoint"+(lineCount-2).ToString());
        //currentCpPos = nextCP.transform.position;
		//Debug.Log("lineCount: "+lineCount);
		if(!Finished)
		{
			if (nextCP == null)
			{
				///Debug.Log("Deleted: Sphere"+(lineCount-2).ToString());
				lineCount = lineCount - 1;	
				canvas = GameObject.Find("/Leap Rig/Main Camera/Canvas");
				if(GameObject.Find("/checkpoint0") != null)
				{
					GameObject prefab = Resources.Load("Got") as GameObject;
					gotIt = Instantiate(prefab) as GameObject;
					gotIt.transform.SetParent(canvas.transform);
					gotIt.transform.localPosition = new Vector3(0,50,0);
					gotIt.transform.localRotation = new Quaternion(0,0,0,1);
					gotIt.transform.localScale = new Vector3(1,1,1);
					t = Time.time;
				}
				

			}
			else
			{
				nextCP.tag = "current";
				//Debug.Log("Existed: Sphere"+(lineCount-2).ToString());
				
				if(Time.time - t > 2)
				{
					Destroy(gotIt);
				}
			}
			Vector3[] newcheckPoints = new Vector3[lineCount];
			//newcheckPoints.RemoveAt(lineCount); 
			for(int i = 0; i<lineCount; i++)
			{
				newcheckPoints[i] = checkPoints[i];
			}
			//playerCollider.Center = transform.position;
			//Debug.Log("Trigger: "+ playerCollider.isTrigger);
			checkPoints[lineCount - 1] = transform.position;
			checkPoints[lineCount - 1].y =  transform.position.y - 1.2f;
			laserLine.positionCount = lineCount;
			laserLine.SetPositions(newcheckPoints);
		}
		
		///Debug.Log("LEgh: "+newcheckPoints.Length);
		/////////////////////////////// WayFinding one//////////////////////////
		
		
		
		
		if (GameObject.Find("/checkpoint0") == null)
		{
			Finished = true;
			Stop = true;
		}
		if(Finished && Stop)
		{
			GameObject prefab = Resources.Load("Finished") as GameObject;
			Finish = Instantiate(prefab) as GameObject;
			Finish.transform.SetParent(canvas.transform);
			Finish.transform.localPosition = new Vector3(0,50,0);
			Finish.transform.localRotation = new Quaternion(0,0,0,1);
			Finish.transform.localScale = new Vector3(1,1,1);
			//Finish.transform.GetComponent<Text>().text = "Finished!!! \n"+"Time: "+ CountDown.timer;
			//FinishSource.Play();
			Finished = false;
		}
			
    }

}
