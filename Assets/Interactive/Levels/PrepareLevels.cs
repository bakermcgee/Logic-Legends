using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareLevels : MonoBehaviour
{

    public bool tutorMode;
    public int tutorLevel;

    public GameObject lvlUI;
    public GameObject freeBar;
    public GameObject tutorBar;
    public GameObject help;

    // Start is called before the first frame update
    void Start() {
        
        if (PlayerPrefs.GetInt("TutorMode") == 1 ? true : false) {

            tutorMode = true;
            UpdLevel();
            lvlUI.SetActive(true);
            freeBar.SetActive(false);
            tutorBar.SetActive(true);

            if(tutorLevel == 0) {
                lvlUI.transform.GetChild(1).gameObject.SetActive(true);
            }

            //help.SetActive(false);

        } else {

            tutorMode = false;
            freeBar.SetActive(true);

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
