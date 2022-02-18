using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("Movement Setup")]
    [SerializeField] float m_TranslationSpeed;
    [SerializeField] float m_RotationSpeed;
    [SerializeField] float m_jumpForce;
    public Vector3 m_jump;
    Rigidbody rigidbodyInstance;
    public bool grounded = true;

    [Header("Fight Setup")]
    [SerializeField] Transform m_Shield;
    public bool m_Protection = false;



    void Start()
    {
        rigidbodyInstance = GetComponent<Rigidbody>();
    }
 
    void FixedUpdate()
    {
        float hInput, vInput;
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Fonction Rotation
        transform.Rotate(Vector3.up * m_RotationSpeed * Time.fixedDeltaTime * hInput);
        // Fonction Déplacements
        transform.Translate(Vector3.forward * m_TranslationSpeed * Time.fixedDeltaTime * vInput);
        // Fonction Saut
        Jump();
        // Fonction Protection
        ProtectAgainEnemyAttacks();
    }

    void Jump(){
        // Détection du joueur au sol
        if(!grounded && transform.position.z < 2) {
            grounded = true;
        }
        // Commande Sauter
        if (Input.GetButtonUp("Jump"))
        {
            rigidbodyInstance.velocity = new Vector3(0f, m_jumpForce, 0f);
            grounded = false;
        }
    }

    void ProtectAgainEnemyAttacks(){
        bool isHiding = Input.GetButton("Hide");
        if(isHiding)
        {
            m_Protection = true;
        }    
        else
        {
            m_Protection = false;
        } 
    }
}
