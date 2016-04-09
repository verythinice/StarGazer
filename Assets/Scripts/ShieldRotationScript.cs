using UnityEngine;
using System.Collections;

public class ShieldRotationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.parent.position;
        float angle = Mathf.Acos(Mathf.Clamp(Vector2.Dot(direction, transform.up) / (direction.magnitude * transform.up.magnitude),0,1))*Mathf.Rad2Deg;
        if (Vector2.Dot(direction, new Vector2(-transform.up.y, transform.up.x)) < 0)
        {
            angle = -angle;
        }
        transform.RotateAround(transform.parent.position, Vector3.forward, angle);
	}
}
