using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private void OnCollisionEnter(Collision Player) 
    {
        
    }

    private void OnCollisionStay(Collision Player) {
        HidingAction();
    }

    // Fonction Se cacher
    void HidingAction(){
        // Debug.Log("Collision détectée");
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Debug.Log("Protection activée");
        }
    }
}
