using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tigger : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Enter");
		Destroy(other.gameObject);
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
