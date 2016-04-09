using UnityEngine;
using System.Collections;

public class SpawnCondition : MonoBehaviour {

    public virtual bool ShouldSpawn()
    {
        return false;
    }

    public virtual void OnSpawn(GameObject spawnedObject)
    {

    }
}
