using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTH : MonoBehaviour
{

    public string playerTag;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        //       Debug.Log("enter");
        if (other.gameObject.CompareTag(playerTag))
        {
            Application.LoadLevel("HEScence");
        }

    }
}
