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
    public float sensitivity;


    void Start()
    {
        rigidbodyInstance = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hInput, vInput;
        hInput = Input.GetAxis("Mouse X");
        vInput = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(0, hInput * sensitivity, 0));
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
