using UnityEngine;
using System.Collections;

public class GameMiscScript : MonoBehaviour {

	public Transform crossHair;

	// Use this for initialization
	void Start () {
        crossHair = GameObject.FindWithTag("Crosshair").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = crossHair.position;
	}
}
