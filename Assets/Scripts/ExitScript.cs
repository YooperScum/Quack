using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public GameObject gameOverWin = null;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<DuckMovement>())
        {
            if (collision.gameObject.GetComponent<DuckMovement>().ducklingStack.Count == 4)
            {
                StartCoroutine(EndGame());
            }
        }
    }

    IEnumerator EndGame()
    {
        FindObjectOfType<DuckMovement>().enabled = false;
        gameOverWin.SetActive(true);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }
}
