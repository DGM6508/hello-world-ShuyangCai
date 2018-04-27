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

    ParticleSystem particle;
    public GameObject teleportermom;


    void Awake () {
        plateAnim = GetComponent<Animator>();
        particle = teleporter.GetComponent<ParticleSystem>();

        particle.Stop();
        teleportermom.SetActive(false);
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

                teleportermom.SetActive(true);
                particle.Play();



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
