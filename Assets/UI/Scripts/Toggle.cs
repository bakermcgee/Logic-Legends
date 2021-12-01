using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject toggled;
    public bool moverOn = false;

    // Called when the button is pressed
    public void OnButtonPress() {

        try {
            toggled.SetActive(!toggled.activeInHierarchy);
        }
        catch { }
        moverOn = !moverOn;

    }

    public void ForceOff() {
        try {
            toggled.SetActive(true);
        }
        catch { }
        moverOn = false;

    }
}
