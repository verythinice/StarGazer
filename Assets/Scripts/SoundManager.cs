using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public enum SoundID
    {
        SID_PICKUP = 0,
        SID_PLAYER_CRASH = 1,
        SID_PLAYER_HIT = 2,
        SID_PLAYER_LASER = 3,
        SID_PLAYER_LASER_ALT = 4,
        SID_DEBRIS = 5,
        SID_SOLAR_FLARE_CLEAR = 6,
        SID_SOLAR_FLARE_PHASE = 7,
        SID_SOLAR_FLARE_WARNING = 8,
        SID_PLAYER_DEAD = 9,
        SID_ASTEROID_EXPLOSION = 10,
    }

    public AudioSource effects;
    public AudioSource musicPlayer;
    public AudioClip[] soundEffects;
    public AudioClip[] music;

	// Use this for initialization
	void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        effects = sources[0];
        musicPlayer = sources[1];
	}
	
	// Update is called once per frame
	void Update()
    {
	    if (!musicPlayer.isPlaying)
        {
            musicPlayer.PlayOneShot(music[Random.Range(0, music.Length)]);
        }
	}

    public void PlaySound(SoundID soundID)
    {
        effects.PlayOneShot(soundEffects[(int)soundID]);
    }
}
