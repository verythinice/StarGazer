using UnityEngine;
using System.Collections;

public class Player : Character
{
    public GameObject playerShield;
    public GameObject playerLaser;

    public enum State
    {
        LEVEL_START,
        PLAY,
        LEVEL_END
    }

    private State currentState;
    private float enterTime = 3;
    private float exitTime = 3;
    private float time;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        playerShield = GameObject.FindWithTag("Shield");
        playerLaser = transform.Find("PlayerLaser").gameObject;
        playerLaser.SetActive(false);
        currentState = State.LEVEL_START;
        transform.position = new Vector2(0, 7);
        time = 0;
        shakeScreen(3, 0.1f);
    }

    public override void OnDeath()
    {
        transform.Translate(new Vector3(0, 9001, 0));
        GetComponent<SpriteRenderer>().enabled = false;
        playerShield.GetComponent<SpriteRenderer>().enabled = false;
        playerLaser.GetComponentInChildren<SpriteRenderer>().enabled = false;
        StartCoroutine(DelayedReload());
        sound.PlaySound(SoundManager.SoundID.SID_PLAYER_DEAD);
        shakeScreen(3, 1);
    }

    public IEnumerator DelayedReload()
    {
        yield return new WaitForSeconds(2.0f); 
        Application.LoadLevel(Application.loadedLevel);
    }

    public override void OnCollision(Character other)
    {
        if (other.team == 5)
        {
            Pickup pickup = other.GetComponent<Pickup>();
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
                sound.PlaySound(SoundManager.SoundID.SID_PICKUP);
            }
        }
        else
        {
            if (other.damage > 20)
            {
                sound.PlaySound(SoundManager.SoundID.SID_PLAYER_CRASH);
            }
            else
            {
                sound.PlaySound(SoundManager.SoundID.SID_PLAYER_HIT);
            }
            health -= other.damage * damageMod;
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        if (currentState == State.LEVEL_START)
        {
            Vector2 startPosition = new Vector2(0, 7);
            Vector2 targetPosition = new Vector2(0, 0);
            //increment timer once per frame
            time += Time.deltaTime;
            if (time > enterTime)
            {
                time = enterTime;
            }

            float t = time / enterTime;
            t = Mathf.Atan(Mathf.Atan(t * Mathf.PI * 0.5f)*Mathf.PI*0.5f);
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            if (time == enterTime)
            {
                time = 0;
                currentState = State.PLAY;
                background.turbo = 50000;
                SetChildrenActive(GameObject.Find("StartMessage"), false);
            }
            else
            {
                background.turbo = 0;
                SetChildrenActive(GameObject.Find("StartMessage"), true);
            }
            playerShield.SetActive(false);
        }
        else if (currentState == State.PLAY)
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

                if (target.targetingType == Character.TT_EYE_BURN)
                {
                    player.health -= 1.0f * dt * damageMod;
                }
                else if (target.targetingType == Character.TT_TRACTOR)
                {
                    float distance = (target.transform.position - transform.position).magnitude + 1.0f;
                    target.transform.position = Vector3.MoveTowards(target.transform.position, transform.position, distance * Time.deltaTime);
                }
            }
            else
            {
                playerLaser.SetActive(false);
            }

            playerShield.SetActive(true);
        }
        else if (currentState == State.LEVEL_END)
        {
            Vector2 startPosition = new Vector2(0, 0);
            Vector2 targetPosition = new Vector2(0, -7);
            //increment timer once per frame
            time += Time.deltaTime;
            if (time > exitTime)
            {
                time = exitTime;
            }

            float t = time / exitTime;
            t = Mathf.Pow(t,4);
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            if (time == exitTime)
            {
                // We do this in Tiling now.
                //Application.LoadLevel(Application.loadedLevel);
            }
            playerShield.SetActive(false);
            playerLaser.SetActive(false);
        }
    }

    public void PlayEndAnimation()
    {
        currentState = State.LEVEL_END;
        health = 20000;
        maxHealth = 20000;
        shakeScreen(3, .1f);
    }
}
