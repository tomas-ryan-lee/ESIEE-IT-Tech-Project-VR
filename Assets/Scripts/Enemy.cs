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
    [SerializeField] public int SpeedWalk;
    public int ScoreUI;
    [SerializeField] private bool movingLeft;

    private void Start() {
        ScoreUI = 0;
        movingLeft = true;
    }

    void Update()
    {
        Score.GetComponent<TMPro.TextMeshProUGUI>().text = "Score : " + ScoreUI;
        if (movingLeft == true) {
            transform.Translate(Vector3.left * SpeedWalk * Time.deltaTime, Space.World);
            if (transform.position.x <= -6) movingLeft = false;
        } else {
            transform.Translate(Vector3.right * SpeedWalk * Time.deltaTime, Space.World);
            if (transform.position.x >= 6) movingLeft = true;
        }
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
}
