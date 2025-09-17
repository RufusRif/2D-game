using System;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSoundSource;

    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;

    [SerializeField] private AudioClip playerDeathMusic;
    [SerializeField] private AudioClip playerThrowDynamite;
    [SerializeField] private AudioClip playerTakeDamage;
    [SerializeField] private AudioClip playerThrowApple;
    [SerializeField] private AudioClip playerPickFruit;
    [SerializeField] private AudioClip playerJump;

    [SerializeField] private AudioClip bunnyAteFruit;
    [SerializeField] private AudioClip bunnyThrowDynamite;

    [SerializeField] private AudioClip rhinoMoveToTarget;
    [SerializeField] private AudioClip rhinoDeath;
    [SerializeField] private AudioClip rhinoTakeDmage;

    [SerializeField] private AudioClip dynamiteExplosion;
    [SerializeField] private AudioClip buttonPress;
    [SerializeField] private AudioClip winMusic;
    [SerializeField] private AudioClip playerCaught;

    private Dictionary<string, AudioClip> soundClips;

    private void Awake()
    {
        Instance = this;

        musicSource.loop = true;
        effectSoundSource.loop = false;

        soundClips = new Dictionary<string, AudioClip>
        {
            { "MenuMusic", menuMusic },
            { "GameMusic", gameMusic },
            { "WinMusic", winMusic },
            { "PlayerDeathMusic", playerDeathMusic },
            { "PlayerThrowDynamite", playerThrowDynamite },
            { "PlayerTakeDamage", playerTakeDamage },
            { "PlayerThrowApple", playerThrowApple },
            { "PlayerPickFruit", playerPickFruit },
            { "PlayerJump", playerJump },
            { "PlayerCaught", playerCaught },
            { "BunnyAteFruit", bunnyAteFruit },
            { "BunnyThrowDynamite", bunnyThrowDynamite },
            { "RhinoMoveToTarget", rhinoMoveToTarget },
            { "RhinoDeath", rhinoDeath },
            { "RhinoTakeDamage", rhinoTakeDmage },
            { "DynamiteExplosion", dynamiteExplosion },
            { "ButtonPress", buttonPress }
        };

    }

    public void PlayMusic(string musicName)
    {
        if (soundClips.TryGetValue(musicName, out AudioClip clip))
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }
    public void PlaySoundEffect(string soundName)
    {
        if (soundClips.TryGetValue(soundName, out AudioClip clip))
        {
            effectSoundSource.PlayOneShot(clip);
        }
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
}


