using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkBelt : MonoBehaviour
{
    // Start is called before the first frame updat
    void Start() {
        if (PlayerPrefs.GetInt("DarkMode") == 1 ? true : false) {
            this.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
        }
    }

}
