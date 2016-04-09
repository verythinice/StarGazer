using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class HealthTint : MonoBehaviour
{
    public Color tint;
    Character character;
    SpriteRenderer renderer;
    
    public void Start()
    {
        character = GetComponentInParent<Character>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.white;
    }

    public void Update()
    {
        float ratio = character.health / character.maxHealth;
        ratio = ratio * ratio * ratio;
        Color currentTint = Color.white * ratio + tint * (1 - ratio);
        currentTint.a = 1.0f;
        renderer.color = currentTint;
    }
}
