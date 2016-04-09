using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed;

    public virtual void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }
}
