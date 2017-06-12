using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public GameObject levelSelectionPanelObject;

    private static MenuPanel menuPanel;

    public static MenuPanel Instance()
    {
        if (!menuPanel)
        {
            menuPanel = FindObjectOfType(typeof(MenuPanel)) as MenuPanel;
            if (!menuPanel)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return menuPanel;
    }
             
    public void StartGame()
    {
        Game.Instance.NextLevel();
    }

    public void OpenLevelSelection()
    {
        levelSelectionPanelObject.SetActive(true);
    }

    public void CloseLevelSelection()
    {
        levelSelectionPanelObject.SetActive(false);
    }
}