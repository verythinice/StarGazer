using UnityEngine;
using System.Collections;

public class Character : Base
{
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
        print("Stop poking me!");
        if (Base.mouseInput)
        {
            OnTargeting();
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
        health -= 10;
    }
}
