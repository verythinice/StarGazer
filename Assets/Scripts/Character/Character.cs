﻿using UnityEngine;
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
        
        Destroy(gameObject);
    }

    public virtual void OnMouseOver()
    {
        if (Base.mouseInput)
        {
            OnTargeting();
        }
    }

    public virtual void OnMouseExit()
    {
        if (Base.mouseInput)
        {
            OnDetarget();
        }
    }



    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() != null)
        {
            OnCollision(other.GetComponent<Character>());
        }
    }

    public virtual void OnCollision(Character other)
    {
        if (team == other.team)
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
