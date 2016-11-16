using UnityEngine;
using System.Collections;

public class VRCameraSimple : MonoBehaviour {

    public GameObject indicator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = transform.forward;
        fwd.y = 0;
        bool lookingDown = false;
        if (transform.eulerAngles.x > 10 && transform.eulerAngles.x < 25)
        {
            lookingDown = true;
            transform.parent.position = transform.parent.position + fwd * 0.3f;
        }

        float scale = lookingDown ? 0.5f : 1.0f;
        indicator.transform.localScale = new Vector3(scale, scale, scale);

        indicator.transform.rotation = transform.rotation;
	}
}
