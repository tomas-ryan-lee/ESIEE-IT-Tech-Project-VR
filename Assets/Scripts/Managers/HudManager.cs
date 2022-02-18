using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SDD.Events;

public class HudManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI m_ScoreText;
    float m_Score;

    public GameObject[] ennemiesLevel;
    public int ennemiesLevelLength;

    void SubscribeEvents()
    {
        EventManager.Instance.AddListener<GameStatisticsChangedEvent>(GameStatisticsChanged);
    }

	public void UnsubscribeEvents()
	{
		EventManager.Instance.RemoveListener<GameStatisticsChangedEvent>(GameStatisticsChanged);
	}

	private void OnEnable()
	{
		SubscribeEvents();
	}

	private void OnDisable()
	{
		UnsubscribeEvents();
	}

    void InitScoreUI(int score){
        ennemiesLevel = GameObject.FindGameObjectsWithTag("Enemy");
        ennemiesLevelLength = ennemiesLevel.Length;
        m_ScoreText.text = "Ennemis vaincus : " + score + "/" + ennemiesLevelLength.ToString();
    }

    void GameStatisticsChanged(GameStatisticsChangedEvent e)
    {
        InitScoreUI(e.eEnnemiesDefeated);
    }
}
