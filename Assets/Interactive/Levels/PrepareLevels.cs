using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareLevels : MonoBehaviour
{

    public bool tutorMode;
    public int tutorLevel;

    // Start is called before the first frame update
    void Start() {
        
        if (PlayerPrefs.GetInt("TutorMode") == 1 ? true : false) {

            tutorMode = true;
            UpdLevel();
            

        } else {

            tutorMode = false;

        }
    }

    void UpdLevel() {

        try {

            tutorLevel = PlayerPrefs.GetInt("TutorLevel");

        }
        catch {

            tutorLevel = 0;
            PlayerPrefs.SetInt("TutorLevel", tutorLevel);
            PlayerPrefs.Save();

        }

    }



}
