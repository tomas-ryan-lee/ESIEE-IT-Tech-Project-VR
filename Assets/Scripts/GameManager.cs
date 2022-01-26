using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Score Setup")]
    [SerializeField] public GameObject Score;
    public int ScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.GetComponent<TMPro.TextMeshProUGUI>().text = "Score : " + ScoreUI;
    }
}
