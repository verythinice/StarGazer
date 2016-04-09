﻿using UnityEngine;
using System.Collections;

public class Level : Base
{
    public float gameTime;
    public GameObject[] spawn;
    public float[] yPos;
    public float[] depth;
    public int nextSpawn;
    public float minX;
    public float maxX;

	// Use this for initialization
	public override void Start()
    {
        base.Start();
        gameTime = 0.0f;
	}
	
	// Update is called once per frame
	public override void Update()
    {
        base.Update();
        gameTime += Time.deltaTime;
        while (nextSpawn < depth.Length && background.distance >= depth[nextSpawn])
        {
            GameObject.Instantiate(spawn[nextSpawn], new Vector3(Random.Range(minX, maxX), yPos[nextSpawn], 0), Quaternion.identity);
            nextSpawn++;
        }
	}
}