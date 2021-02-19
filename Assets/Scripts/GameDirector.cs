using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
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
            Application.Quit();
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
}
