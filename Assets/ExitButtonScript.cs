using UnityEngine;
using System.Collections;

public class ExitButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ExitToMainMenu () {
        Application.LoadLevel(0);
    }
}
