using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableThisEnableThat : MonoBehaviour
{
    [SerializeField] private GameObject disableThis;
    [SerializeField] private GameObject enableThat;

    public void DisableThisEnableThatFunction()
    {
        if (disableThis != null & enableThat != null)
        {
            disableThis.SetActive(false);
            enableThat.SetActive(true);
        }
    }
}


