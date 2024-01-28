using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllatorSounds : MonoBehaviour
{
    public static ControllatorSounds Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void ExecuteSound(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
}
