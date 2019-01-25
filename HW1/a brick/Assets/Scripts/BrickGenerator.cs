using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour {


	// Use this for initialization
	void Start () {
        GameObject prefab = Resources.Load("brick") as GameObject;
        GameObject prefab2 = Resources.Load("brick2") as GameObject;
        GameObject prefab3 = Resources.Load("brick3") as GameObject;


        float num = 60;
        for (int i = 0; i < num; i++){
            for (int height = 0; height < 30; height++){
                GameObject brick;
                if (i*height%3 == 0)
                {
                    brick = Instantiate(prefab) as GameObject;
                }
                else if(i * height % 3 == 1)
                {
                    brick = Instantiate(prefab2) as GameObject;
                }
                else
                {
                    brick = Instantiate(prefab3) as GameObject;
                }


                int offset = height % 2;
                float r = 3;
                if(offset == 0)
                {
                    float x = Mathf.Sin(i * 360 / num * Mathf.Deg2Rad) * r;
                    float z = Mathf.Cos(i * 360 / num * Mathf.Deg2Rad) * r;
                    brick.transform.position = new Vector3(x, (float)(height * 0.15), z);
                    brick.transform.Rotate(new Vector3(0, i * 360 / num, 0));
                }
                if(offset == 1)
                {
                    float x = Mathf.Sin((i * 360 / num + 360 / num / 2) * Mathf.Deg2Rad) * r;
                    float z = Mathf.Cos((i * 360 / num + 360 / num / 2) * Mathf.Deg2Rad) * r;
                    brick.transform.position = new Vector3(x,(float)(height*0.15),z);
                    brick.transform.Rotate(new Vector3(0, (i * 360 / num + 360 / num / 2), 0));
                }


            }

        }



    }
	
	// Update is called once per frame
    /*
	void Update () {
		
	}
	*/

}
