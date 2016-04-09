using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{
    public Tiling background;
    public static bool mouseInput = true;
    public static Character target;
    public static float targettingTime;

	public virtual void Start()
    {
        background = GameObject.FindWithTag("background").GetComponent<Tiling>();
	}
	
	public virtual void Update()
    {
        
	}
}
