using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    bool isPlayerComing = false;
    public string playerTag;
    Animator leverAnim;
    public bool aMultoLever = false;

    private void OnTriggerEnter(Collider other)
    {
 //       Debug.Log("enter");
        if (other.gameObject.CompareTag(playerTag))
        {
            isPlayerComing = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
 //       Debug.Log("exit");
        if (other.gameObject.CompareTag(playerTag))
        {
            isPlayerComing = false;
        }
        
    }
    void Start () {
        leverAnim = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerComing)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                leverAnim.SetTrigger("draw");
                if (aMultoLever)
                {
                    GM.instance.AddLever(gameObject);
                    Debug.Log("this: "+this);
                    Debug.Log(this.gameObject);
                }
                else
                {
                    StartCoroutine(GM.instance.DoorDelay());
                }
                
            }
        }
	}
}
