using UnityEngine;
using System.Collections;

public class Crosshair : Rotate 
{
    public float baseRotationSpeed;
    public float speed = 5;
    public float deadZone=.5f;

    private InputGetter inputGetter;

    public virtual void Start()
    {
        baseRotationSpeed = rotationSpeed;
        inputGetter = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputGetter>();
    }

    // Update is called once per frame
	public override void Update()
    {
        Vector2 targetLocation = inputGetter.getInputLocation();
        float distanceToTarget = (targetLocation - (Vector2)transform.position).magnitude;
        if (distanceToTarget > deadZone)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetLocation, distanceToTarget * speed * Time.deltaTime);
        }

        if (Base.target != null)
        {
            rotationSpeed = -baseRotationSpeed * 8.0f;
        }
        else
        {
            rotationSpeed = baseRotationSpeed;
        }

        base.Update();
	}
}
