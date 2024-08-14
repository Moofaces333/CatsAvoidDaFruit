using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif



public class GameManager : MonoBehaviour
{
    // variables
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverTextScore;
    public Button restartButton;
    public Button quitButton;
    public int score;
    public int incrementScore = 5;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(UpdateScore(incrementScore));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UpdateScore(int amount) {
        while (isGameActive) {
            score += amount;
            scoreText.text = "" + score;
            yield return new WaitForSeconds(1);
        }
    }
    public void StartGame() {

    }

    public void GameOver() {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameOverTextScore.text = "Your score is: " + score;
        gameOverTextScore.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

}
