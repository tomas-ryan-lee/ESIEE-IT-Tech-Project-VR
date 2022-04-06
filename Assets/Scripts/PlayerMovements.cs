using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovements : MonoBehaviour
{
    [Header("Movement Setup")]
    [SerializeField] float m_RotationSpeed;

    void Update()
    {
        PlayerRotation();
    }

    private void PlayerRotation()
    {
        float h = m_RotationSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
    }
}
