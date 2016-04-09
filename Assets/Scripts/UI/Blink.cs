using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour
{
    public GameObject[] blinkers;
    public float timeUntilSwitch;
    public float shownTime;
    public float hiddenTime;
    public bool hidden;
	
    void Start()
    {
        timeUntilSwitch = shownTime;
        hidden = false;
    }

	// Update is called once per frame
	void Update()
    {
        timeUntilSwitch -= Time.deltaTime;
        if (timeUntilSwitch <= 0.0f)
        {
            ToggleBlinkers();
        }
	}

    void ToggleBlinkers()
    {
        hidden = !hidden;
        if (hidden)
        {
            timeUntilSwitch = hiddenTime;
        }
        else
        {
            timeUntilSwitch = shownTime;
        }
        
        for (int i = 0; i < blinkers.Length; ++i)
        {
            blinkers[i].SetActive(!hidden);
        }
    }
}
