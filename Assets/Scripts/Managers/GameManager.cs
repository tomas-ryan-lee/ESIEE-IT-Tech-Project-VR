using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public enum GameState
{
    menu, initLevel, play, pause, gameover, victory
}

public class GameManager : MonoBehaviour
{
    static GameManager m_Instance;
    public static GameManager Instance { get {
        return m_Instance; } }
    GameState m_State;
    public bool IsPlaying { get { return m_State == GameState.play; } }
    public bool HasThePlayerWon(int score, int VictoryScore)
    {
        return score >= VictoryScore;
    }

    int m_Score;
	[SerializeField] int m_VictoryScore;
	float m_Countdown;
	[SerializeField] float m_GameDuration;

    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<PlayButtonClickedEvent>(PlayButtonClicked);
        EventManager.Instance.AddListener<MainMenuButtonClickedEvent>(MainMenuButtonClicked);
    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<PlayButtonClickedEvent>(PlayButtonClicked);
        EventManager.Instance.RemoveListener<MainMenuButtonClickedEvent>(MainMenuButtonClicked);
    }

	private void OnEnable()
	{
		SubscribeEvents();
	}

	private void OnDisable()
	{
		UnsubscribeEvents();
	}

	void Start()
    {
		SetAndBroadcastScoreAndTime(0, m_GameDuration);
        Menu();
    }

    void Update()
    {
        if(IsPlaying)
		{
			SetAndBroadcastScoreAndTime(m_Score, Mathf.Max(0, m_Countdown - Time.deltaTime));
			if (m_Countdown == 0)
			    GameOver();
		}
    }


    void SetAndBroadcastState(GameState State)
    {
        m_State = State;
		switch (m_State)
		{
			case GameState.menu:
				EventManager.Instance.Raise(new GameMenuEvent());
				break;
			case GameState.play:
				EventManager.Instance.Raise(new GamePlayEvent());
				break;
			case GameState.pause:
				EventManager.Instance.Raise(new GamePauseEvent());
				break;
			case GameState.gameover:
				EventManager.Instance.Raise(new GameOverEvent());
				break;
			case GameState.victory:
				EventManager.Instance.Raise(new GameVictoryEvent());
				break;
			default:
				break;
		}
    }

    void SetAndBroadcastScoreAndTime(int score, float time)
    {
        m_Score = score;
		m_Countdown = time;
		EventManager.Instance.Raise(new GameStatisticsChangedEvent() { eEnnemiesDefeated = m_Score, eCountdown = m_Countdown });
    }

    void Menu()
    {
        SetAndBroadcastState(GameState.menu);
    }

	void InitLevel()
	{
		SetAndBroadcastState(GameState.initLevel);
	}

    void GameOver()
    {
        SetAndBroadcastState(GameState.gameover);
    }


    // Events' callbacks
	void PlayButtonClicked(PlayButtonClickedEvent e)
	{
		InitLevel();
	}

	public void QuitButtonClicked(QuitButtonClickedEvent e)
	{
		Application.Quit();
	}

	void MainMenuButtonClicked(MainMenuButtonClickedEvent e)
	{
		SetAndBroadcastState(GameState.menu);
	}
}