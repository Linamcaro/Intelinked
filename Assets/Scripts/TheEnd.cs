using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{

    private static TheEnd _instance;
    public static TheEnd Instance
    {
        get { return _instance; }
    }

    [SerializeField] private GameObject finishText;


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

    public void Show()
    {
      
        finishText.SetActive(true);

    }
   


}
