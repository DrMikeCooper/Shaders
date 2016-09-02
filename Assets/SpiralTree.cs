using UnityEngine;
using System.Collections;

public class SpiralTree : MonoBehaviour {

    public GameObject temp;
    public Vector3 offset = new Vector3(0, 10, 0);
    Vector3 target;
    public bool rebuild = true;
    public int number = 33;
    public float fallIn = 0.3f;
    public float cap = 4.0f;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
        if (rebuild)
            Build();
	}

    void Build()
    {
        rebuild = false;
        for (int i=0; i<transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);

        target = transform.position + offset;
        Vector3 pos = transform.position;
        for (int i = 0; i < number; i++)
        {
            Vector3 towards = target - pos;
            towards.Normalize();
            Vector3 sideways = new Vector3(towards.y, -towards.x, towards.z);

            float side = i * fallIn;
            if (side > cap)
                side = cap;
            Vector3 delta = towards + side * sideways;
            delta.Normalize();
            pos = pos + delta;
            GameObject tmp = Instantiate(temp, pos, new Quaternion()) as GameObject;
            tmp.transform.parent = transform;
        }
    }

}
