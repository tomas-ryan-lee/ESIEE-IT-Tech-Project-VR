using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Enemy : MonoBehaviour
{

    public ActivateEnemiesShoots activateEnemiesShoots;
    [Header("Life Setup")]
    [SerializeField] GameObject m_Bullet;
    [SerializeField] float m_LifePoints = 3;

    [Header("Shoot Setup")]
    [SerializeField] public bool ActivateShoot;
    [SerializeField] public Transform target;

    [Header("Movements Setup")]
    [SerializeField] public int SpeedWalk;
    [SerializeField] float MoveSpeed;
    [SerializeField] float MinDist;
    [SerializeField] float MaxDist;

	private void Update() {
        if(target != null)
        {
            transform.LookAt(target);
        }
    }
    

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
        ActivateEnemiesShoots.instance.AddPointsToEnnemiesDestroyed();
    }
}
