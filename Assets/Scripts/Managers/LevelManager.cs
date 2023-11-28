using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get { return _instance; }
    }


    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(this);
        }
        else
        {
            _instance = this;
        }

    }


    // Load level by index
    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            TheEnd.Instance.Show();

            Debug.Log("No more levels available.");
        }

    }

    public void LoadNextLevel()
    {
        NextLevel();
    }
}
