using UnityEngine;
using System.Collections;

public class TimedLife : MonoBehaviour
{
    public float lifetime;
    float timeLeft;

	// Use this for initialization
	void Start()
    {
        timeLeft = lifetime;
	}
	
	// Update is called once per frame
	void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
