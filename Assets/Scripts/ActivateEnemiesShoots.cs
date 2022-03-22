using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemiesShoots : MonoBehaviour
{
    public static float EnnemiesDestroyed;
    public static ActivateEnemiesShoots instance;
    [SerializeField] public GameObject[] EnnemiesList;
    [SerializeField] public float EnnemiesToDestroy;

    private void Awake() {
        GameObject m_GOEnemy = GameObject.FindWithTag("Enemy");
        instance = this;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            foreach (var enemy in EnnemiesList)
            {
                enemy.GetComponent<Enemy>().ActivateShoot = true;
            }
            other.GetComponent<PlayerMovements>().m_MovesetsBlocked = true;
        }
        Destroy(gameObject);
    }

    public void AddPointsToEnnemiesDestroyed(){
        EnnemiesDestroyed++;
        EnablePlayerMovesets();
    }

    void EnablePlayerMovesets()
    {
        if (EnnemiesToDestroy == EnnemiesDestroyed)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovements>().m_MovesetsBlocked = false;
            //Destroy(this);
        }
    }
}
