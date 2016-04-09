using UnityEngine;
using System.Collections;

public class ShieldRotationScript : MonoBehaviour {

    private InputGetter inputGetter;

	// Use this for initialization
	void Start () {
        inputGetter = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputGetter>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 targetPos = inputGetter.getInputLocation();
        Vector2 direction = targetPos - (Vector2)transform.parent.position;
        float angle = Mathf.Acos(Mathf.Clamp(Vector2.Dot(direction, transform.up) / (direction.magnitude * transform.up.magnitude),0,1))*Mathf.Rad2Deg;
        if (Vector2.Dot(direction, new Vector2(-transform.up.y, transform.up.x)) < 0)
        {
            angle = -angle;
        }
        
        if (angle.CompareTo(float.NaN) != 0)
        {
            transform.RotateAround(transform.parent.position, Vector3.forward, angle);
        }
	}
}
