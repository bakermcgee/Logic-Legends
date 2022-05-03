using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.UI;

public class UserLogin : MonoBehaviour
{
    public GameObject suEM;
    public GameObject suUN;
    public GameObject suPW;
    public GameObject suCF;

    public GameObject liEM;
    public GameObject liPW;

    public GameObject err;
    public GameObject err2;
    public GameObject profileButton;

    private string email;
    private string username;
    private string password;
    private string confirmPW;

    bool startedAuth = false;
    bool startedNew = false;

    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

    //starts firebase and checks if user is already logged in
    void Awake() {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        if (auth.CurrentUser != null) {
            user = auth.CurrentUser;
            UpdateUI(true);
        }
    }

    //checks each frame for authentication of user to update UI
    void Update() {

        try {
            if (startedNew && (auth.CurrentUser != null)) {
                startedNew = false;

                Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
                    DisplayName = username,
                };

                user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                    if (task.IsCanceled) {
                        err.GetComponent<TextMeshProUGUI>().text = ("UpdateUserProfileAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted) {
                        err.GetComponent<TextMeshProUGUI>().text = ("UpdateUserProfileAsync encountered an error: " + task.Exception);
                        return;
                    }

                });
            }
        } catch { startedNew = true; startedAuth = true; }

        if (startedAuth) {
            if (auth.CurrentUser != null) {
                Debug.Log("works");
                startedAuth = false;
                ClearFields();
                UpdateUI(true);
            }
        }

    }

    //attempts to sign up a user for the first time when called
    public void SignUp() {

        email = suEM.GetComponent<TextMeshProUGUI>().text;
        username = suUN.GetComponent<TextMeshProUGUI>().text;
        password = suPW.GetComponent<TextMeshProUGUI>().text;
        confirmPW = suCF.GetComponent<TextMeshProUGUI>().text;
        startedNew = true;
        startedAuth = true;

        bool validInfo = true;
        bool success = false;

        try {
            var eml = new MailAddress(email);
        } catch {
            validInfo = false;
            err.GetComponent<TextMeshProUGUI>().text = "Error: Re-enter an email with a valid format.";
        }

        if (validInfo && !(username.Length > 4)) {
            validInfo = false;
            err.GetComponent<TextMeshProUGUI>().text = "Error: Username must be at least 5 characters in length.";
        }

        if (validInfo && !(password.Length > 7)) {
            validInfo = false;
            err.GetComponent<TextMeshProUGUI>().text = "Error: Password must be at least 8 characters in length.";
        }

        if (validInfo && !(password == confirmPW)) {
            validInfo = false;
            err.GetComponent<TextMeshProUGUI>().text = "Error: Passwords must match.";
        }

        if (validInfo) {
            auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
                if (task.IsCanceled) {
                    err.GetComponent<TextMeshProUGUI>().text = ("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    err.GetComponent<TextMeshProUGUI>().text = ("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                // Firebase user has been created.
                success = true;
                user = task.Result;
            });
            
            /*if (success && (user != null)) {
                Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
                    DisplayName = username,
                };

                user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                    if (task.IsCanceled) {
                        err.GetComponent<TextMeshProUGUI>().text = ("UpdateUserProfileAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted) {
                        err.GetComponent<TextMeshProUGUI>().text = ("UpdateUserProfileAsync encountered an error: " + task.Exception);
                        return;
                    }

                    
                    print("User profile updated successfully.");
                });

                ClearFields();
                UpdateUI(true);
            }*/

        }

    }

    //attempts to sign in a user
    public void Login() {

        startedAuth = true;
        email = liEM.GetComponent<TextMeshProUGUI>().text;
        password = liPW.GetComponent<TextMeshProUGUI>().text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled) {
                err.GetComponent<TextMeshProUGUI>().text = ("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                err.GetComponent<TextMeshProUGUI>().text = ("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);
            
        });

    }

    //signs out a user
    public void Logout() {
        auth.SignOut();
        UpdateUI(false);
    }

    //clears all text fields when called
    public void ClearFields() {
        suEM.GetComponent<TextMeshProUGUI>().text = "";
        suUN.GetComponent<TextMeshProUGUI>().text = "";
        suPW.GetComponent<TextMeshProUGUI>().text = "";
        suCF.GetComponent<TextMeshProUGUI>().text = "";
        liEM.GetComponent<TextMeshProUGUI>().text = "";
        liPW.GetComponent<TextMeshProUGUI>().text = "";
    }


    //changes the profile button depending on login status
    public void UpdateUI(bool loggedIn) {
        if(loggedIn) {
            profileButton.transform.GetChild(0).gameObject.SetActive(false);
            profileButton.transform.GetChild(1).gameObject.SetActive(true);
            profileButton.transform.GetChild(1).gameObject
                .transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = user.DisplayName;
            print(user.DisplayName);
        } else {
            profileButton.transform.GetChild(0).gameObject.SetActive(true);
            profileButton.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
