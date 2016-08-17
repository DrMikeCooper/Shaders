using UnityEngine;
using System.Collections;

public class FlyCamera : MonoBehaviour
{
    Vector3 m_mousePos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * Input.GetAxis("Vertical");
        transform.position = transform.position + transform.up * 10.0f * Input.GetAxis("Mouse ScrollWheel");
        transform.position = transform.position + transform.right * Input.GetAxis("Horizontal");
        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - m_mousePos;
            Vector3 rot = transform.eulerAngles;
            if (delta.x !=0)
                rot.y += delta.x;
            if (delta.y != 0)
                rot.x -= delta.y;
            transform.eulerAngles = rot;
        }
        m_mousePos = Input.mousePosition;


    }
}