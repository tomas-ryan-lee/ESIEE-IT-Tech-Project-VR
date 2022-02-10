using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI m_ScoreText;
    float m_Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_ScoreText.text = "Score : " + m_Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
