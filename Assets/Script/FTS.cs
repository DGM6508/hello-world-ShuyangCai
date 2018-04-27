using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTS : MonoBehaviour {

    public string playerTag;
    // Use this for initialization

    private void Awake()
    {
        Screen.lockCursor = true;

        Cursor.visible = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        //       Debug.Log("enter");
        if (other.gameObject.CompareTag(playerTag))
        {
            Application.LoadLevel("SecondRoomScene");
        }

    }
}
