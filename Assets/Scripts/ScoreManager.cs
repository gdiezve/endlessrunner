using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public CharacterController character;
    public TextMeshProUGUI text;
    public TextMeshProUGUI finalText;
    int score = 0;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore (int point) 
    {
        if (!character.isDead) {
            score += point;
            text.text = "SCORE " + score.ToString();
            finalText.text = "YOUR SCORE " + score.ToString();
        }
    }

    public int GetScore() {
        return this.score;
    }
}
