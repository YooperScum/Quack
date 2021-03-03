using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField] BoolVar isPaused;
    [SerializeField] GameObject pauseMenu;

    private int brothersToWin = 4;
    private int currentBrothers = 0;
    private GameObject player;
    private GameObject sewerExit;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sewerExit = GameObject.Find("SewerExit");

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused.Value == true)
            {
                isPaused.Value = false;
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
            else
            {
                isPaused.Value = true;
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }
    }

    void FixedUpdate()
    {
        currentBrothers = player.GetComponent<DuckMovement>().ducklingStack.Count;
        if (currentBrothers == brothersToWin)
        {
            Destroy(sewerExit);
        }
    }

    public void Unpause()
    {
        if (isPaused.Value == true)
        {
            isPaused.Value = false;
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
