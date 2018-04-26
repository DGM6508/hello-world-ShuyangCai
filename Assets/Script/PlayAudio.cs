using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour {

    public void PlayAudioEffect(AudioClip assetAudio)
    {
        AudioSource assetAudioSource = GetComponent<AudioSource>();
        assetAudioSource.clip = assetAudio;
        assetAudioSource.Play();
    }

}
