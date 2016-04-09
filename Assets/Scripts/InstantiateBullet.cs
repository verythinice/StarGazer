using UnityEngine;
using System.Collections;

public class InstantiateBullet : MonoBehaviour {

	public GameObject laser;
	private GameObject laser_p;
	public GameObject player;
	private float timeStamp = 0f;
	private float cooldown = 1.5f;
	private float spd = 1f;
		// Use this for initialization
	void Start () {

	}

		// Update is called once per frame
	void Update () {
		//Find player vector position
		player = GameObject.Find("Player");

			//Instantiate this number of bullet toward player position
		if (Time.time > timeStamp + cooldown)
		{
			laser_p = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
			Drift laser_temp = laser_p.AddComponent<Drift>();
			laser_temp.speed = spd;	
			Vector2 pos = (player.transform.position - transform.position).normalized;
			laser_temp.direction = pos;
			timeStamp = Time.time;
		}
	}
}