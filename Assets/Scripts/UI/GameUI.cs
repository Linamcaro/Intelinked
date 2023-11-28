using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject LevelTextUI;

    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.PlayGameMusic(true);
        
    }


    public void ShowLevelNumber()
    {
        StartCoroutine(TextTimer());
    }


    IEnumerator TextTimer()
    {
        Show();
        yield return new WaitForSeconds(1f);
        Hide();
    }


    public void ReturnMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    private void Show()
    {
        LevelTextUI.SetActive(true);

    }
    private void Hide()
    {
        LevelTextUI.SetActive(false);
    }

}
