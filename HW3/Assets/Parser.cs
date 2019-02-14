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
	GameObject nextCP;
	
	Vector3[] checkPoints;
	public Vector3[] newcheckPoints;
    GameObject CheckPoint;
	private LineRenderer laserLine;
	
	bool Finished=false;

    void Start()
    {	
		
		lineCount = File.ReadAllLines("sample.txt.txt").Length;
		checkPoints = new Vector3[lineCount];
		laserLine = GetComponent<LineRenderer>();
		//Debug.Log(lineCount);
        try
        {
            using (StreamReader sr = new StreamReader("sample.txt.txt"))
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

		checkPoints[lineCount - 1].y =  transform.position.y - 1.2f;
		
		laserLine.positionCount = lineCount;


    }

    // Update is called once per frame
    void Update()
    {
		/////////////////////////////// WayFinding one//////////////////////////
		nextCP = GameObject.Find("/checkpoint"+(lineCount-2).ToString());
		//Debug.Log("lineCount: "+lineCount);
		if (nextCP == null)
		{
			///Debug.Log("Deleted: Sphere"+(lineCount-2).ToString());
			lineCount = lineCount - 1;	
		}
		else
		{
			//Debug.Log("Existed: Sphere"+(lineCount-2).ToString());
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
		///Debug.Log("LEgh: "+newcheckPoints.Length);
		/////////////////////////////// WayFinding one//////////////////////////
		
		
		
		
		if (GameObject.Find("/checkpoint0") == null)
			Finished = true;
    }

}
