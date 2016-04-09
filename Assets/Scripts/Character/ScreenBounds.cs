using UnityEngine;
using System.Collections;

public class ScreenBounds : MonoBehaviour
{
    public Vector2 center;
    public Vector2 bounds;

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
        Vector3 newPosition = transform.position;
        if (transform.position.x > center.x + bounds.x)
        {
            newPosition.x = center.x - bounds.x;
        }

        if (transform.position.x < center.x - bounds.x)
        {
            newPosition.x = center.x + bounds.x;
        }

        if (transform.position.y > center.y + bounds.y)
        {
            newPosition.y = center.y - bounds.y;
        }

        if (transform.position.y < center.y - bounds.y)
        {
            newPosition.y = center.y + bounds.y;
        }
        transform.position = newPosition;
	}
}
