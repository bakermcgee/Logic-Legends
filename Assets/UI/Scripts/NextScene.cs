using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour {

    public string scn;
    public bool darkMode;
    public bool mouseMode;
    bool st = true;

    void Start() {

        try {

            darkMode = PlayerPrefs.GetInt("DarkMode") == 1 ? true : false;
            mouseMode = PlayerPrefs.GetInt("MouseMode") == 1 ? true : false;

            this.transform.GetChild(1).gameObject
                .transform.GetChild(1).gameObject
                .GetComponent<UnityEngine.UI.Toggle>().isOn = darkMode;

            this.transform.GetChild(1).gameObject
                .transform.GetChild(2).gameObject
                .GetComponent<UnityEngine.UI.Toggle>().isOn = mouseMode;

        } catch {

        }

        st = false;

    }

    public void NewCirc() {

        bool tutorMode = false;
        PlayerPrefs.SetInt("TutorMode", tutorMode ? 1 : 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(scn);
    
    }

    public void TutorialMode() {

        bool tutorMode = true;
        PlayerPrefs.SetInt("TutorMode", tutorMode ? 1 : 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(scn);

    }

    public void ToggleDark() {

        if (!st) { 
            darkMode = !darkMode;
            PlayerPrefs.SetInt("DarkMode", darkMode ? 1 : 0);
            PlayerPrefs.Save();
        }

    }

    public void ToggleMouse() {

        if (!st) {
            mouseMode = !mouseMode;
            PlayerPrefs.SetInt("MouseMode", mouseMode ? 1 : 0);
            PlayerPrefs.Save();
        }

    }

}
