using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsSlider : MonoBehaviour
{
    public string settingName;
    public Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(settingName, 1.0f) * 10.0f;
    }

    public void OnValueUpdate()
    {
        PlayerPrefs.SetFloat(settingName, slider.value / 10.0f);
    }
}
