using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TobiiButton : MonoBehaviour
{
    public Toggle toggle;

    public void Start()
    {
        toggle = GetComponent<Toggle>();
    }

	public void SetTobii()
    {
        bool active = toggle.isOn;
        if (active)
        {
            PlayerPrefs.SetInt("UseMouse", 0);
        }
        else
        {
            PlayerPrefs.SetInt("UseMouse", 1);
        }
    }
}
