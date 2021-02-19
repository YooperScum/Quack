using UnityEngine;
using UnityEngine.Events;

public abstract class OnTVarChanged<T> : MonoBehaviour
{
    [SerializeField]
    protected TVar<T> _TObj;

    public UnityEvent<T> Actions;

    [SerializeField]
    protected bool _NotifyOnEnable = false;

    protected void OnEnable()
    {
        if (_TObj == null)
        {
            return;
        }

        _TObj.Observers += TriggerActions;

        if (_NotifyOnEnable)
        {
            TriggerActions(_TObj.Value);
        }
    }

    protected void OnDisable()
    {
        if (_TObj == null)
        {
            return;
        }

        _TObj.Observers -= TriggerActions;
    }

    public void TriggerActions(T val)
    {
        Actions.Invoke(val);
    }
}
