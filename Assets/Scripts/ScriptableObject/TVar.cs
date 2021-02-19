using UnityEngine;
using System;
using UnityEngine.Events;

[System.Serializable]
public abstract class TVar<T> : ScriptableObject, ISerializationCallbackReceiver
{

    [SerializeField]
    private T _initialValue;

    [SerializeField]
    private T _value;

    public event Action<T> Observers;

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            NotifyObservers();
        }
    }

    public void NotifyObservers()
    {
        Observers?.Invoke(_value);
    }

    public void OnAfterDeserialize()
    {
        _value = _initialValue;
    }

    public void OnBeforeSerialize()
    {
    }

}