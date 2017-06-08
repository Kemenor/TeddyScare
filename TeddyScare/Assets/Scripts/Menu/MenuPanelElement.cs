using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuPanelElement: MonoBehaviour
{
    private MenuPanel menuPanel;

    void Awake()
    {
        menuPanel = MenuPanel.Instance();              
    }

    public void StartGame()
    {
        menuPanel.StartGame();
    }


    public void OpenLevelSelection()
    {
        menuPanel.OpenLevelSelection();
    }

    public void CloseLevelSelection()
    {
        menuPanel.CloseLevelSelection();
    }

}