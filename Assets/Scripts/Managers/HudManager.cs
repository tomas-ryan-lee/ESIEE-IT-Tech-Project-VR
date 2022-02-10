using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SDD.Events;

public class HudManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI m_ScoreText;
    float m_Score;

    #region Events subscription
    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<GameScorePlayerChangedEvent>(GameScorePlayerChanged);
    }
    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<GameScorePlayerChangedEvent>(GameScorePlayerChanged);
    }
	private void OnEnable()
	{
		SubscribeEvents();
	}
	private void OnDisable()
	{
		UnsubscribeEvents();
	}
    #endregion

    void Start()
    {
        m_ScoreText.text = "Score : " + m_Score.ToString();
    }

    private void GameScorePlayerChanged(GameScorePlayerChangedEvent e)
    {
        m_Score = m_Score + e.eScore;
        m_ScoreText.text = "Score : " + m_Score.ToString();
    }
}
