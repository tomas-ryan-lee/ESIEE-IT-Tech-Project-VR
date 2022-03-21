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
    public bool m_MovesetsBlocked = false;
    Rigidbody rigidbodyInstance;

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
        if (!m_MovesetsBlocked)
        {
            // Fonction Déplacements
            transform.Translate(Vector3.forward * m_TranslationSpeed * Time.fixedDeltaTime * vInput);
        }
        
    }

    /*void ProtectAgainEnemyAttacks(){
        bool isHiding = Input.GetButton("Hide");
        if(isHiding)
        {
            m_Protection = true;
        }    
        else
        {
            m_Protection = false;
        } 
    }*/
}
