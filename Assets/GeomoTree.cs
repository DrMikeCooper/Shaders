using UnityEngine;
using System.Collections;

[System.Serializable]
public class Shape : System.Object
{
    public Color color;
};

public class GeomoTree : MonoBehaviour {


    [System.Serializable]

    public class Rect : Shape
    {
        float width;
        float height;
    };

    [System.Serializable]

    public class Circle : Shape
    {
        public float radius;
    };

    public Shape[] shapes;
	// Use this for initialization
	void Start () {
        shapes = new Shape[2];
        shapes[0] = new Rect();
        shapes[1] = new Circle();
 	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
