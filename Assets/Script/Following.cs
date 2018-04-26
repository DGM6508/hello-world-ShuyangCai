using UnityEngine;
using System.Collections;

public class Following : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {

        offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        Vector3 Pos = transform.position + offset;

        target.position = Pos;

       transform.localEulerAngles = new Vector3(0f, target.transform.localEulerAngles.y,0f);


    }
}