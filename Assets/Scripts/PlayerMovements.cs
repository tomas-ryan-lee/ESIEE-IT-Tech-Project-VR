using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovements : MonoBehaviour
{
    [Header("Movement Setup")]
    [SerializeField] float m_RotationSpeed;
    [SerializeField] float m_RotationSpeedKeyboard;
    public Vector3 point;

    void Update()
    {
        PlayerRotation();
    }

    private void PlayerRotation()
    {
        float h = m_RotationSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);

        if (Input.GetKey("right") || Input.GetKey("d"))
            transform.Rotate(Vector3.up * m_RotationSpeedKeyboard * Time.deltaTime);
        else if (Input.GetKey("left") || Input.GetKey("q"))
            transform.Rotate(-Vector3.up * m_RotationSpeedKeyboard * Time.deltaTime);
        
    }
}
