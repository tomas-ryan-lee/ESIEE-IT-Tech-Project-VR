using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Enemy : MonoBehaviour
{
    [Header("Life Setup")]
    [SerializeField] GameObject m_Bullet;
    [SerializeField] float m_LifePoints = 4;

    [Header("Score Setup")]
    [SerializeField] public int SpeedWalk;

    [Header("Movements Setup")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float MinDist;
    [SerializeField] float MaxDist;
    

	/** FONCTIONS DE COLLISION ET DE DESTRUCTION
    ---------------------------------------------**/
    private void OnCollisionEnter(Collision m_Bullet) 
    {
        DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        m_LifePoints--;
        if(m_LifePoints < 1){
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        HudManager.instance.AddPointsToScore();
    }
}
