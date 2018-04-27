using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public static GM instance;
    public static int pressureNum=0;
    Animator doorAnim;
    float animTime = 0.0f;
    string animName = "ExitDoor";
    public float waitingTime=1.5f;
    bool isRightOrder = false;
    bool hasChecked = false;
    public List<GameObject> leverOrder = new List<GameObject>();
    public List<GameObject> selectedOrder = new List<GameObject>();



    private void Awake()
    {




        

        if (instance != null)
        {
            Destroy(gameObject);
//            Debug.Log("if instance: " + instance);
        }
        else
        {
            instance = this;

        } 

    }

    void Start () {
        doorAnim = GameObject.FindWithTag("ExitDoor").GetComponent<Animator>();

	}
	
    public void DoorOpen()
    {
        animTime = Mathf.Clamp01(doorAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        doorAnim.Play(animName, 0, animTime);

        doorAnim.SetFloat("direction", 1.0f);

    }
    public void DoorClose()
    {
        animTime = Mathf.Clamp01(doorAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        doorAnim.Play(animName, 0, animTime);
        doorAnim.SetFloat("direction", -1.0f);

    }

    public IEnumerator DoorDelay()
    {
        yield return new WaitForSeconds(waitingTime);
        DoorOpen();
    }

    public void AddLever(GameObject newLever)
    {
        if (selectedOrder.Contains(newLever))
        {
            selectedOrder.Remove(newLever);
        }
        else
        {
            selectedOrder.Add(newLever);
        }
    }

    void CheckOrder()
    {
        isRightOrder = true;
        for (int i= 0; i< leverOrder.Count; i = i + 1)
        {
            if (leverOrder[i]!=selectedOrder[i])
            {
                isRightOrder = false;
            }
        }
        if (isRightOrder)
        {
            StartCoroutine(GetRightLeverOrder());
        }
        else
        {
            StartCoroutine(GetWrongLeverOrder());
        }
    }

    IEnumerator GetWrongLeverOrder()
    {
       
        yield return new WaitForSeconds(waitingTime);
        foreach (GameObject difLever in leverOrder)
        {
            Animator difLeverAnim = difLever.gameObject.GetComponent<Animator>();
            difLeverAnim.SetTrigger("draw");
        }
        selectedOrder.Clear();
        hasChecked = false;
    }

    IEnumerator GetRightLeverOrder()
    { 
        yield return new WaitForSeconds(waitingTime);
        DoorOpen();
    }

    void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("a");
            DoorOpen();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("d");
            DoorClose();
        }
        */




        if (!hasChecked)
        {
            if (leverOrder.Count==selectedOrder.Count)
            { Debug.Log(111111111111111);
                hasChecked = true;
                CheckOrder();
            }

        }
    }
}
