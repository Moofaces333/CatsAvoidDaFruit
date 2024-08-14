using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // variables 
    private GameManager gameManager;
    private Animator playerAnim;
    private void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Obstacle")) {
            //Destroy(gameObject);
            playerAnim.SetTrigger("death_Trig");
            StartCoroutine(waitFor3Seconds());
            
            // GameManager Set Game Over
            gameManager.GameOver();
        }
    }

    IEnumerator waitFor3Seconds() {
        yield return new WaitForSecondsRealtime(3.1f);
        gameObject.SetActive(false);
    }
}
