using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] public GameObject DoorToOpen;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            DoorToOpen.GetComponent<Animator>().enabled = true;
            Destroy(this);
        }
    }
}
