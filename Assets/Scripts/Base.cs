using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{
    Tiling background;

	// Use this for initialization
	void Start()
    {
        background = GameObject.FindWithTag("background").GetComponent<Tiling>();
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}
}
