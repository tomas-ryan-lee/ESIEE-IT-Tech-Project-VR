using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Life Points Setup")]
    [SerializeField] public int m_Life = 3;
    public GameObject[] m_LifePoints;

    [Header("Invulnerability Setup")]
    private bool m_isInvincible = false;
    [SerializeField] public float m_InvincibilityDurationSeconds = 1.5f;

    [Header("Damages Setup")]
    [SerializeField] public GameObject BloodScreen;

    #region Damages
    private void OnCollisionEnter(Collision other) 
    {
        if(other.collider.tag == "EnemyBullet")
            TakeDamage();
    }

    private void TakeDamage() 
    {
        if (m_isInvincible) return;

        m_Life--;
        Destroy(m_LifePoints[m_Life].gameObject);

        StartCoroutine(BecomeTemporarilyInvincible());
        StartCoroutine(ShowBloodScreen());
    }

    void MethodThatTriggersInvulnerability()
    {
        if(!m_isInvincible)
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        m_isInvincible = true;

        yield return new WaitForSeconds(m_InvincibilityDurationSeconds);

        m_isInvincible = false;
        Debug.Log("Player is no longer invincible!");
    }

    private IEnumerator ShowBloodScreen()
    {
        Debug.Log("Je saigne !");
        BloodScreen.SetActive(true);

        yield return new WaitForSeconds(m_InvincibilityDurationSeconds);
        
        BloodScreen.SetActive(false);
        Debug.Log("Je saigne plus !");
    }
    #endregion
}
