using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    protected SpawnCondition condition;

    public virtual void Start()
    {
        condition = GetComponent<SpawnCondition>();
    }

    public virtual void Update()
    {
        if (condition.ShouldSpawn())
        {
            Spawn();
        }
    }

	// Use this for initialization
    public virtual void Spawn()
    {
        condition.OnSpawn((GameObject)GameObject.Instantiate(spawnPrefab, transform.position, transform.rotation));
	}
}
