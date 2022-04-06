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
        
    }

    void Update()
    {
        
    }
}
