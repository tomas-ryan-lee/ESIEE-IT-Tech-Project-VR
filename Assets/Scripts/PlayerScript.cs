using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int m_Life = 3;
    public GameObject[] m_LifePoints;

    // Update is called once per frame
    private void Start() {
        Debug.Log(m_LifePoints.Length);
    }

    private void TakeDamage() {
        m_Life--;
        Destroy(m_LifePoints[m_Life].gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "EnemyBullet")
            TakeDamage();
    }
}
