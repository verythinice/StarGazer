using UnityEngine;
using System.Collections;

public class Player : Character
{
    public GameObject playerShield;

	// Use this for initialization
	public override void Start()
    {
        base.Start();
        playerShield = GameObject.FindWithTag("Shield");
	}
	
	// Update is called once per frame
	public override void Update()
    {
        base.Update();
        print(target);
        print(targetingTime);
        float dt = Time.deltaTime;
        if (target != null)
        {
            targetingTime += dt;
            if (target.targetingType == Character.TT_LOCK_ON)
            {
                if (targetingTime >= 3.0f)
                {
                    targetingTime -= 3.0f;
                    target.health -= 50;
                }
            }
            else if (target.targetingType == Character.TT_EYE_BURN)
            {
                player.health -= 1.0f * dt;
            }
            else if (target.targetingType == Character.TT_TRACTOR)
            {
                // ... do stuff ...
            }

            if (target.targetingType == Character.TT_SHIELD || target.targetingType == Character.TT_NO_EFFECT)
            {
                playerShield.SetActive(true);
            }
            else
            {
                playerShield.SetActive(false);
            }
        }
        else
        {
            playerShield.SetActive(true);
        }
	}
}
