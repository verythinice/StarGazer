using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public int team;
    public float damage;

    void OnTriggerStay2D(Collider2D other)
    {
        Character otherCharacter = other.GetComponent<Character>();
        if (otherCharacter == null || otherCharacter.team == team)
        {
            return;
        }

        otherCharacter.health -= damage * Time.deltaTime;
    }
}
