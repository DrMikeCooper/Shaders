using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

    private Vector3[] points;
    private int nextPoint;
    public float speed = 0.01f;

    Material mat;

    // Use this for initialization
    void Start () {
        int num = Random.Range(3, 6);
        points = new Vector3[num];
        for (int i = 0; i < num; i++)
            points[i] = new Vector3(Random.Range(-80, 80), 0, Random.Range(-80, 80));
        nextPoint = 0;

        SkinnedMeshRenderer smr = GetComponentInChildren<SkinnedMeshRenderer>();
        mat = smr.material;
        int index = Random.Range(0, 15);
        mat.SetFloat("_ColorIndex", index);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 delta = points[nextPoint] - transform.position;
        if (delta.magnitude < 1)
        {
            nextPoint++;
            if (nextPoint == points.Length)
                nextPoint = 0;
        }

        transform.position = transform.position + delta.normalized * speed;
        float angle = (180.0f / Mathf.PI) * Mathf.Atan2(delta.x, delta.z);
        transform.eulerAngles = new Vector3(0, angle, 0);

        mat.SetFloat("_BHRadius", Blackhole.s_radius);
        mat.SetVector("_BHOrigin", Blackhole.s_origin);
	}
}
