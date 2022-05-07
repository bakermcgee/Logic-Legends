using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudUploadAppear : MonoBehaviour
{

    public GameObject button;
    Firebase.Auth.FirebaseAuth auth;
    bool loggedIn = false;

    void Awake() {

        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

    }

    // Update is called once per frame
    void Update()
    {
        if (auth.CurrentUser != null) {
            loggedIn = true;
        } else {
            loggedIn = false;
        }

        if (loggedIn && !button.activeInHierarchy) {
            button.SetActive(true);
        } else if (!loggedIn && button.activeInHierarchy) {
            button.SetActive(false);
        }
    }
}
