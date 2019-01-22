using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Raycasttest : MonoBehaviour {
    public Camera cam;
    public GameObject brick = null;
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

    public Image loading;
    public Image loadingdimmed;
    public float filltime = 2.0f;
    float movetime;
    float locktime;
    float explosiontime;//rm later
    int explosioncounter = 0;
    int groundcounter = 0;

    float temphead;
    public float force;
    bool locked = false;
   
    // Use this for initialization
    int x = 3;
    float r;
    float k;
    void Start () {
        loading.fillAmount = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {


        RaycastHit hit = new RaycastHit();
       
      
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.yellow);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 10, out hit, 5000))
        {

            if (hit.transform.tag == "brick")
            {
                loading.fillAmount += 1.0f / filltime * Time.deltaTime;
                rend = hit.collider.gameObject.GetComponent<Renderer>();
                original = rend.material.color;
                if (!locked)
                    rend.material.color = Color.green;



                if (brick != hit.transform.gameObject && !locked) //&& !locked) //if new brick is looked at and not locked
                {
                    loading.fillAmount = 0.0f;
                    if (brick != null)
                        brick.GetComponent<Renderer>().material.color = original;

                    brick = hit.transform.gameObject;
                    //currentBrick = hit.transform;

                    locktime = Time.time;
                    explosiontime = Time.time;
                    // Debug.Log("new brick" + temptime);


                }

                if (Time.time - locktime < 2 && !locked)
                {

                    //wall = currentBrick.position;
                    //wall.y = transform.postion.y;
                    //initialDistance = transform.position - wall;

                    currHeadPostion = transform.position;
                }



                if (Time.time - locktime >= 2)// || locked) //if looking at the same brick for 3 seconds
                {
                    locked = true;
                    loading.enabled = false;
                    loadingdimmed.enabled = false;
                    if (locked)
                    {
                        brick.GetComponent<Renderer>().material.color = Color.blue;


                        k = Vector3.Distance(hit.transform.position, brick.transform.position) / Vector3.Distance(brick.transform.position, transform.position);
                        if (k <= 0.23)
                        {
                            float Rad = Mathf.Atan(brick.transform.position.x / brick.transform.position.z);
                            float distance = Vector3.Distance(currHeadPostion, transform.position);
                            Debug.Log("currHeadPostion" + currHeadPostion);
                            Debug.Log("transform.position" + transform.position);
                            Debug.Log("distance.position" + distance);
                            r = Mathf.Sqrt(brick.transform.position.x * brick.transform.position.x + brick.transform.position.z * brick.transform.position.z);
                            if (distance >= 0.03)
                            {
                                explosioncounter = 0;
                                if (Vector3.Distance(currHeadPostion, brick.transform.position) > Vector3.Distance(transform.position, brick.transform.position))
                                {
                                    brick.transform.position = new Vector3((r + distance * 0.5f) * Mathf.Sin(Rad), brick.transform.position.y, (r + distance * 0.5f) * Mathf.Cos(Rad));
                                }
                                if (Vector3.Distance(currHeadPostion, brick.transform.position) < Vector3.Distance(transform.position, brick.transform.position))
                                {
                                    brick.transform.position = new Vector3((r - distance * 0.5f) * Mathf.Sin(Rad), brick.transform.position.y, (r - distance * 0.5f) * Mathf.Cos(Rad));
                                }
                            }

                            else
                            {
                                explosioncounter++;
                                if (explosioncounter == 420)
                                {
                                    brick.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, force), ForceMode.Impulse);
                                }
                            }

                        }

                        if (k > 0.23)
                        {
                            locked = false;
                            loading.enabled = true;
                            loadingdimmed.enabled = true;
                        }

                    }
                    //Vector3 newDistance = transform.position - wall;
                    //Vector3 centerWall = new Vector3(0, hit.transform.y, 0);
                    //Vector3 radialVector = hit.transform.position - centerWall;




                    //Debug.Log("currHeadPostion" + currHeadPostion);
                    //Debug.Log("HeadPostion" + transform.position);
                    //Debug.Log("distance" + distance);

                    //if (newDistance < intialDistance)
                    //{
                    //    hit.tranform.position =  
                    //}


                    //rend = hit.collider.gameObject.GetComponent<Renderer>();
                    //original = rend.material.color;

                    //hit.transform.position = new Vector3(currHead.x, currHead.y, currHead.z);






                }



                //hit.transform.position = new Vector3(2, x, 0);
                //x++;


            }

            if (hit.transform.tag == "Sky")
            {
                Debug.Log("sky was looked at");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }


            if (hit.transform.tag == "ground")
            {
                float tempY = transform.parent.transform.position.y;
                groundcounter++;
                if (groundcounter == 120)
                {
                    Vector3 pos = hit.point;
                    pos.y = tempY;
                    transform.parent.transform.position = pos;
                    groundcounter = 0;
                   
                    


                }


            }
            else
            {
                groundcounter = 0;
            }
        }
    }

    
}
