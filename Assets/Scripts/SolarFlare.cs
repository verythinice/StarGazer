using UnityEngine;
using System.Collections;

public class SolarFlare : MonoBehaviour
{
    public float delay;
    public float duration;
    public float intensity;
    public float timeSinceStart;
    GameObject warning;

	// Use this for initialization
	void Start()
    {
        timeSinceStart = 0.0f;
        warning = GameObject.Find("SolarFlareWarning");
	}
	
	// Update is called once per frame
	void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart > delay)
        {
            ClearAsteroids();
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
