using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLogic : MonoBehaviour
{

    public SpriteRenderer gates;
    public Sprite newGate;

    public GameObject lg;
    public GameObject inp1;
    public GameObject inp2;
    public GameObject outp;
    public GameObject reset;

    bool i1 = true;
    bool i2 = true;
    bool op = true;
    bool rs = true;


    public void selectGate() {

        gates.sprite = newGate;
        movePoints();
        Invoke("showGate", 0.15f);

    }

    void movePoints() {

        if (this.name == "AND") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 1.2f), (yPos + 0.43f), 0);
            inp2.transform.position = new Vector3((xPos - 1.2f), (yPos - 0.43f), 0);
            outp.transform.position = new Vector3((xPos + 1.2f), (yPos + 0.02f), 0);
            rs = false;


        } else if (this.name == "NAND") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 1.3f), (yPos + 0.43f), 0);
            inp2.transform.position = new Vector3((xPos - 1.3f), (yPos - 0.43f), 0);
            outp.transform.position = new Vector3((xPos + 1.3f), (yPos + 0.02f), 0);
            rs = false;

        } else if (this.name == "OR") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 1.1f), (yPos + 0.37f), 0);
            inp2.transform.position = new Vector3((xPos - 1.1f), (yPos - 0.32f), 0);
            outp.transform.position = new Vector3((xPos + 1.1f), (yPos + 0.02f), 0);
            rs = false;

        } else if (this.name == "NOR") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 1.2f), (yPos + 0.37f), 0);
            inp2.transform.position = new Vector3((xPos - 1.2f), (yPos - 0.32f), 0);
            outp.transform.position = new Vector3((xPos + 1.2f), (yPos + 0.02f), 0);
            rs = false;

        } else if (this.name == "XOR") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 1.1f), (yPos + 0.37f), 0);
            inp2.transform.position = new Vector3((xPos - 1.1f), (yPos - 0.32f), 0);
            outp.transform.position = new Vector3((xPos + 1.1f), (yPos + 0.02f), 0);
            rs = false;

        } else if (this.name == "Node") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 1.05f), (yPos + 0.0008f), 0);
            i2 = false;
            outp.transform.position = new Vector3((xPos + 1.05f), (yPos + 0.0008f), 0);
            rs = false;

        } else if (this.name == "Inverter") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 1.05f), (yPos + 0.0008f), 0);
            i2 = false;
            outp.transform.position = new Vector3((xPos + 1.05f), (yPos + 0.03f), 0);
            rs = false;

        } else if (this.name == "Battery") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            i1 = false;
            i2 = false;
            outp.transform.position = new Vector3((xPos + 1.05f), (yPos - 0.02f), 0);
            rs = false;

        } else if (this.name == "Ground") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 1f), (yPos - 0.02f), 0);
            i2 = false;
            op = false;
            rs = false;

        } else if (this.name == "Button") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            i1 = false;
            i2 = false;
            outp.transform.position = new Vector3((xPos + 1.2f), (yPos - 0.09f), 0);
            rs = false;

        } else if (this.name == "Switch") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            i1 = false;
            i2 = false;
            outp.transform.position = new Vector3((xPos + 1.05f), (yPos - 0.5f), 0);
            rs = false;

        } else if (this.name == "Counter") {
            
            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 1.1f), (yPos + 0.15f), 0);
            i2 = false;
            outp.transform.position = new Vector3((xPos + 1.1f), (yPos + 0.14f), 0);
            reset.transform.position = new Vector3((xPos - 0.01f), (yPos - 1f), 0);

        } else if (this.name == "Timer") {
            
            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 1.1f), (yPos + 0.15f), 0);
            i2 = false;
            outp.transform.position = new Vector3((xPos + 1.1f), (yPos + 0.14f), 0);
            reset.transform.position = new Vector3((xPos - 0.01f), (yPos - 1f), 0);

        } else if (this.name == "Light") {

            float xPos = lg.transform.position.x;
            float yPos = lg.transform.position.y;
            inp1.transform.position = new Vector3((xPos - 0.8f), (yPos - 0.9f), 0);
            i2 = false;
            op = false;
            rs = false;

        }

    }

    void showGate() {
        gates.enabled = true;
    
        if (i1) inp1.SetActive(true);
        if (i2) inp2.SetActive(true);
        if (op) outp.SetActive(true);
        if (rs) reset.SetActive(true);

    }

}
