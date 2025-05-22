using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private int ScoreInt;
    public TMP_Text ScoreText;

    public void ScorePlusOne()
    {
        ScoreInt++;
    }

    private void Update()
    {
        ScoreText.text = ScoreInt.ToString();
    }
}
