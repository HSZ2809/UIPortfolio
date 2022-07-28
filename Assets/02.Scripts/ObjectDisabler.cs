using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    // public method
    public void DisableObject()
    {
        this.gameObject.SetActive(false);
    }
}
