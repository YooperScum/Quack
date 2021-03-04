using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int _sceneIndex = 0;
    public void Change()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}