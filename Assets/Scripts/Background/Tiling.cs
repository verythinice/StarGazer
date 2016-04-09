using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tiling : MonoBehaviour
{
    public GameObject[] tileTypes;
    public int sizeX;
    public int sizeY;
    public Vector3 center;
    List<List<GameObject>> tiles;
    int bottomY;
    int bottomIndex;

	// Use this for initialization
	void Start()
    {
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
                tiles[i][j] = (GameObject)GameObject.Instantiate(tileTypes[Random.Range(0, tileTypes.Length)], position, Quaternion.identity);
                print("instantiaing at: ");
                print(position);
            }
        }
	}
	
	// Update is called once per frame
	void Update()
    {
	    
	}
}
