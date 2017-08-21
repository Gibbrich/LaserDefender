using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private Text text;

    private static int score;
    
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Score(int score)
    {
        ScoreKeeper.score += score;
        text.text = ScoreKeeper.score.ToString();
    }

    public static void ResetScore()
    {
        score = 0;
    }
}