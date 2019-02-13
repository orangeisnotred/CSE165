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

    GameObject CheckPoint;

    void Start()
    {
       
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
           
            using (StreamReader sr = new StreamReader("sample.txt.txt"))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
               
                while ((line = sr.ReadLine()) != null)
                {
                    //Debug.Log(line);


                    string[] coordStrings = line.Split(' ');
                    xPos = float.Parse(coordStrings[0]) * .0254f;
                    yPos = float.Parse(coordStrings[1]) * .0254f;
                    zPos = float.Parse(coordStrings[2]) * .0254f;
                   

                    GameObject prefab = Resources.Load("Sphere") as GameObject;
                    CheckPoint = Instantiate(prefab) as GameObject;
                    CheckPoint.transform.position = new Vector3(xPos, yPos, zPos);



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
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
