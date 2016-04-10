using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthCircularBarScript : CircularBarScript {

    override public float getCurrentAmount()
    {
        return base.player.health;
    }

    override public float getMaxAmount()
    {
        return base.player.maxHealth;
    }

}
