using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TeleporterCon : MonoBehaviour {

    public AudioClip teleportArr;
    public AudioClip teleportDep;
    AudioSource teleportSound;
    public GameObject teleporterDes;
    public float teleporterTime;
    ParticleSystem particle;
    void Awake () {
        //    teleporterDes.GetComponent<ParticleSystem>().Play();
        particle = teleporterDes.GetComponent<ParticleSystem>();
        teleportSound = GetComponent<AudioSource>();
        particle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        //  teleporterDes.GetComponent<ParticleSystem>().Play();
        particle.Play();
        StartCoroutine(Teleporter(other.gameObject));
        teleportSound.clip = teleportDep;
        teleportSound.Play();
    }
    
    IEnumerator Teleporter(GameObject teleporter)
    {
        teleporter.SetActive(false);
        yield return new WaitForSeconds(teleporterTime);
        teleporter.transform.position = teleporterDes.transform.position;
        teleportSound.clip = teleportArr;
        teleportSound.Play();
        teleporter.SetActive(true);
        particle.Stop();
    }
    void Update () {
		
	}
}
