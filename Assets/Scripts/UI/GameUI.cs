using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    


    private void Show()
    {
        LevelTextUI.SetActive(true);

    }
    private void Hide()
    {
        LevelTextUI.SetActive(false);
    }

}
