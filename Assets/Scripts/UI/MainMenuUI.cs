using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private void Awake()
    {
        MusicManager.Instance.PlayMenuMusic(true); 
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("FirstLevel");
    }
}
