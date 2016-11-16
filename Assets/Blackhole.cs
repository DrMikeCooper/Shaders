using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour {

    public static Vector3 s_origin;
    public static float s_radius;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // orbit
        float angle = 0.2f * Time.time;
        transform.position = new Vector3(30 * Mathf.Sin(angle), 0, 30 * Mathf.Cos(angle));
        s_origin = transform.position;
        s_radius = 100.0f * transform.localScale.x;
	}
}
