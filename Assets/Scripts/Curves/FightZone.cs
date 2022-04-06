using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZone : MonoBehaviour
{
    public GameObject Starter;
    public Transform nodeLocation;
    [SerializeField]
    public string EnemyTagCibled;

    void Start ()
    {
        /*var gos = GameObject[];
        gos = GameObject.FindGameObjectsWithTag("EnemyZone1");*/
        Debug.Log(GameObject.FindGameObjectsWithTag("EnemyZone1").Length);
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag(EnemyTagCibled) == null)
        {
            Instantiate(Starter, nodeLocation.position, nodeLocation.rotation);
            Destroy(gameObject);
        }

    }
}
