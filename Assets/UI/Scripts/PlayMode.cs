using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMode : MonoBehaviour
{

    public bool play = false;
    public GameObject pageOn;
    public GameObject tb;
    public Sprite def;
    public Sprite stp;

    // Called when the button is pressed
    public void OnButtonPress() {

        pageOn.SetActive(!pageOn.activeInHierarchy);
        tb.SetActive(!tb.activeInHierarchy);
        play = !play;

        if (play) {
            this.gameObject.GetComponent<Image>().sprite = stp;
        } else {
            this.gameObject.GetComponent<Image>().sprite = def;
        }

    }

}
