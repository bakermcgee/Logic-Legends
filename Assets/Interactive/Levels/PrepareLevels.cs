using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareLevels : MonoBehaviour
{

    public bool tutorMode;
    public int tutorLevel;

    public GameObject lvlSelect;
    public GameObject lvlUI;
    public GameObject freeBar;
    public GameObject tutorBar;
    public GameObject help;

    //checks playerprefs to see if the tutorial was chosen and what level player is on
    //if on the tutorial, the level UI is activated and if the highest level reached is greater than 0,
    //it sends the player to the level select. otherwise, it will automatically play level 0 for new players
    void Start() {
        
        if (PlayerPrefs.GetInt("TutorMode") == 1 ? true : false) {

            tutorMode = true;
            UpdLevel();
            lvlUI.SetActive(true);
            freeBar.SetActive(false);
            tutorBar.SetActive(true);

            if(tutorLevel == 0) {
                lvlUI.transform.GetChild(1).gameObject.SetActive(true);
            } else if(tutorLevel > 0) {
                lvlSelect.SetActive(true);
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
