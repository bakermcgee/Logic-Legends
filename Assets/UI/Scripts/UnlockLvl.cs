using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLvl : MonoBehaviour
{

    public GameObject play;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("TutorLevel") >= this.transform.GetSiblingIndex()){
            play.SetActive(true);
        } else {
            play.SetActive(false);
        }      
    }

    
}
