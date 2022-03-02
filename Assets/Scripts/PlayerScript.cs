using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject[] m_LifePoints;
    public int m_Life;

    // Update is called once per frame
    void Update()
    {
        if(m_Life < 1)
            Debug.Log("GameOver");
    }

    public void TakeDamage(int d)
    {
        m_Life -= d;
    }
}
