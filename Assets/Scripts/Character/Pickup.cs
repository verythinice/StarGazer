using UnityEngine;
using System.Collections;

public class Pickup : Character
{
    public enum PickupType
    {
        PT_HEALTH = 1,
    }

    public PickupType type;
    public float intensity;
}
