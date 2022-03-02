using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPointScript : MonoBehaviour
{
    [SerializeField] Transform m_TargetPoint;
    [SerializeField] EnemyMovement m_EnemyMoveset;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "EnemyBody")
            m_EnemyMoveset.target = m_TargetPoint;
    }
}
