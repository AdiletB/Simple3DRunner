using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [HideInInspector]
    public float score;
    public Text scoreText;
    public GameObject player;

    private float bestScore;
    public Text gameOverScoreText;
    public Text bestScoreText;
    private bool isGameEnd = false;

    void Update()
    {
        if(!isGameEnd){
            score = player.transform.position.z;
            scoreText.text = score.ToString("0");
        }
        
    }
    public void SetBestScore(){
        isGameEnd = true; 
        if(!PlayerPrefs.HasKey("BestScore")){
            bestScore = PlayerPrefs.GetFloat("BestScore");
        }
        else{
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        if(bestScore < score){
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        gameOverScoreText.text += " " + ((int)score).ToString();
        bestScoreText.text += " " + ((int)bestScore).ToString();
    }
}
