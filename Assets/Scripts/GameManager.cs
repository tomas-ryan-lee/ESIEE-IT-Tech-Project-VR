namespace STUDENT_NAME{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        [Header("Score Setup")]
        [SerializeField] public GameObject Score;
        public int ScoreUI;

        void Update()
        {
            Score.GetComponent<TMPro.TextMeshProUGUI>().text = "Score : " + ScoreUI;
        }
    }
}
