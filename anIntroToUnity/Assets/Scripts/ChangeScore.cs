using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScore : MonoBehaviour
{
    public TMPro.TMP_Text score;

    private int currentPlayerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changingScore()
    {
        currentPlayerScore++;
        score.text = currentPlayerScore.ToString();
    }
}
