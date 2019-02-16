using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointGot : MonoBehaviour
{
	public AudioClip SoundClip;
	public AudioSource SoundSource;
    // Start is called before the first frame update
    void Start()
    {
        SoundSource.clip = SoundClip;
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log( (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)));
        if (!OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
		{
			Debug.Log("un");
			SoundSource.Play();
			Debug.Log("unity");
		}
    }
}
