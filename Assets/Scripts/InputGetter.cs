using UnityEngine;
using System.Collections;

public class InputGetter : MonoBehaviour {
    public enum InputType
    {
        MOUSE,
        TOBII_EYE
    }
    public InputType inputType;

    private EyeTrackerScript eyeTrackerScript;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("UseMouse", 0) == 1)
        {
            inputType = InputType.MOUSE;
        }
        else
        {
            inputType = InputType.TOBII_EYE;
        }

        if (inputType == InputType.TOBII_EYE)
        {
            eyeTrackerScript = GetComponent<EyeTrackerScript>();
        }
	}
	
    public Vector2 getInputLocation()
    {
        if (inputType == InputType.MOUSE)
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (inputType == InputType.TOBII_EYE)
        {
            return Camera.main.ScreenToWorldPoint(eyeTrackerScript.getScreenPoint());
        }
        else
        {
            return new Vector2();
        }
    }

    public bool getInputPresence()
    {
        if (inputType == InputType.TOBII_EYE)
        {
            return eyeTrackerScript.getEyePresence();
        }
        else
        {
            return !Input.GetMouseButton(1);
        }
    }
}
