using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private void Start()
    {
        MusicManager.Instance.PlayMenuMusic(false); 
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("FirstLevel");
    }
}
