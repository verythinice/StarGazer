using UnityEngine;
using System.Collections;

public class SolarLight : MonoBehaviour {
    private float brightness = 0;
    LensFlare lensFlare;
    private bool on = true;

	// Use this for initialization
	void Start () {
        lensFlare = GetComponent<LensFlare>();
        for (int i = 0; i < 20; i++){
           
                lensFlare.brightness += 2;
            
        }
    }
	
	
	// Update is called once per frame
	void Update () {

        if (lensFlare.brightness > 0.0f) 
        { 
            float fade = GetComponent<LensFlare>().fadeSpeed;
            lensFlare.brightness -= fade;
        }
	}
}
