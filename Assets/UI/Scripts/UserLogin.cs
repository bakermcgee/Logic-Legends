using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Storage;
using Firebase.Database;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UserLogin : MonoBehaviour
{
    //sign up info
    public GameObject suEM;
    public GameObject suUN;
    public GameObject suPW;
    public GameObject suCF;

    //login info
    public GameObject liEM;
    public GameObject liPW;
    public GameObject newUser;
    public GameObject newIcon;
    
    //error messages for sign up and sign in pages
    public GameObject err;
    public GameObject err2;
    public GameObject err3;
    //objects that will be toggled on successful submit
    public GameObject profileButton;
    public GameObject loginBox;
    public GameObject signUpBox;
    public GameObject loginScreen;
    public GameObject titleScn;
    public GameObject particles;
    public GameObject changeUser;
    public GameObject profUN;
    public GameObject profScn;

    private string email;
    private string username;
    private string password;
    private string confirmPW;
    private string path;
    public Image usrIcon;
    public Image usrIcon2;

    bool startedAuth = false;
    bool startedNew = false;
    bool authed = false;

    public int localLvl;

    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    DatabaseReference refer;


    //starts firebase and checks if user is already logged in
    void Awake() {
        localLvl = PlayerPrefs.GetInt("TutorLevel");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        refer = FirebaseDatabase.DefaultInstance.RootReference;
        if (auth.CurrentUser != null) {
            user = auth.CurrentUser;
            authed = true;
            UpdateUI(true);
            UpdateLvl();
        }
    }

    //checks each frame for authentication of user to update UI
    void Update() {
        
        //sets the username upon new account creation
        try {
            if (startedNew && (auth.CurrentUser != null)) {
                startedNew = false;

                refer.Child("users").Child(user.UserId).Child("username").SetValueAsync(username);
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

        //checks for a successful login and updates the UI if so
        if (startedAuth) {
            if (auth.CurrentUser != null) {

                err2.GetComponent<TextMeshProUGUI>().text = "";
                authed = true;
                startedAuth = false;
                UpdateUI(true);
                UpdateLvl();

            } else {
                err2.GetComponent<TextMeshProUGUI>().text = "Login encountered an error: Enter a valid email and password combination.";
            }
        }

        //checks to make sure the UI is completely updated
        try {
            if (authed && profileButton.transform.GetChild(1).gameObject
                    .transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text != user.DisplayName) {

                UpdateUI(true);

            }
        }catch { }

    }

    //attempts to sign up a user for the first time when called
    public void SignUp() {

        email = suEM.GetComponent<TMP_InputField>().text;
        username = suUN.GetComponent<TMP_InputField>().text;
        password = suPW.GetComponent<TMP_InputField>().text;
        confirmPW = suCF.GetComponent<TMP_InputField>().text;
        startedNew = true;
        startedAuth = true;

        bool validInfo = true;

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

        if (validInfo && password.Contains(username)) {
            validInfo = false;
            err.GetComponent<TextMeshProUGUI>().text = "Error: Username and password must be unique.";
        }

        if (validInfo && password.Contains(email)) {
            validInfo = false;
            err.GetComponent<TextMeshProUGUI>().text = "Error: Email and password must be unique.";
        }

        if (validInfo && !(password.Length > 7)) {
            validInfo = false;
            err.GetComponent<TextMeshProUGUI>().text = "Error: Password must be at least 8 characters in length.";
        }

        if (validInfo && !(password == confirmPW)) {
            validInfo = false;
            err.GetComponent<TextMeshProUGUI>().text = "Error: Passwords must match.";
        }

        //attempts to create a new user if valid info is given
        if (validInfo) {
            auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
                if (task.IsCanceled) {
                    err.GetComponent<TextMeshProUGUI>().text = ("Sign up was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    err.GetComponent<TextMeshProUGUI>().text = ("Sign up encountered an error: " + task.Exception);
                    return;
                }

                user = task.Result;
            });

        }

    }

    //attempts to sign in a user
    public void Login() {

        startedAuth = true;
        email = liEM.GetComponent<TMP_InputField>().text;
        print(liEM.GetComponent<TMP_InputField>().text);
        password = liPW.GetComponent<TMP_InputField>().text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.Log("Login was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.Log("Login error: " + task.Exception);
                return;
            }

            user = task.Result;
            
        });

    }

    //signs out a user
    public void Logout() {
        auth.SignOut();
        authed = false;
        //UpdateUI(false);
    }

    //clears all text fields when called
    public void ClearFields() {
        suEM.GetComponent<TMP_InputField>().text = "";
        suUN.GetComponent<TMP_InputField>().text = "";
        suPW.GetComponent<TMP_InputField>().text = "";
        suCF.GetComponent<TMP_InputField>().text = "";
        liEM.GetComponent<TMP_InputField>().text = "";
        liPW.GetComponent<TMP_InputField>().text = "";
    }


    //changes the profile button depending on login status
    public void UpdateUI(bool loggedIn) {
        if(loggedIn) {
            profileButton.transform.GetChild(0).gameObject.SetActive(false);
            profileButton.transform.GetChild(1).gameObject.SetActive(true);

            profileButton.SetActive(true);
            loginBox.SetActive(true);
            signUpBox.SetActive(false);
            loginScreen.SetActive(false);
            titleScn.SetActive(true);
            titleScn.transform.GetChild(1).gameObject.SetActive(true);
            titleScn.transform.GetChild(2).gameObject.SetActive(true);
            titleScn.transform.GetChild(3).gameObject.SetActive(true);
            titleScn.transform.GetChild(4).gameObject.SetActive(true);
            particles.SetActive(true);
            profScn.SetActive(false);
            ClearFields();

            try {
                profileButton.transform.GetChild(1).gameObject
                    .transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = user.DisplayName;
                profUN.GetComponent<TextMeshProUGUI>().text = user.DisplayName;
            } catch { }
            
            
        } else {
            profileButton.transform.GetChild(0).gameObject.SetActive(true);
            profileButton.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    //attempts to change the username when called
    public void ChangeUsername() {
        username = newUser.GetComponent<TMP_InputField>().text;
        bool validInfo = true;

        if (validInfo && !(username.Length > 4)) {
            validInfo = false;
            err3.GetComponent<TextMeshProUGUI>().text = "Error: Username must be at least 5 characters in length.";
        }

        if (validInfo && username == user.DisplayName) {
            validInfo = false;
            err3.GetComponent<TextMeshProUGUI>().text = "Error: New username must not match previous username.";
        }

        if (validInfo) {
            changeUser.SetActive(false);

            refer.Child("users").Child(user.UserId).Child("username").SetValueAsync(username);
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
                DisplayName = username,
            };

            user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                if (task.IsCanceled) {
                    Debug.Log("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.Log("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

            });
        }
    }

    public void UpdateLvl() {

        FirebaseDatabase.DefaultInstance
            .GetReference(("/users/" + user.UserId + "/level"))
            .GetValueAsync().ContinueWith(task => {
                if (task.IsFaulted) {
                    
                    Debug.Log("oops");

                } else if (task.IsCompleted) {

                    //print(task.Result);
                    DataSnapshot snapshot = task.Result;
                    int dbLvl = Convert.ToInt32(snapshot.Value);
                    
                    //print(localLvl +"");
                    if (dbLvl > localLvl) {
                        PlayerPrefs.SetInt("TutorLevel", dbLvl);
                        PlayerPrefs.Save();
                    } else {
                        refer.Child("users").Child(user.UserId).Child("level").SetValueAsync(localLvl);
                    }

                }
        });

    }

    //attempts to change the icon when called
    public void ChangeIcon() {
        
    }

}
