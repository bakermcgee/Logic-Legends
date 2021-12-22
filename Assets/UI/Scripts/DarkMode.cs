using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("DarkMode") == 1 ? true : false) {
            this.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
        }
    }

}
