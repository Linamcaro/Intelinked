using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    //Reference to the SO that have the sounds
    [SerializeField] private SoundsSO soundsfxSO;

    //Reference to the Audio Source
    private AudioSource audioSource;

    //Reference to the volume
    private float volume = 1f;

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get { return _instance; }
    }


    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);

            // Initialize the audio source
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                // If there's no AudioSource component, add one to the GameObject
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
    }

    /// <summary>
    /// Function to play audioclip sound
    /// </summary>
    /// <param name="audioClip"></param>
    /// <param name="volume"></param>
    private void PlaySound(AudioClip audioClip, float volume)
    {
        
            audioSource.PlayOneShot(audioClip, volume);
        
    }

    /// <summary>
    /// Function to play jump sound
    /// </summary>
   
    public void PlayJumpSound()
    {
        PlaySound(soundsfxSO.jump, 1);
    }

    /// <summary>
    /// Function to play death sound
    /// </summary>
    public void PlayDeathSound()
    {
        PlaySound(soundsfxSO.death, volume);
    }

    /// <summary>
    /// Function to play timer sound
    /// </summary>
    public void PlayTimerSound()
    {
        PlaySound(soundsfxSO.timer, volume);
    }

    /// <summary>
    /// Function to play player alignment sound
    /// </summary>
    public void PlayPlayerAlignmentSound()
    {
        PlaySound(soundsfxSO.playerAlignment, volume);
    }


}
