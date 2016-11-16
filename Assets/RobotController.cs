using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {

    public GameObject proto;
    public int number = 10;

	// Use this for initialization
	void Start () {
	    for (int i=0; i<number; i++)
        {
            GameObject obj = Instantiate<GameObject>(proto);
            obj.transform.position = new Vector3(Random.Range(-40, 40), 0, Random.Range(-40, 40));
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
