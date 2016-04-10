using UnityEngine;
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
    public float maxDistance;
    public float playerHealth;
    public int nextLevel;
    public float extraEndLevelDelay;

    public void Awake()
    {
        if (playerHealth == 0)
        {
            playerHealth = 200;
        }

        GameObject.FindWithTag("Background").GetComponent<Tiling>().maxDistance = maxDistance;
        GameObject.FindWithTag("Background").GetComponent<Tiling>().nextLevel = nextLevel;
        GameObject.FindWithTag("Background").GetComponent<Tiling>().extraEndLevelDelay = extraEndLevelDelay;
        GameObject.FindWithTag("Player").GetComponent<Player>().maxHealth = playerHealth;
    }

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
