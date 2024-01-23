using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField inputName;

    private bool canStart = false;
    void Start()
    {
        if (Data.Instance.playerName != "")
        {
            inputName.text = Data.Instance.playerName;
        }

    }


    void Update()
    {
        if ( inputName.text == null || inputName.text == "")
        {
            canStart = false;
        }
        else
        {
            canStart = true;
        }
    }


    public void StartGame()
    {
        if (canStart)
        {
            Data.Instance.playerName = inputName.text;
            SceneManager.LoadScene(1);
            Debug.Log(Data.Instance.playerName);
        }
    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
