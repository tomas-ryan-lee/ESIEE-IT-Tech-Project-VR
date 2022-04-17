using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Enemy : MonoBehaviour
{
    [Header("Life Setup")]
    [SerializeField] GameObject m_Bullet;
    [SerializeField] float m_LifePoints = 3;

    [Header("Shoot Setup")]
    [SerializeField] public bool m_ActivateShoot;
    [SerializeField] public Transform target;

    [Header("Movements Setup")]
    [SerializeField] public int SpeedWalk;
    [SerializeField] float MoveSpeed;
    [SerializeField] float MinDist;
    [SerializeField] float MaxDist;

    [Header("Gifts Setup")]
    [SerializeField] bool newWeapon;
    [SerializeField] int selectedWeapon;

    [Header("Shoot Setup")]
    float m_NextShootTime;
    [SerializeField] Transform m_SpawnPosition;
    [SerializeField] float m_CoolDownDuration;
    [SerializeField] public float m_WaitBeforeShootSeconds;
    bool m_canFire = true;

    [Header("Projectile Setup")]
    [SerializeField] GameObject m_ProjectilePrefab;
    [SerializeField] float m_ProjectileInitSpeed;
    [SerializeField] float m_ProjectileLifeDuration;

    private void Awake() {
        StartCoroutine(WaitBeforeShoot());
    }

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
        if (newWeapon == true)
        {
            PlayerScript.instancePlayer.ChangeWeapon(selectedWeapon);
        }
    }
    

	/** FONCTIONS DE TIR
    ---------------------------------------------**/
    private IEnumerator WaitBeforeShoot()
    {
        while(m_canFire){
            Debug.Log("Peut pas tirer");
            m_ActivateShoot = false;
            yield return new WaitForSeconds(m_WaitBeforeShootSeconds);
            m_ActivateShoot = true;
            ShootBullet();
            Debug.Log("Peut tirer");
        }
    }

    GameObject ShootProjectile()
	{
            GameObject newBallGO = Instantiate(m_ProjectilePrefab);
            newBallGO.transform.position = m_SpawnPosition.position;
            newBallGO.GetComponent<Rigidbody>().velocity = m_SpawnPosition.transform.forward * m_ProjectileInitSpeed;
            return newBallGO;    
	}

    void ShootBullet(){
        if (m_ActivateShoot && Time.time> m_NextShootTime)
        {
            Destroy(ShootProjectile(), m_ProjectileLifeDuration); // la destruction a lieu en fin de frame ... pas immédiatement !
            m_NextShootTime = Time.time + m_CoolDownDuration;
        }
    }
}
