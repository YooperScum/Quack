using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private Image[] _notches = null;
    private int _volume;

    public int Volume
    {
        get { return _volume; }
        set 
        { 
            _volume = value;
            int num = _volume;
            foreach(Image img in _notches)
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
