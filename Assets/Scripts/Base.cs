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

    public float screenShake;
    private CameraShakeScript cameraShakeScript;
    public SoundManager sound;

    public virtual void Start()
    {
        background = GameObject.FindWithTag("Background").GetComponent<Tiling>();
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Character>();
        sound = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        pickupMod = 1.0f / PlayerPrefs.GetFloat("Difficulty", 1.0f);
        damageMod = PlayerPrefs.GetFloat("Difficulty", 1.0f);
        if (screenShake > 0)
        {
            cameraShakeScript = Camera.main.gameObject.GetComponent<CameraShakeScript>();
        }
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

    //Overloads for controlling screenshake
    protected void shakeScreen()
    {
        if (screenShake > 0)
        {
            shakeScreen(screenShake);
        }
    }

    protected void shakeScreen(float shake)
    {
        if (cameraShakeScript != null)
        {
            cameraShakeScript.screenShake(shake);
        }
    }

    protected void shakeScreen(float shake, float shakeAmount)
    {
        if (cameraShakeScript != null)
        {
            cameraShakeScript.screenShake(shakeAmount, shake);
        }
    }
}
