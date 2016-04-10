using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DistanceCircularBarScript : CircularBarScript {

    override public float getCurrentAmount()
    {
        return base.background.distance;
    }

    override public float getMaxAmount()
    {
        return base.background.maxDistance;
    }

}
