using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("Movement Setup")]
    [SerializeField] float m_TranslationSpeed;
    [SerializeField] float m_RotationSpeed;
    Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float hInput, vInput;
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * m_RotationSpeed * Time.fixedDeltaTime * hInput);
        transform.Translate(Vector3.forward * m_TranslationSpeed * Time.fixedDeltaTime * vInput);
    }
}
