using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if(other.collider.tag == "Player")
            Destroy(gameObject);
    }
}
