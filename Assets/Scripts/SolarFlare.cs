using UnityEngine;
using System.Collections;

public class SolarFlare : Base
{
    public GameObject solarFlareVisual;
    bool spawned;
    public float delay;
    public float duration;
    public float intensity;
    public float timeSinceStart;
    GameObject warning;
    InputGetter input;

	// Use this for initialization
	public override void Start()
    {
        base.Start();
        timeSinceStart = 0.0f;
        warning = GameObject.Find("SolarFlareWarning");
        input = GameObject.Find("InputManager").GetComponent<InputGetter>();
        sound.PlaySound(SoundManager.SoundID.SID_SOLAR_FLARE_WARNING);
        spawned = false;
	}
	
	// Update is called once per frame
	public override void Update()
    {
        base.Update();
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart > delay)
        {
            ClearAsteroids();
            if (input.getInputPresence())
            {
                player.health -= intensity * Time.deltaTime * damageMod;
            }
            if (!spawned)
            {
                GameObject.Instantiate(solarFlareVisual);
                spawned = true;
            }
        }

        if (timeSinceStart > delay - 1 && !warning.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            SetWarningShown(true);
            sound.PlaySound(SoundManager.SoundID.SID_SOLAR_FLARE_PHASE);
        }

        if (timeSinceStart > delay + duration)
        {
            sound.PlaySound(SoundManager.SoundID.SID_SOLAR_FLARE_CLEAR);
            SetWarningShown(false);
            Destroy(gameObject);
        }
	}

    void SetWarningShown(bool shown)
    {
        SetChildrenActive(warning, shown);
    }

    void ClearAsteroids()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        for (int i = 0; i < asteroids.Length; ++i)
        {
            asteroids[i].GetComponent<Character>().health = 0;
        }

        GameObject[] lasers = GameObject.FindGameObjectsWithTag("Laser");
        for (int i = 0; i < lasers.Length; ++i)
        {
            Destroy(lasers[i]);
        }
    }
}
