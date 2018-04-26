using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSpe : MonoBehaviour
{

    bool isPlayerComing = false;
    public string playerTag;
    Animator leverAnim;
    public bool aMultoLever = false;
    public GameObject aT1, aT2, aT3;

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
    void Awake()
    {
        leverAnim = gameObject.GetComponent<Animator>();
        aT1.SetActive(false);
        aT2.SetActive(false);
        aT3.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerComing)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                leverAnim.SetTrigger("draw");
                if (aMultoLever)
                {
                    GM.instance.AddLever(gameObject);
                    Debug.Log("this: " + this);
                    Debug.Log(this.gameObject);
                }
                else
                {
                    aT1.SetActive(true);
                    aT2.SetActive(true);
                    aT3.SetActive(true);
                    StartCoroutine(GM.instance.DoorDelay());

                }

            }
        }
    }
}
