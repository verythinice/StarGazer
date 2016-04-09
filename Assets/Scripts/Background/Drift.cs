using UnityEngine;
using System.Collections;

public class Drift : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
        float dt = Time.deltaTime;
        transform.Translate(speed * direction * dt);
	}
}
