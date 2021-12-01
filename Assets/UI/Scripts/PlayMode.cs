using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMode : MonoBehaviour
{

    public bool play = false;
    public GameObject pageOn;

    // Called when the button is pressed
    public void OnButtonPress() {

        pageOn.SetActive(!pageOn.activeInHierarchy);
        print(!pageOn.activeInHierarchy);
        play = !play;

        if (play) {
            this.gameObject.GetComponent<Image>().color = new Color(1f, 0.1f, 0.3f, 1f);
        } else {
            this.gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }

    }

}
