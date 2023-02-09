using UnityEngine;

public class DDOL : MonoBehaviour
{
    void Start()
    {
        if(FindObjectsOfType<DDOL>().Length > 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
}