using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{
    public GameObject playerObject;
    public Character player;
    public Tiling background;
    public static bool mouseInput = true;
    public static Character target;
    public static float targetingTime;

    public float pickupMod;
    public float damageMod;

	public virtual void Start()
    {
        background = GameObject.FindWithTag("Background").GetComponent<Tiling>();
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Character>();
        pickupMod = 1.0f / PlayerPrefs.GetFloat("Difficulty", 1.0f);
        damageMod = PlayerPrefs.GetFloat("Difficulty", 1.0f);
	}
	
	public virtual void Update()
    {
        
	}

    public static void SetTarget(Character character)
    {
        if (character == target)
        {
            return;
        }

        targetingTime = 0.0f;
        target = character;
    }
}
