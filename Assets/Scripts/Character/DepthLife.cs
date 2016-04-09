using UnityEngine;
using System.Collections;

public class DepthLife : Base
{
    public float startDepth;
    public float depthAlive = 12.0f;

	// Use this for initialization
	public override void Start()
    {
        base.Start();
        startDepth = background.distance;
	}
	
	// Update is called once per frame
	public override void Update()
    {
        base.Update();

	    if (background.distance - startDepth > depthAlive)
        {
            Destroy(gameObject);
        }
	}
}
