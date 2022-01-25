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
    }

    void Jump(){
        if(!grounded && transform.position.z < 2) {
            grounded = true;
        }
        // Commande Sauter
        if (Input.GetButton("Jump"))
        {
            rigidbodyInstance.velocity = new Vector3(0f, m_jumpForce, 0f);
            grounded = false;
        }
    }
}
