using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    Animator plateAnim;
    public string pressThingTag;
    public float waitingTime;
    public bool needWeight;
    public GameObject teleporter;

    bool intrigger = true;



    void Start () {
        plateAnim = GetComponent<Animator>();
	}

    private void OnTriggerEnter(Collider other)
    {

        if (intrigger && other.gameObject.CompareTag(pressThingTag))
        {
            intrigger = false;
            plateAnim.SetTrigger("press");
            GM.pressureNum = GM.pressureNum + 1;
            Debug.Log(GM.pressureNum);

            if (GM.pressureNum == 2)
            {
                StartCoroutine(WaitingForOpen());

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( !intrigger && needWeight && other.gameObject.CompareTag(pressThingTag))
        {
            intrigger = true;
            plateAnim.SetTrigger("press");
           GM.pressureNum = GM.pressureNum -1;
            Debug.Log("exit"+GM.pressureNum);
            
            if (GM.pressureNum < 2)
            {
                GM.instance.DoorClose();
                
            }
            
        }
    }

    IEnumerator WaitingForOpen()
    {
        yield return new WaitForSeconds(waitingTime);
        GM.instance.DoorOpen();
    }

}
