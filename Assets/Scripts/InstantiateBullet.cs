using UnityEngine;
using System.Collections;

public class InstantiateBullet : MonoBehaviour {

	public GameObject laser;
	private GameObject laser_p;
	public GameObject player;
	private float timeStamp = 0f;
	public float cooldown = 1.5f;
	public float spd = 1f;
		// Use this for initialization
	void Start () {

	}

		// Update is called once per frame
	void Update () {
		//Find player vector position
		player = GameObject.FindWithTag("Player");

			//Instantiate this number of bullet toward player position
		if (Time.time > timeStamp + cooldown)
		{
			laser_p = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
			Drift laser_temp = laser_p.AddComponent<Drift>();
			laser_temp.speed = spd;	
			Vector2 pos = (player.transform.position - transform.position);

            // Shoot underneath the player.
            pos.y -= 1;

            pos.Normalize();

			laser_temp.direction = pos;

            Transform start = laser_p.transform.GetChild(0).transform;
            Vector3 direction = player.transform.position - start.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            start.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			timeStamp = Time.time;
		}
	}
}