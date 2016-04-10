using UnityEngine;
using System.Collections;

public class Laser : Base
{
    public int team;
    public float damage;
    public float timeSinceSound = 0.0f;
    public float soundDelay;

    void OnTriggerStay2D(Collider2D other)
    {
        Character otherCharacter = other.GetComponent<Character>();
        if (otherCharacter == null || otherCharacter.team == team)
        {
            return;
        }

        timeSinceSound += Time.deltaTime;
        if (timeSinceSound > soundDelay)
        {
            timeSinceSound = 0.0f;
            sound.PlaySound(SoundManager.SoundID.SID_PLAYER_LASER);
        }
        
        otherCharacter.health -= damage * Time.deltaTime;
    }
}
