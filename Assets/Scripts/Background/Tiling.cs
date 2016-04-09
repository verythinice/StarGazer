using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tiling : MonoBehaviour
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

    List<List<GameObject>> tiles;
    int bottomY;
    int bottomIndex;

	// Use this for initialization
	void Start()
    {
        turbo = 5.0f;
        brakes = 3.0f;

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
        for (int i = 0; i < sizeX; ++i)
        {
            for (int j = 0; j < sizeY; ++j)
            {
                tiles[i][j].GetComponent<Drift>().speed = speedToSet;
            }
        }
    }

	// Update is called once per frame
	void Update()
    {
	    if (Input.GetKey(turboButton))
        {
            SetSpeed(speed * turboSpeedMultiplier);
        }
        else if (Input.GetKey(brakeButton))
        {
            SetSpeed(speed * brakesMultiplier);
        }
        else
        {
            SetSpeed(speed);
        }
	}
}
