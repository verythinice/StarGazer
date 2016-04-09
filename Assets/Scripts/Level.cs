using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    public float gameTime;
    public GameObject[] spawn;
    public float[] yPos;
    public float[] spawnTime;
    public int nextSpawn;
    public float minX;
    public float maxX;

	// Use this for initialization
	void Start()
    {
        gameTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update()
    {
        gameTime += Time.deltaTime;
        while (nextSpawn < spawnTime.Length && gameTime >= spawnTime[nextSpawn])
        {
            GameObject.Instantiate(spawn[nextSpawn], new Vector3(Random.Range(minX, maxX), yPos[nextSpawn], 0), Quaternion.identity);
            nextSpawn++;
        }
	}
}
