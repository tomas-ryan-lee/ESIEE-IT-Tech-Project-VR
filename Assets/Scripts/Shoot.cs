using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Shoot Setup")]
    [SerializeField] Transform m_SpawnPosition;
    [SerializeField] float m_CoolDownDuration;
    float m_NextShootTime;

    [Header("Projectile Setup")]
    [SerializeField] GameObject m_ProjectilePrefab;
    [SerializeField] float m_ProjectileInitSpeed;
    [SerializeField] float m_ProjectileLifeDuration;

    // Start is called before the first frame update
    void Start()
    {
        m_NextShootTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Fonction Tirer
        ShootBullet();
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
        bool isFiring = Input.GetButton("Fire");
        if (isFiring && Time.time> m_NextShootTime)
        {
            Destroy(ShootProjectile(), m_ProjectileLifeDuration); // la destruction a lieu en fin de frame ... pas immédiatement !
            m_NextShootTime = Time.time + m_CoolDownDuration;
        }
    }



    /** FONCTIONS DE BOUCLIER
    ---------------------------------------------**/
    
}
