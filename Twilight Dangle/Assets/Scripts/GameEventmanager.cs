using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventmanager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPaused = false;
    private bool isDead = false;
    private int totalCollectibles;
    public GameObject pauseMenuUI; 
    public GameObject deathScreen;
    public GameObject winScreen;

    void Start()
    {
        totalCollectibles = GameObject.FindGameObjectsWithTag("Rewards").Length; 
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead) return;  

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    public void PlayerDied()
    {
        isDead = true;
        deathScreen.SetActive(true); 
        Time.timeScale = 0f;
    }

    public void WinGame(){
        winScreen.SetActive(true);
        Time.timeScale = 0f;
        isDead = true;
    }
}
