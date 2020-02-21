using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameController : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject player;
    private ScoreController scoreController;
    private PlayerController playerController;
    // Start is called before the first frame update
    private void Start() {
        scoreController = GetComponent<ScoreController>();
        playerController = player.GetComponent<PlayerController>();
    }
    public void EndGame(){
        gameOverMenu.SetActive(true);
        scoreController.SetBestScore();
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu(){
        SceneManager.LoadScene(1);
    }
    public void Boost(int duration)
    {
        float oldSpeed = playerController.GetDefaultSpeed();        
        float boostSpeed = oldSpeed + 300;
        SetPlayerSpeed(boostSpeed);

        Debug.Log("SpeedBost: "+playerController.GetSpeed());

        var callback = new TimerCallback(SetPlayerSpeed);
        var timer = new Timer(callback, oldSpeed, duration, 0);
    }
    private void SetPlayerSpeed(object speed)
    {
        playerController.SetSpeed((float)speed);
         Debug.Log("Speed set: "+playerController.GetSpeed());

    }
}
