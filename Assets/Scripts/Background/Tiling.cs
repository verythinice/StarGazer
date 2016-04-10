using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tiling : Base
{
    public Sprite[] tileTypes;
    public GameObject tile;
    public float tileSize;
    public float[] tileFrequencies;
    public int sizeX;
    public int sizeY;

    public Vector3 center;

    public float speed;
    public float turboSpeedMultiplier;
    public float brakesMultiplier;

    public KeyCode turboButton;
    public KeyCode brakeButton;

    public float turbo;
    public float brakes;
    public float currentSpeed;

    public List<Drift> floatingObjects;

    public float distance;

    List<List<GameObject>> tiles;
    int bottomY;
    int bottomIndex;

    public float maxDistance;
    public bool levelComplete;
    public int nextLevel;
    public float extraEndLevelDelay;

	// Use this for initialization
	public override void Start()
    {
        base.Start();
        currentSpeed = speed;
        turbo = 50000.0f;
        brakes = 50000.0f;
        distance = 0;

        tiles = new List<List<GameObject>>(sizeX);
        for (int i = 0; i < sizeX; ++i)
        {
            tiles.Add(new List<GameObject>(sizeY));
        }

        for (int i = 0; i < sizeX; ++i)
        {
            for (int j = 0; j < sizeY; ++j)
            {
                Vector3 position = new Vector3(center.x + (i - sizeX / 2.0f), center.y + (j - sizeY / 2.0f), center.z);
                GameObject newTile = (GameObject)GameObject.Instantiate(tile, position, Quaternion.identity);
                tiles[i].Add(newTile);
                newTile.GetComponent<SpriteRenderer>().sprite = SelectNewTileType();
                Range tileRange = newTile.AddComponent<Range>();
                tileRange.startPosition = new Vector3(center.x + (i - sizeX / 2.0f), center.y - (sizeY / 2.0f), center.z);
                tileRange.resetDistance.x = sizeX;
                tileRange.resetDistance.y = sizeY;
            }
        }

        SetSpeed(speed);
	}
	
    Sprite SelectNewTileType()
    {
        float totalFreq = 0.0f;
        for (int i = 0; i < tileFrequencies.Length; ++i)
        {
            totalFreq += tileFrequencies[i];
        }

        float rand = Random.Range(0, totalFreq);
        float freqSoFar = tileFrequencies[0];
        for (int i = 0; i < tileFrequencies.Length; ++i)
        {
            if (rand < freqSoFar)
            {
                return tileTypes[i];
            }

            freqSoFar += tileFrequencies[i];
        }

        return tileTypes[tileTypes.Length - 1];
    }

    void SetSpeed(float speedToSet)
    {
        currentSpeed = speedToSet;
        for (int i = 0; i < sizeX; ++i)
        {
            for (int j = 0; j < sizeY; ++j)
            {
                tiles[i][j].GetComponent<Drift>().speed = speedToSet;
            }
        }

        List<Drift> activeFloatingObjects = new List<Drift>();
        for (int i = 0; i < floatingObjects.Count; ++i)
        {
            if (floatingObjects[i] != null)
            {
                floatingObjects[i].speed = speedToSet;
                activeFloatingObjects.Add(floatingObjects[i]);
            }
        }

        floatingObjects = activeFloatingObjects;
    }

    public void AddFloatingObject(GameObject baseObject)
    {
        Drift drift = baseObject.AddComponent<Drift>();
        drift.direction = new Vector3(0, 1, 0);
        drift.speed = currentSpeed;
        floatingObjects.Add(drift);
    }

	// Update is called once per frame
	public override void Update()
    {
        base.Update();
        bool speedSet = false;
        float dt = Time.deltaTime;
	    if (Input.GetKey(turboButton))
        {
            if (turbo > 0 && player.health > 10.0f)
            {
                SetSpeed(speed * turboSpeedMultiplier);
                speedSet = true;
                turbo -= dt;
                player.health -= 10.0f * damageMod * dt;
            }
        }
        else if (Input.GetKey(brakeButton))
        {
            if (brakes > 0)
            {
                SetSpeed(speed * brakesMultiplier);
                speedSet = true;
                brakes -= dt;
                player.health += 5.0f * (1 / damageMod) * dt;
            }
        }

        if (!speedSet)
        {
            SetSpeed(speed);
        }

        // You move down too fast still.
        float distanceMultiplier = 1.0f;
        if (difficulty < 1.0f)
        {
            distanceMultiplier -= 0.25f;
        }
        else if (difficulty > 1.0f)
        {
            distanceMultiplier += 0.25f;
        }

        if (currentSpeed > speed)
        {
            distanceMultiplier += 0.5f;
        }
        else if (currentSpeed < speed)
        {
            distanceMultiplier -= 0.25f;
        }

        distance += currentSpeed * dt * distanceMultiplier;
        
        if (distance >= maxDistance && !levelComplete)
        {
            levelComplete = true;
            SetChildrenActive(GameObject.Find("EndMessage"), true);
            player.PlayEndAnimation();
            StartCoroutine("EndLevel");
        }
	}

    public IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(4.0f + extraEndLevelDelay);
        Application.LoadLevel(nextLevel);
    }
}
