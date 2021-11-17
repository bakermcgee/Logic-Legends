using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToPage : MonoBehaviour
{


    public GameObject pageOn;
    public GameObject pageOff;

    // Called when the button is pressed
    public void OnButtonPress(){

        if (!pageOn.activeInHierarchy){

            pageOn.SetActive(true);
            pageOff.SetActive(false);

        }

    }
}
