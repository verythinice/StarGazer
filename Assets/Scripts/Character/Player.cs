using UnityEngine;
using System.Collections;

public class Player : Character
{
    public GameObject playerShield;
    public GameObject playerLaser;

	// Use this for initialization
	public override void Start()
    {
        base.Start();
        playerShield = GameObject.FindWithTag("Shield");
        playerLaser = transform.Find("PlayerLaser").gameObject;
        playerLaser.SetActive(false);
	}

    public override void OnDeath()
    {
        transform.Translate(new Vector3(0, 9001, 0));
        GetComponent<SpriteRenderer>().enabled = false;
        playerShield.GetComponent<SpriteRenderer>().enabled = false;
        playerLaser.GetComponentInChildren<SpriteRenderer>().enabled = false;
        StartCoroutine(DelayedReload());
    }

    public IEnumerator DelayedReload()
    {
        yield return new WaitForSeconds(2.0f); 
        Application.LoadLevel(Application.loadedLevel);
    }

    public override void OnCollision(Character other)
    {
        health -= other.damage * damageMod;
    }

	// Update is called once per frame
	public override void Update()
    {
        base.Update();
        float dt = Time.deltaTime;
        if (target != null)
        {
            targetingTime += dt;
            if (target.targetingType == Character.TT_LOCK_ON)
            {
                playerLaser.SetActive(true);
                Vector3 direction = target.transform.position - player.transform.position;
                Vector3 midpoint = player.transform.position + direction / 2;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                playerLaser.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                float distance = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
                playerLaser.transform.localScale = new Vector3(distance / 3, playerLaser.transform.localScale.y, playerLaser.transform.localScale.z);
                playerLaser.transform.position = midpoint;
            }
            else
            {
                playerLaser.SetActive(false);
            }

            if (target.targetingType == Character.TT_SHIELD || target.targetingType == Character.TT_NO_EFFECT)
            {
                playerShield.SetActive(true);
            }
            else
            {
                playerShield.SetActive(false);
            }

            if (target.targetingType == Character.TT_EYE_BURN)
            {
                player.health -= 1.0f * dt * damageMod;
            }
            else if (target.targetingType == Character.TT_TRACTOR)
            {
                if (targetingTime > 1.0f)
                {
                    Pickup pickup = target.gameObject.GetComponent<Pickup>();
                    if (pickup != null)
                    {
                        if (pickup.type == Pickup.PickupType.PT_HEALTH)
                        {
                            player.health += pickup.intensity * base.pickupMod;
                            if (health > maxHealth)
                            {
                                health = maxHealth;
                            }
                        }
                        targetingTime = 0.0f;
                        target = null;

                        Destroy(pickup.gameObject);
                    }
                }
            }
        }
        else
        {
            playerShield.SetActive(true);
            playerLaser.SetActive(false);
        }
	}
}
