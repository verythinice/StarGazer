using UnityEngine;
using System.Collections;

public class SolarFlare : Base
{
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
	}
	
	// Update is called once per frame
	public override void Update()
    {
        base.Update();
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart > delay)
        {
            ClearAsteroids();

            print(input.getInputPresence());
            if (input.getInputPresence())
            {
                player.health -= intensity * Time.deltaTime * damageMod;
            }
        }

        if (timeSinceStart > delay - 1 && !warning.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            SetWarningShown(true);
        }

        if (timeSinceStart > delay + duration)
        {
            SetWarningShown(false);
            Destroy(gameObject);
        }
	}

    void SetWarningShown(bool shown)
    {
        for (int i = 0; i < warning.transform.childCount; ++i)
        {
            warning.transform.GetChild(i).gameObject.SetActive(shown);
        }
    }

    void ClearAsteroids()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        for (int i = 0; i < asteroids.Length; ++i)
        {
            asteroids[i].GetComponent<Character>().health = 0;
        }
    }
}
