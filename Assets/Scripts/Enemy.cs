using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject m_Bullet;
    [SerializeField] float m_LifePoints = 4;

    [Header("Score Setup")]
    [SerializeField] public GameObject Score;
    [SerializeField] public int ScoreAdd;
    public int ScoreUI;

    private void Start() {
        ScoreUI = 0;
    }

    private void OnCollisionExit(Collision m_Bullet) {
        ScoreUI = ScoreUI + ScoreAdd;
        m_LifePoints--;
        DestroyEnemy();
    }

    void DestroyEnemy(){
        if(m_LifePoints < 1){
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Score.GetComponent<TMPro.TextMeshProUGUI>().text = "Score : " + ScoreUI;
    }
}
