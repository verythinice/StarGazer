using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed;
    public Vector3 axis;
    public KeyCode forward;
    public KeyCode backward;
    public Vector3 min;
    public Vector3 max;

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKey(forward))
        {
            transform.Translate(axis * speed);
        }

        if (Input.GetKey(backward))
        {
            transform.Translate(-axis * speed);
        }

        if (transform.localPosition.x <= min.x)
        {
            transform.localPosition = new Vector3(max.x, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x >= max.x)
        {
            transform.localPosition = new Vector3(min.x, transform.localPosition.y, transform.localPosition.z);
        }
	}
}
