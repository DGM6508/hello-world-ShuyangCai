using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class MovingSound : MonoBehaviour {

    Rigidbody rb;
    AudioSource aSource;
    public AudioClip movingSound;

	void Start () {
        rb = GetComponent <Rigidbody> ();
        aSource=GetComponent<AudioSource>();
        aSource.clip = movingSound;
	}
	
	void Update () {
//        Debug.Log(rb.velocity.magnitude);
		if (rb.velocity.magnitude>0.00001f && !aSource.isPlaying)
        {
            aSource.Play();
        }

    }
}
