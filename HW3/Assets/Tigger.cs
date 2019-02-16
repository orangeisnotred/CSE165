using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tigger : MonoBehaviour
{
	public AudioClip SoundClip;
	public AudioSource SoundSource;
	public AudioClip CrashClip;
	public AudioSource CrashSource;
	bool Got = false;
	bool Crash = false;
	
	void OnTriggerEnter(Collider other)
	{
        Debug.Log("Enter");
        if (other.gameObject.tag == "current")
        {
            Parser.lastCpPos = other.gameObject.transform.position; 
            Destroy(other.gameObject);
			Got = true;
			
			
        }
        if(other.gameObject.tag == "collision")
        {
            transform.parent.position = Parser.lastCpPos;
            CountDown.timeLeft = 3.0f;
			Crash = true;
			//Vector3 relativePos = Parser.currentCpPos - transform.position;
			//Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
			//transform.rotation = rotation;
        }
	}
	
	void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stay");
    }
    // Start is called before the first frame update
    void Start()
    {
		SoundSource.clip = SoundClip;
		CrashSource.clip = CrashClip;
    }

    // Update is called once per frame
    void Update()
    {
		if(Got)
		{
			SoundSource.Play();
			Got = false;
		}
		if(Crash)
		{
			CrashSource.Play();
			Crash = false;
		}
        
    }
}
