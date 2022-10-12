using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnRoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
