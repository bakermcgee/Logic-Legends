using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTwo : MonoBehaviour {
    public int lvlState;
    public GameObject gates;
    public GameObject blockers;
    public GameObject playB;
    public GameObject lvl1;
    public GameObject circuit1;
    public GameObject circuit2;
    public GameObject circuit3;
    public GameObject circuit4;
    public GameObject tbA;
    public GameObject tbB;

    public GameObject bat1;
    public GameObject bat2;
    public GameObject and1;
    public GameObject grd1;
    public GameObject nod1;
    public GameObject lit1;
    public GameObject inv1;
    public GameObject swt1;
    public GameObject tmr1;

    public GameObject pointA;
    public GameObject pointB;

    // Start sets up variable defaults
    /*void Start() {
        restart();
    }*/

    // Update checks for which lvlState the player is on
    void Update() {

        switch (lvlState) {

            case 0:
                if (gates.GetComponent<PlaceLogic>().gateClones.Count > 3) {
                    grd1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    bat1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    bat2 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    and1 = gates.GetComponent<PlaceLogic>().gateClones[3];

                    pointA = bat1.transform.GetChild(3).gameObject;
                    pointB = and1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = bat2.transform.GetChild(3).gameObject;
                    pointB = and1.transform.GetChild(2).gameObject;
                    connectWire();

                    pointA = and1.transform.GetChild(3).gameObject;
                    pointB = grd1.transform.GetChild(1).gameObject;
                    connectWire();

                    lvlState = 1;
                }
                break;

            case 1:
                if (gates.GetComponent<PlaceLogic>().gateClones.Count > 4) {
                    //this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    grd1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    bat1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    bat2 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    and1 = gates.GetComponent<PlaceLogic>().gateClones[3];
                    nod1 = gates.GetComponent<PlaceLogic>().gateClones[4];

                    pointA = bat1.transform.GetChild(3).gameObject;
                    pointB = nod1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nod1.transform.GetChild(3).gameObject;
                    pointB = and1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = and1.transform.GetChild(3).gameObject;
                    pointB = grd1.transform.GetChild(1).gameObject;
                    connectWire();

                    ToDrawing();
                }
                break;

            case 2:
                if (grd1.transform.GetChild(1)
                    .gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {
                    this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                    ToSuccessA();
                }
                break;

            case 3:
                if (grd1.transform.GetChild(1)
                    .gameObject.GetComponent<SpriteRenderer>().color != new Color(1f, 0.984f, 0.447f, 1f)) {
                    this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
                    ToInverter();
                }
                break;

            case 4:
                /*if (gates.GetComponent<PlaceLogic>().gateClones[1].transform.GetChild(3)
                    .gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {
                    this.gameObject.transform.GetChild(6).gameObject.SetActive(false);
                    //ToOr();
                }*/
                if (gates.GetComponent<PlaceLogic>().gateClones.Count > 2) {
                    lit1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    inv1 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    swt1 = gates.GetComponent<PlaceLogic>().gateClones[1];

                    pointA = inv1.transform.GetChild(3).gameObject;
                    pointB = lit1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = swt1.transform.GetChild(3).gameObject;
                    pointB = inv1.transform.GetChild(1).gameObject;
                    connectWire();
                    this.gameObject.transform.GetChild(5).gameObject.SetActive(true);
                    lvlState = 5;
                }
                break;

            case 5:
                /*try {
                    if (gates.GetComponent<PlaceLogic>().gateClones[3].transform.GetChild(3)
                        .gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {
                        this.gameObject.transform.GetChild(5).gameObject.SetActive(false);
                        ToSuccessB();
                    }
                } catch { }*/
                if (lit1.transform.GetChild(1)
                    .gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {
                    this.gameObject.transform.GetChild(6).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(7).gameObject.SetActive(true);
                    lvlState = 6;
                }
                break;

            case 6:
                if (!playB.GetComponent<PlayMode>().play) {
                    this.gameObject.transform.GetChild(7).gameObject.SetActive(false);
                    ToInverter2();
                }
                break;

            case 7:
                if (gates.GetComponent<PlaceLogic>().gateClones.Count > 5) {
                    lit1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    bat1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    bat2 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    tmr1 = gates.GetComponent<PlaceLogic>().gateClones[3];
                    tmr1.GetComponent<GateBehavior>().goal = 2;
                    //tmr1.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = "2";
                    //tmr1.transform.GetChild(6).gameObject.SetActive(false);
                    nod1 = gates.GetComponent<PlaceLogic>().gateClones[4];
                    and1 = gates.GetComponent<PlaceLogic>().gateClones[5];

                    pointA = and1.transform.GetChild(3).gameObject;
                    pointB = lit1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nod1.transform.GetChild(3).gameObject;
                    pointB = and1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = bat1.transform.GetChild(3).gameObject;
                    pointB = nod1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = bat2.transform.GetChild(3).gameObject;
                    pointB = tmr1.transform.GetChild(1).gameObject;
                    connectWire();

                    this.gameObject.transform.GetChild(8).gameObject.SetActive(true);
                    lvlState = 8;
                }
                break;

            case 8:
                if(gates.GetComponent<PlaceLogic>().gateClones.Count > 5 && gates.GetComponent<TrackWires>().wires.Count > 5 && playB.GetComponent<PlayMode>().play) {
                    this.gameObject.transform.GetChild(8).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(9).gameObject.SetActive(true);
                    lvlState = 9;
                }
                break;

            case 9:
                if (!playB.GetComponent<PlayMode>().play) {
                    lvlState = 10;
                    ToEnd();
                }
                break;
        }
    }

    void ToDrawing() {
        lvlState = 2;
        //blockers.transform.GetChild(3).gameObject.SetActive(true);
        blockers.transform.GetChild(0).gameObject.SetActive(false);
        blockers.transform.GetChild(5).gameObject.SetActive(false);
        blockers.transform.GetChild(6).gameObject.SetActive(false);
        blockers.transform.GetChild(8).gameObject.SetActive(false);
        blockers.transform.GetChild(9).gameObject.SetActive(false);
        //this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

    void ToSuccessA() {
        lvlState = 3;
        this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }

    public void ToNode() {
        gates.GetComponent<PlaceLogic>().ClearScreen();
        circuit1.SetActive(false);
        //tbA.SetActive(false);
        circuit2.SetActive(true);
        circuit2.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();
        //tbB.SetActive(true);
        blockers.transform.GetChild(3).gameObject.SetActive(false);
    }

    void ToInverter(){
        lvlState = 4;
        gates.GetComponent<PlaceLogic>().ClearScreen();
        circuit2.SetActive(false);
        tbA.SetActive(false);

        circuit3.SetActive(true);
        circuit3.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();

        tbB.SetActive(true);
    }

    void ToInverter2() {
        lvlState = 7;
        gates.GetComponent<PlaceLogic>().ClearScreen();
        circuit3.SetActive(false);

        circuit4.SetActive(true);
        circuit4.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();

    }

    void ToEnd() {
        gates.GetComponent<PlaceLogic>().ClearScreen();
        tbB.SetActive(false);
        circuit4.SetActive(false);

        PlayerPrefs.SetInt("TutorLevel", 3);
        PlayerPrefs.Save();
        this.gameObject.transform.GetChild(9).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(10).gameObject.SetActive(true);
    }

    public void restart() {
        lvlState = 0;
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        blockers.transform.GetChild(3).gameObject.SetActive(false);
        lvl1.SetActive(true);
        circuit1.SetActive(true);
        circuit1.transform.GetChild(1).gameObject.SetActive(false);
        circuit1.transform.GetChild(2).gameObject.SetActive(false);
        circuit1.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();
        tbA.SetActive(true);

        circuit2.SetActive(false);
        circuit2.transform.GetChild(1).gameObject.SetActive(false);
        circuit2.transform.GetChild(2).gameObject.SetActive(false);
        circuit2.transform.GetChild(3).gameObject.SetActive(false);
        circuit2.transform.GetChild(4).gameObject.SetActive(false);

        circuit3.SetActive(false);
        circuit3.transform.GetChild(1).gameObject.SetActive(false);
        circuit3.transform.GetChild(2).gameObject.SetActive(false);

        circuit4.SetActive(false);
        circuit4.transform.GetChild(1).gameObject.SetActive(false);
        circuit4.transform.GetChild(2).gameObject.SetActive(false);
        circuit4.transform.GetChild(3).gameObject.SetActive(false);
        circuit4.transform.GetChild(4).gameObject.SetActive(false);
        circuit4.transform.GetChild(5).gameObject.SetActive(false);
        tbB.SetActive(false);
    }

    void connectWire() {

        pointA.GetComponent<PlaceWire>().loadWire(pointB);
        pointB.GetComponent<CircleCollider2D>().enabled = false;

    }
}
