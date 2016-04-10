using UnityEngine;
using System.Collections;

public class ShieldRotationScript : MonoBehaviour {

    private InputGetter inputGetter;
    public float speed = 5;
    public float deadZone = 5;

    // Use this for initialization
    void Start () {
        inputGetter = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputGetter>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 targetPos = inputGetter.getInputLocation();
        Vector2 direction = targetPos - (Vector2)transform.parent.position;
        float angle = Vector2.Angle(transform.up, direction);
        if (Mathf.Abs(angle) > deadZone)
        {
            float orthagonalDirection = Vector2.Dot(direction, new Vector2(-transform.up.y, transform.up.x));
            if (orthagonalDirection < 0)
            {
                angle = -angle;
            }
            else if (orthagonalDirection == 0)
            {
                if (Vector2.Dot(Vector2.up, direction) > 0)
                {
                    angle = -angle;
                }
            }
            transform.RotateAround(transform.parent.position, Vector3.forward, angle);
        }

    }
}
