using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class MenuManager : MonoBehaviour, IEventHandler
{
    [SerializeField] GameObject m_MenuPanel;
    [SerializeField] GameObject m_PausePanel;
    [SerializeField] GameObject m_VictoryPanel;
    [SerializeField] GameObject m_GameOverPanel;

    List<GameObject> m_AllPanels = new List<GameObject>();

    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<GameMenuEvent>(GameMenu);
        EventManager.Instance.AddListener<GamePlayEvent>(GamePlay);
        EventManager.Instance.AddListener<GameOverEvent>(GameOver);
        EventManager.Instance.AddListener<GameVictoryEvent>(GameVictory);
    }
    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<GameMenuEvent>(GameMenu);
        EventManager.Instance.RemoveListener<GamePlayEvent>(GamePlay);
        EventManager.Instance.RemoveListener<GameOverEvent>(GameOver);
        EventManager.Instance.RemoveListener<GameVictoryEvent>(GameVictory);
    }

	private void OnEnable()
	{
		SubscribeEvents();
	}

	private void OnDisable()
	{
		UnsubscribeEvents();
	}

    private void Awake() 
    {
        m_AllPanels.AddRange(new GameObject[] { m_MenuPanel, m_VictoryPanel, m_GameOverPanel, m_PausePanel });
    }

    void DisplayPanel(GameObject panelGO)
    {
        foreach (var item in m_AllPanels) item.SetActive(item == panelGO);
    }

    void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    void GameMenu(GameMenuEvent e)
    {
        DisplayPanel(m_MenuPanel);
    }

    public void GamePlay(GamePlayEvent e)
    {
        DisplayPanel(null);
    }

    void GameOver(GameOverEvent e)
    {
        DisplayPanel(m_GameOverPanel);
    }

    void GameVictory(GameVictoryEvent e)
    {
        DisplayPanel(m_VictoryPanel);
    }

    public void PlayButtonHasBeenClicked()
    {
        EventManager.Instance.Raise(new PlayButtonClickedEvent());
        ClosePanel(m_MenuPanel);
    }

    public void QuitButtonHasBeenClicked()
    {
        EventManager.Instance.Raise(new QuitButtonClickedEvent());
		Application.Quit();
    }

    public void MenuButtonHasBeenClicked()
    {
        EventManager.Instance.Raise(new MainMenuButtonClickedEvent());
        DisplayPanel(m_PausePanel);
    }
}
