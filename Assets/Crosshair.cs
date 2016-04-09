using UnityEngine;
using System.Collections;

public class Crosshair : Rotate 
{
    public float baseRotationSpeed;
    public Camera camera;

    public virtual void Start()
    {
        baseRotationSpeed = rotationSpeed;
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
	public override void Update()
    {
        base.Update();
        Vector3 inputPosition = Input.mousePosition;
        Vector3 ray = camera.ScreenToWorldPoint(new Vector3(Screen.width - inputPosition.x, Screen.height - inputPosition.y, camera.transform.position.z));
        ray.z = 0;
        transform.position = ray;

        if (Base.target != null)
        {
            rotationSpeed = baseRotationSpeed * 3.0f;
        }
        else
        {
            rotationSpeed = baseRotationSpeed;
        }
	}
}
