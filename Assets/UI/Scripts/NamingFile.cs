using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NamingFile : MonoBehaviour
{

    public GameObject gates;
    public GameObject sB;

    public void changeName() {

        gates.GetComponent<SaveData>().changeName(this.gameObject.GetComponent<TMP_InputField>().text);
        this.gameObject.GetComponent<TMP_InputField>().text = "";

    }

    public void keepName() {

        gates.GetComponent<SaveData>().changeName(this.gameObject.GetComponent<TextMeshProUGUI>().text);

    }

    public void keepNameCloud() {

        sB.GetComponent<SaveGUIController>().uploadSave(this.gameObject.GetComponent<TextMeshProUGUI>().text);

    }

    public void deleteFile() {

        gates.GetComponent<SaveData>().deleteName(this.gameObject.GetComponent<TextMeshProUGUI>().text);
    
    }

}
