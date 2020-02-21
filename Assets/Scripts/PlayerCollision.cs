using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;
    private GameController gameManager;
    public int count;
    public int boostDurationInMsc = 3000;

    private void Start() {
        gameManager = FindObjectOfType<GameController>();
        playerController = player.GetComponent<PlayerController>();
    }
    private void Update() {
        if(transform.position.y < -1){
            gameManager.EndGame();
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Obstacle"){
            gameManager.EndGame();
            playerController.enabled = false;
        }
        if(other.collider.tag == "Booster"){
            gameManager.Boost(boostDurationInMsc);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Coin")
        {
            count++;
            Destroy(other.gameObject);
        }
    }
}
