using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;

    private AudioSource audioSource;

    public static MusicManager Instance { get; private set; }

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);

            // Initialize the audio source
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                // If there's no AudioSource component, add one to the GameObject
                audioSource = gameObject.AddComponent<AudioSource>();
            }

        }
        else
        {
            Destroy(gameObject);
        }

    }

    //-----------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Method to play a clip, set if looping and if should restart
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="looping"></param>
    /// <param name="restart"></param>
    private void PlayTrack(AudioClip clip, bool looping, bool restart)
    {
        if (audioSource.isPlaying)
        {
            //if we don want to restart the clip then return
            if (!restart && audioSource.clip == clip) { return; }
            audioSource.Stop();
        }

        audioSource.clip = clip;
        audioSource.loop = looping;
        audioSource.time = 0;
        audioSource.Play();

    }

    //-----------------------------------------------------------------------------------------------------------

    public void PlayMenuMusic(bool restart)
    {
        PlayTrack(menuMusic, true, restart);
    }

    //-----------------------------------------------------------------------------------------------------------

    public void PlayGameMusic(bool restart)
    {
        PlayTrack(gameMusic, true, restart);
    }

}