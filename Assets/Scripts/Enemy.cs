using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Life Setup")]
    [SerializeField] GameObject m_Bullet;
    [SerializeField] float m_LifePoints = 4;

    [Header("Score Setup")]
    [SerializeField] public int SpeedWalk;

    [Header("Movements Setup")]
    [SerializeField] Transform Player;
    [SerializeField] float MoveSpeed;
    [SerializeField] float MinDist;
    [SerializeField] float MaxDist;

    private void Update() {
        FollowPlayer();
    }


    /** FONCTIONS DE MOUVEMENTS
    ---------------------------------------------**/
    private void FollowPlayer(){
        transform.LookAt(Player);
        // L'ennemi est loin du joueur
        if (Vector3.Distance(transform.position,Player.position) >= MinDist)
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
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
}
