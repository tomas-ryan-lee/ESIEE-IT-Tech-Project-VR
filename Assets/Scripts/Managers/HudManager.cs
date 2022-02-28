using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SDD.Events;

public class HudManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI m_ScoreText;
    public static HudManager instance;
    public int m_Score;
    public GameObject[] ennemiesLevel;
    public int ennemiesLevelLength;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        InitEnnemiesLength();
        InitScoreUI(0);
    }

    void InitEnnemiesLength(){
        ennemiesLevel = GameObject.FindGameObjectsWithTag("Enemy");
        ennemiesLevelLength = ennemiesLevel.Length;
    }

    void InitScoreUI(int score){
        m_ScoreText.text = "Ennemis vaincus : " + score + "/" + ennemiesLevelLength.ToString();
    }

    public void AddPointsToScore()
    {
        m_Score++;
        InitScoreUI(m_Score);
    }
}
