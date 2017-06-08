using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectionPanelElement : MonoBehaviour
{
    private LevelSelectionPanel levelSelectionPanel;

    void Awake()
    {
        levelSelectionPanel = LevelSelectionPanel.Instance();

    }

    public void LoadLevelOne()
    {
        levelSelectionPanel.LoadLevelOne();
        levelSelectionPanel.CloseLevelSelection();
    }

    public void LoadLevelTwo()
    {
        levelSelectionPanel.LoadLevelTwo();
        levelSelectionPanel.CloseLevelSelection();
    }

    public void OpenLevelSelection()
    {
        levelSelectionPanel.OpenLevelSelection();
    }

    public void CloseLevelSelection()
    {
        levelSelectionPanel.CloseLevelSelection();
    }

}