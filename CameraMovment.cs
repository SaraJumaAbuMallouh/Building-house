using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public Transform targit;
    public float speed;

    private void Update()
    {
        Quaternion m_Targit = Quaternion.LookRotation(targit.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, m_Targit, speed * Time.deltaTime);
        //transform.LookAt(targit.position);
    }
}
