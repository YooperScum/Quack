using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private Image[] _notches = null;
    [SerializeField] private FloatVar _floatVolume = null;
    private int _volume = 0;

    public int Volume
    {
        get { return _volume; }
        set 
        { 
            _volume = value;
            int num = _volume;
            _floatVolume.Value = _volume/20f;
            PlayerPrefs.SetFloat("volume", _floatVolume.Value);
            foreach (Image img in _notches)
            {
                if(num != 0)
                {
                    img.fillCenter = true;
                    num--;
                }
                else
                {
                    img.fillCenter = false;
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume")) PlayerPrefs.SetFloat("volume", 0.5f);
        _floatVolume.Value = PlayerPrefs.GetFloat("volume");
        Volume = Mathf.RoundToInt(_floatVolume.Value * 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume(bool add)
    {
        if (add)
        {
            if(Volume < _notches.Length) Volume++;
        }
        else
        {
            if(Volume > 0) Volume--;
        }
    }
}
