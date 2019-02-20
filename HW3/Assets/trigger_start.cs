using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trigger_start : MonoBehaviour
{

	
	void OnTriggerEnter(Collider other)
	{
        Debug.Log("Enter");
        if (other.gameObject.tag == "normalPlayMode")
        {
            
           
			SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
			
			
        }
        else if(other.gameObject.tag == "hearingPlayMode")
        {
			Debug.Log(other.gameObject.tag);
			SceneManager.LoadScene("hearingMode", LoadSceneMode.Single);
        }
		
		
		
		
	}
	void OnTriggerStay(Collider other)
	{
        Debug.Log("Stay");
        if (other.gameObject.tag == "normalPlayMode")
        {
            
           
			SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
			
			
        }
        else if(other.gameObject.tag == "hearingPlayMode")
        {
			Debug.Log(other.gameObject.tag);
			SceneManager.LoadScene("hearingMode", LoadSceneMode.Single);
        }
		
		
		
		
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
