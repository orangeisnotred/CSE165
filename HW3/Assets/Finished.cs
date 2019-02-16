using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
	public AudioClip SoundClip;
	public AudioSource SoundSource;
    // Start is called before the first frame update
    void Start()
    {

        SoundSource.clip = SoundClip;
		SoundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

			

    }
}
