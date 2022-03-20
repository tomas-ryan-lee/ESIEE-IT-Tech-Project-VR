using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemiesShoots : MonoBehaviour
{

    [SerializeField] public GameObject[] EnnemiesList;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            foreach (var enemy in EnnemiesList)
            {
                enemy.GetComponent<Enemy>().ActivateShoot = true;
            }
        }
        Debug.Log("Fonction active");
    }
}
