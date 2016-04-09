using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class RandomSprite : MonoBehaviour
{
    public Sprite[] sprites;

	// Use this for initialization
	void Start()
    {
        if (sprites.Length > 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        }
	}
}
