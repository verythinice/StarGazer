using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed;
    public Vector3 axis;
    public KeyCode forward;
    public KeyCode backward;

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
	}
}
