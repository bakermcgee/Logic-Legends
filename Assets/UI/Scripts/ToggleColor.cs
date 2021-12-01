using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleColor : MonoBehaviour
{

    bool colorOn = false;
    
    public void OnButtonPress() {

        colorOn = !colorOn;
        if (colorOn) {
            this.gameObject.GetComponent<Image>().color = new Color(0.353f, 0.353f, 0.353f, 1f);
        } else {
            this.gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }

    }

    public void ForceOff() {

        colorOn = false;
        if (colorOn) {
            this.gameObject.GetComponent<Image>().color = new Color(0.353f, 0.353f, 0.353f, 1f);
        } else {
            this.gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }

    }

}
