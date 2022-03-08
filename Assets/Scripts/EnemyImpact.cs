using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpact : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        StartCoroutine(ChangeColorOnHit());
    }

    private IEnumerator ChangeColorOnHit()
    {
        gameObject.GetComponent<Renderer> ().material.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<Renderer> ().material.color = Color.white;
    }
}
