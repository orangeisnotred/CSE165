using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tigger : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
        Debug.Log("Enter");
        if (other.gameObject.tag == "current")
        {
            Parser.lastCpPos = other.gameObject.transform.position; 
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "collision")
        {
            transform.parent.position = Parser.lastCpPos;
            CountDown.timeLeft = 3.0f;
        }
	}
	
	void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stay");
    }
    // Start is called before the first frame update
    void Start()
    {
		Collider m_ObjectCollider = GetComponent<Collider>();
        Debug.Log("Trigger: "+ m_ObjectCollider.isTrigger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
