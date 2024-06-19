using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game_manager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int game_score ;
    // Start is called before the first frame update
    void Start()
    {
        game_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText();
    }

    public void scoreText()
    {
        score.text = "score : " + game_score;
    }
    public void plus_score()
    {
        game_score++;
    }

    public float getScore()
    {
        return game_score;
    }
}
