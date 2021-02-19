using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class UIDucksCounter : MonoBehaviour
{
    public TMP_Text _Text;

    private void Awake()
    {
        _Text = GetComponent<TMP_Text>();
    }

    public void ChangeCounter(int c)
    {
        _Text.text = $"{c}/4";
    }
}
