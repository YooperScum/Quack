using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform[] _cameraLocations = null;
    [SerializeField] private Camera _cam = null;
    [SerializeField] private GameObject _titleScreen = null;
    [SerializeField] private GameObject _menuScreen = null;
    [SerializeField] private GameObject _settingsScreen = null;
    [SerializeField] private Animator _transitionAnim = null;

    private bool _titleScreenTriggered = false;
    private bool _camIsPositioned = true;
    private Transform _nextLocation = null;
    private GameObject _nextScreen = null;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _titleScreen.SetActive(true);
        _menuScreen.SetActive(false);
        _settingsScreen.SetActive(false);

        _cam.transform.position = _cameraLocations[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_titleScreenTriggered && Input.anyKeyDown)
        {
            _titleScreen.SetActive(false);
            _nextScreen = _menuScreen;
            _titleScreenTriggered = true;
            _nextLocation = _cameraLocations[1];
            _camIsPositioned = false;
        }

        if(!_camIsPositioned)
        {
            _cam.transform.position = Vector3.Lerp(_cam.transform.position, _nextLocation.position, 2f*Time.deltaTime);
            if(Vector3.Distance(_cam.transform.position,_nextLocation.position) <= 0.2f)
            {
                _nextScreen.SetActive(true);
                _camIsPositioned = true;
            }
        }
    }

    //Button methods: 

    public void Play()
    {
        //Play Transition and change to the main game scene.
        _transitionAnim.gameObject.transform.parent.gameObject.SetActive(true);
        _transitionAnim.SetTrigger("Swipe");
    }
    public void SettingsToggle()
    {
        //If settings is not active, then move to that location and make it active else move to main menu area and make that active.
        if(!_settingsScreen.activeInHierarchy)
        {
            _menuScreen.SetActive(false);
            _nextScreen = _settingsScreen;
            _nextLocation = _cameraLocations[2];
            _camIsPositioned = false;
        }
        else
        {
            _settingsScreen.SetActive(false);
            _nextScreen = _menuScreen;
            _nextLocation = _cameraLocations[1];
            _camIsPositioned = false;
        }
    }
    public void Quit()
    {
        //Close application.
        Application.Quit();
    }
}
 