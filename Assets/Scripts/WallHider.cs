using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHider : MonoBehaviour
{
    private enum Direction
    {
        North,
        East,
        South,
        West
    }

    [SerializeField]
    TVar<int> _Direction;

    [SerializeField]
    Material _InvisibleMAT;

    [SerializeField]
    Direction _HideDirection;

    [SerializeField]
    float _DelayDuration = 2f;

    private Material[] _OriginalMats;
    private Material[] _InvisibleMats;
    private Renderer _Rend;

    private void Awake()
    {
        _Rend = GetComponent<Renderer>();
        _OriginalMats = _Rend.materials;

        _InvisibleMats = new Material[_OriginalMats.Length];

        for (int i = 0; i < _OriginalMats.Length; i++)
        {
            Debug.Log(_OriginalMats[i].name);
            if (_OriginalMats[i].name == "Techo (Instance)" || _OriginalMats[i].name == "Pared (Instance)" || _OriginalMats[i].name == "Borde_Pared (Instance)")
            {
                Debug.Log("Entro");
                _InvisibleMats[i] = _InvisibleMAT;
            }
            else
            {
                _InvisibleMats[i] = _OriginalMats[i];
            }
        }
    }

    private void OnEnable()
    {
        _Direction.Observers += OnVarChanged;
        OnVarChanged(_Direction.Value);
    }

    private void OnDisable()
    {
        _Direction.Observers -= OnVarChanged;
    }

    private void OnVarChanged(int value)
    {
        if (value == (int)_HideDirection)
        {
            StartCoroutine(ChangeMaterials(_InvisibleMats));
        }
        else
        {
            StartCoroutine(ChangeMaterials(_OriginalMats));
        }
    }

    IEnumerator ChangeMaterials(Material[] mats)
    {
        yield return new WaitForSeconds(_DelayDuration);
        _Rend.materials = mats;
    }
}
