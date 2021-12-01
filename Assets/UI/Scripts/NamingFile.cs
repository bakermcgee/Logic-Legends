using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NamingFile : MonoBehaviour
{

    public GameObject gates;

    public void changeName() {

        gates.GetComponent<SaveData>().changeName(this.gameObject.GetComponent<TMP_InputField>().text);
        this.gameObject.GetComponent<TMP_InputField>().text = "";

    }

    public void keepName() {

        gates.GetComponent<SaveData>().changeName(this.gameObject.GetComponent<TextMeshProUGUI>().text);

    }

}
