using UnityEngine;
using System.Collections;

public class MouseFollower : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        bool touch = false;
        Vector3 mousepos = new Vector3(0,0,0);

#if MOBILE_INPUT
        if (Input.touchCount > 0)
        {
            touch = true;
            mousepos = Input.GetTouch(0).position;
        }
#else
        if (Input.GetMouseButton(0))
        {
            touch = true;
            mousepos = Input.mousePosition;
        }
#endif
        if (!touch)
            return;

        Ray ray = Camera.main.ScreenPointToRay(mousepos);
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray, out hitInfo))
        {
            transform.position = hitInfo.point;
        }
    }
}
