using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovements : MonoBehaviour
{
    [Header("Bezier Curve Setup")]
    [SerializeField] List<Transform> m_CtrlTransforms;
    [SerializeField] int m_NbPtsOnSpline;
    [SerializeField] bool m_IsClosed;
    [SerializeField] float m_PtsDensity;

    [Header("Movement Setup")]
    [SerializeField] float m_TranslationSpeed;
    [SerializeField] float m_RotationSpeed;
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
        // Fonction Déplacements
        transform.Translate(Vector3.forward * m_TranslationSpeed * Time.fixedDeltaTime * vInput);
        // Fonction Rotation
        transform.Rotate(Vector3.up * m_RotationSpeed * Time.fixedDeltaTime * hInput);
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
