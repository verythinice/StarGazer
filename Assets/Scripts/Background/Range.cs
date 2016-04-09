using UnityEngine;
using System.Collections;

public class Range : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 resetDistance;

	// Use this for initialization
	void Start()
    {
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        Vector3 newPosition = transform.position;
        if (transform.position.x - startPosition.x > resetDistance.x)
        {
            newPosition.x -= resetDistance.x;
        }

        if (transform.position.x - startPosition.x < -resetDistance.x)
        {
            newPosition.x += resetDistance.x;
        }

        if (transform.position.y - startPosition.y > resetDistance.y)
        {
            newPosition.y -= resetDistance.y;
        }

        if (transform.position.y - startPosition.y < -resetDistance.y)
        {
            newPosition.y += resetDistance.y;
        }

        if (transform.position.z - startPosition.z > resetDistance.z)
        {
            newPosition.z -= resetDistance.z;
        }

        if (transform.position.z - startPosition.z < -resetDistance.z)
        {
            newPosition.z += resetDistance.z;
        }
        this.transform.position = newPosition;
	}
}
