using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Shoot Setup")]
    [SerializeField] Transform m_SpawnPosition;
    [SerializeField] float m_CoolDownDuration;
    float m_NextShootTime;

    [Header("Projectile Setup")]
    [SerializeField] GameObject m_ProjectilePrefab;
    [SerializeField] float m_ProjectileInitSpeed;
    [SerializeField] float m_ProjectileLifeDuration;

    [Header("Life Setup")]
    [SerializeField] GameObject m_Bullet;
    [SerializeField] float m_LifePoints = 4;

    [Header("Score Setup")]
    [SerializeField] public int ScoreAdd;
    [SerializeField] public int SpeedWalk;
    int ScoreUI;

    [Header("Movements Setup")]
    [SerializeField] private bool movingLeft;

    private void Start() {
        ScoreUI = 0;
        movingLeft = true;
    }

    void Update()
    {
        // Mouvement de l'ennemi
    }



    /** FONCTIONS DE COLLISION ET DE DESTRUCTION
    ---------------------------------------------**/
    private void OnCollisionExit(Collision m_Bullet) {
        m_LifePoints--;
        DestroyEnemy();
    }

    void DestroyEnemy(){
        if(m_LifePoints < 1){
            Destroy(gameObject);
        }
    }



    /** FONCTIONS DE TIR
    ---------------------------------------------**/
    GameObject ShootProjectile()
	{
        GameObject newBallGO = Instantiate(m_ProjectilePrefab);
        newBallGO.transform.position = m_SpawnPosition.position;
        newBallGO.GetComponent<Rigidbody>().velocity = m_SpawnPosition.transform.forward * m_ProjectileInitSpeed;
        return newBallGO;
	}

    void ShootBullet(){
        Destroy(ShootProjectile(), m_ProjectileLifeDuration); // la destruction a lieu en fin de frame ... pas immédiatement !
        m_NextShootTime = Time.time + m_CoolDownDuration;
    }
}
