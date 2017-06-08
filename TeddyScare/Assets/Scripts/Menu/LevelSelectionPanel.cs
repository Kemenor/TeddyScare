using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectionPanel : MonoBehaviour
{
    public GameObject levelSelectionPanelObject;

    private static LevelSelectionPanel levelSelectionPanel;

    public static LevelSelectionPanel Instance()
    {
        if (!levelSelectionPanel)
        {
            levelSelectionPanel = FindObjectOfType(typeof(LevelSelectionPanel)) as LevelSelectionPanel;
            if (!levelSelectionPanel)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return levelSelectionPanel;
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Bear1");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Bear2");
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