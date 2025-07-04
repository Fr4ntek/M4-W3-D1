using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PauseMenu;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject canvas;

    public enum GAME_STATE { PLAYING, PAUSED };
    public GAME_STATE GameState { get; private set; }
    
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void Resume()
    {
        if (!canvas.activeSelf)
        {
            canvas.SetActive(true);
            GameState = GAME_STATE.PAUSED;
            Time.timeScale = 0;
        }
        else
        {
            canvas.SetActive(false);
            GameState = GAME_STATE.PLAYING;
            Time.timeScale = 1;
        }
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu-Es1");
    }
}
