using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitEditor : MonoBehaviour
{
    public string scn;

    public void exitScn() {

        SceneManager.LoadScene(scn);

    }
}
