using UnityEngine;

public class testingandy : MonoBehaviour
{
    [SerializeField]
    TVar<int> iii;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            iii.Value = iii.Value + 1;
        }
    }

    // public void Test(int v)
    // {
    //     Debug.Log(v);
    // }
}
