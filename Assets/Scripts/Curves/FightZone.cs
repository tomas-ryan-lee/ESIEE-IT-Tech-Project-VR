using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZone : MonoBehaviour
{
    public GameObject Starter;
    public Transform nodeLocation;
    private float ennemiesToDestroy;
    [SerializeField]
    public float ennemiesDestroyed;

    void Start ()
    {

    }
    void Update()
    {
        if (ennemiesToDestroy == ennemiesDestroyed)
        {
            Instantiate(Starter, nodeLocation.position, nodeLocation.rotation);
            Destroy(gameObject);
        }

    }
}
