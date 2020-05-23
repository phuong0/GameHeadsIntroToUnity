using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public TMPro.TMP_Text score;

    private int currentPlayerScore = 0;

    public void changeTheScore()
    {
        currentPlayerScore++;
        score.text = currentPlayerScore.ToString();
    }
}
