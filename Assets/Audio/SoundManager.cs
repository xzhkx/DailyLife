using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    GOLDMOUNTAINBGM,
    PLAYHOUSEBGM,
    KITCHENBGM,
    DUNGEONBGM,

    CLICK,
    COOK,
    MINING,
    CLAIM,
    SELECTTILE,
    ADDCOIN
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{  
    public static SoundManager Instance { get; private set; }

    [SerializeField] private List<AudioClip> soundList = new List<AudioClip>();

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundType sound, float volume = 1)
    {
        audioSource.PlayOneShot(soundList[(int)sound], volume);
    }
}
