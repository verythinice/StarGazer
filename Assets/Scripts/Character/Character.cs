using UnityEngine;
using System.Collections;

public class Character : Base
{
    public static int TT_NO_EFFECT = 0;
    public static int TT_SHIELD = 1;
    public static int TT_LOCK_ON = 2;
    public static int TT_TRACTOR = 3;
    public static int TT_EYE_BURN = 4;

    public int team;
    public int targetingType;
    public bool isStatic = false;
    public float damage;
    public float maxHealth;
    public float health;
    public GameObject explosion;
    public SoundManager.SoundID deathEffect;

	// Use this for initialization
	public override void Start()
    {
        base.Start();
        if (maxHealth == 0)
        {
            maxHealth = 1;
        }

        health = maxHealth;
        if (!isStatic)
        {
            background.AddFloatingObject(gameObject);
        }
	}
	
	// Update is called once per frame
	public override void Update()
    {
        base.Update();
        if (health <= 0.0f)
        {
            OnDeath();
        }
	}

    public virtual void OnDeath()
    {
        if (explosion != null)
        {
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
        }
        sound.PlaySound(deathEffect);
        shakeScreen();
        Destroy(gameObject);
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        Character otherCharacter = other.GetComponent<Character>();
        if (otherCharacter != null && otherCharacter.team != -1 && team != -1)
        {
            OnCollision(otherCharacter);
        }

        if (other.tag == "Crosshair")
        {
            OnTargeting();
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Crosshair")
        {
            OnDetarget();
        }
    }

    public virtual void OnCollision(Character other)
    {
        if (team == other.team || other.team == 5 || team == 5)
        {
            return;
        }

        health -= other.damage;
    }

    public virtual void OnTargeting()
    {
        Base.SetTarget(this);
    }

    public virtual void OnDetarget()
    {
        if (Base.target == this)
        {
            Base.SetTarget(null);
        }
    }
}
