using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{
    public GameObject playerObject;
    public Player player;
    public Tiling background;
    public static bool mouseInput = true;
    public static Character target;
    public static float targetingTime;

    public float difficulty;
    public float pickupMod;
    public float damageMod;

    public float screenShake;
    private CameraShakeScript cameraShakeScript;
    public SoundManager sound;

    public virtual void Start()
    {
        background = GameObject.FindWithTag("Background").GetComponent<Tiling>();
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();
        sound = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        difficulty = PlayerPrefs.GetFloat("Difficulty", 1.0f);
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

    public void SetChildrenActive(GameObject parent, bool active)
    {
        if (parent == null)
        {
            return;
        }

        for (int i = 0; i < parent.transform.childCount; ++i)
        {
            parent.transform.GetChild(i).gameObject.SetActive(active);
        }
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
