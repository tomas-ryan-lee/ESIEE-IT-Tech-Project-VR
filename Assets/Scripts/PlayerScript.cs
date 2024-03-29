using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region Variables
    public static PlayerScript instancePlayer;
    [Header("Life Points Setup")]
    [SerializeField] public int m_Life = 3;
    public GameObject[] m_LifePoints;

    [Header("Invulnerability Setup")]
    private bool m_isInvincible = false;
    [SerializeField] public float m_InvincibilityDurationSeconds = 1.5f;

    [Header("Damages Setup")]
    [SerializeField] public GameObject BloodScreen;

    [Header("Weapons Setup")]
    [SerializeField] GameObject m_weaponPoint;
    [SerializeField] GameObject[] m_weaponsList;
    GameObject m_weaponPrefab;
    float m_MunitionsWeapon;
    float m_MunitionsChargerWeapon;

    [Header("Shield Setup")]
    [SerializeField] GameObject m_shield;
    #endregion

    #region Commons
    private void Awake() {
        instancePlayer = this;
    }

    private void Start() {
        // Mise en place de l'arme par défaut
        Instantiate(m_weaponsList[0], m_weaponPoint.transform);
        // Désactivation du bouclier par défaut
        Shield(false);
    }

    private void Update() {
        // Activation du Shield
        if (Input.GetButtonDown("Hide"))
        {
            Shield(true);
        }
        if (Input.GetButtonUp("Hide"))
        {
            Shield(false);
        }

        // Rechargement de l'arme
        if (Input.GetButtonUp("Submit"))
        {
            ReloadWeapon();
        }
    }
    #endregion

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

    #region Weapons
    public void ChangeWeapon(int selectedWeapon){
        Instantiate(m_weaponsList[selectedWeapon], m_weaponPoint.transform);
    }

    public void ReloadWeapon()
    {
        m_weaponPrefab = GameObject.FindWithTag("Weapon");
        m_MunitionsWeapon = m_weaponPrefab.GetComponent<Shoot>().m_Munitions;
        m_MunitionsChargerWeapon = m_weaponPrefab.GetComponent<Shoot>().m_Munitions;
        m_MunitionsWeapon = m_MunitionsChargerWeapon;
        Debug.Log("Rechargé");
    }
    #endregion

    #region Shield
    private void Shield(bool activateStat)
    {
        m_shield.SetActive(activateStat);
        m_isInvincible = true;
    }
    #endregion
}
