using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject toggled;
    public bool moverOn = false;

    // Called when the button is pressed
    public void OnButtonPress() {

        toggled.SetActive(!toggled.activeInHierarchy);
        moverOn = !moverOn;

    }

    public void ForceOff() {

        toggled.SetActive(true);
        moverOn = false;

    }
}
