using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelThree : MonoBehaviour
{
    public int lvlState;
    public GameObject gates;
    public GameObject blockers;
    public GameObject playB;
    public GameObject lvl;
    public GameObject circuit1;
    public GameObject circuit2;
    public GameObject circuit3;
    public GameObject circuit4;
    public GameObject tbA;
    public GameObject tbB;

    public GameObject swt1;
    public GameObject swt2;
    public GameObject bat1;
    public GameObject bat2;
    public GameObject inv1;
    public GameObject nnd1;
    public GameObject nor1;
    public GameObject nod1;
    public GameObject and1;
    public GameObject cnt1;
    public GameObject lit1;
    public GameObject grd1;

    public GameObject pointA;
    public GameObject pointB;

    // Update checks for which lvlState the player is on
    void Update() {

        // this switch works similar to a FSM; when the conditions are met within a level, move to the next state
        switch (lvlState) {

            case 0:
                if (gates.GetComponent<PlaceLogic>().gateClones.Count > 4) {
                    grd1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    bat1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    bat2 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    and1 = gates.GetComponent<PlaceLogic>().gateClones[3];
                    inv1 = gates.GetComponent<PlaceLogic>().gateClones[4];

                    pointA = bat1.transform.GetChild(3).gameObject;
                    pointB = and1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = bat2.transform.GetChild(3).gameObject;
                    pointB = and1.transform.GetChild(2).gameObject;
                    connectWire();

                    pointA = and1.transform.GetChild(3).gameObject;
                    pointB = inv1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = inv1.transform.GetChild(3).gameObject;
                    pointB = grd1.transform.GetChild(1).gameObject;
                    connectWire();

                    playB.GetComponent<PlayMode>().play = true;
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

                    lvlState = 1;
                }
                break;

            case 1:
                if (circuit2.activeInHierarchy && gates.GetComponent<TrackWires>().wires.Count > 2 &&
                    gates.GetComponent<PlaceLogic>().gateClones[0].transform.GetChild(1)
                    .gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {

                    this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(4).gameObject.SetActive(true);

                    lvlState = 2;

                }
                break;

            case 2:
                if (!playB.GetComponent<PlayMode>().play) {
                    ToNOR();
                }
                break;

            case 3:
                if(gates.GetComponent<PlaceLogic>().gateClones.Count > 4) {
                    lit1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    swt1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    swt2 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    nor1 = gates.GetComponent<PlaceLogic>().gateClones[3];
                    nod1 = gates.GetComponent<PlaceLogic>().gateClones[4];

                    pointA = swt1.transform.GetChild(3).gameObject;
                    pointB = nod1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nod1.transform.GetChild(3).gameObject;
                    pointB = nor1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = swt2.transform.GetChild(3).gameObject;
                    pointB = nor1.transform.GetChild(2).gameObject;
                    connectWire();

                    pointA = nor1.transform.GetChild(3).gameObject;
                    pointB = lit1.transform.GetChild(1).gameObject;
                    connectWire();

                    this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(5).gameObject.SetActive(true);

                    playB.GetComponent<PlayMode>().play = true;

                    lvlState = 4;
                }
                break;

            case 4:
                if (circuit4.activeInHierarchy && gates.GetComponent<PlaceLogic>().gateClones.Count > 4) {
                    lit1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    cnt1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    cnt1.GetComponent<GateBehavior>().goal = 3;
                    cnt1.transform.GetChild(5).gameObject.GetComponent<TMP_Text>().text = "3";
                    cnt1.transform.GetChild(6).gameObject.SetActive(false);
                    and1 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    nnd1 = gates.GetComponent<PlaceLogic>().gateClones[3];
                    nor1 = gates.GetComponent<PlaceLogic>().gateClones[4];

                    pointA = cnt1.transform.GetChild(3).gameObject;
                    pointB = lit1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nor1.transform.GetChild(3).gameObject;
                    pointB = cnt1.transform.GetChild(4).gameObject;
                    connectWire();

                    pointA = and1.transform.GetChild(3).gameObject;
                    pointB = cnt1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nnd1.transform.GetChild(3).gameObject;
                    pointB = and1.transform.GetChild(1).gameObject;
                    connectWire();

                    tbB.SetActive(true);

                    lvlState = 5;
                }
                break;

            case 5:
                if (gates.GetComponent<PlaceLogic>().gateClones[0].transform.GetChild(1)
                    .gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {

                    this.gameObject.transform.GetChild(7).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(8).gameObject.SetActive(true);

                    lvlState = 6;

                }
                break;

            case 6:
                if (!playB.GetComponent<PlayMode>().play) {
                    ToEnd();
                }
                break;
        }

    }

    public void ToNAND() {

        gates.GetComponent<PlaceLogic>().ClearScreen();
        playB.GetComponent<PlayMode>().play = false;
        circuit1.SetActive(false);

        circuit2.SetActive(true);
        circuit2.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();

        blockers.transform.GetChild(3).gameObject.SetActive(false);
        blockers.transform.GetChild(0).gameObject.SetActive(false);
        blockers.transform.GetChild(5).gameObject.SetActive(false);
        blockers.transform.GetChild(6).gameObject.SetActive(false);
        blockers.transform.GetChild(8).gameObject.SetActive(false);
        blockers.transform.GetChild(9).gameObject.SetActive(false);

        tbA.SetActive(true);

    }

    void ToNOR() {
        lvlState = 3;
        gates.GetComponent<PlaceLogic>().ClearScreen();

        //this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
        //this.gameObject.transform.GetChild(5).gameObject.SetActive(true);
        blockers.transform.GetChild(0).gameObject.SetActive(true);

        circuit2.SetActive(false);
        tbA.SetActive(false);

        circuit3.SetActive(true);
        circuit3.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();
    }

    public void ToChallenge() {

        this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
        gates.GetComponent<PlaceLogic>().ClearScreen();
        playB.GetComponent<PlayMode>().play = false;

        blockers.transform.GetChild(0).gameObject.SetActive(true);
        blockers.transform.GetChild(0).gameObject.SetActive(false);
        blockers.transform.GetChild(5).gameObject.SetActive(false);
        blockers.transform.GetChild(6).gameObject.SetActive(false);
        blockers.transform.GetChild(8).gameObject.SetActive(false);
        blockers.transform.GetChild(9).gameObject.SetActive(false);

        circuit3.SetActive(false);

        circuit4.SetActive(true);
        circuit4.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();

    }

    void ToEnd() {
        gates.GetComponent<PlaceLogic>().ClearScreen();
        tbB.SetActive(false);
        circuit4.SetActive(false);

        PlayerPrefs.SetInt("TutorLevel", 4);
        PlayerPrefs.Save();
        this.gameObject.transform.GetChild(8).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(9).gameObject.SetActive(true);
    }

    public void restart() {
        lvlState = 0;
        blockers.transform.GetChild(3).gameObject.SetActive(false);
        lvl.SetActive(true);

        circuit1.SetActive(true);
        circuit1.transform.GetChild(1).gameObject.SetActive(false);
        circuit1.transform.GetChild(2).gameObject.SetActive(false);
        circuit1.transform.GetChild(3).gameObject.SetActive(false);
        circuit1.transform.GetChild(4).gameObject.SetActive(false);
        circuit1.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();

        circuit2.SetActive(false);
        circuit2.transform.GetChild(1).gameObject.SetActive(false);
        circuit2.transform.GetChild(2).gameObject.SetActive(false);
        
        circuit3.SetActive(false);
        circuit3.transform.GetChild(1).gameObject.SetActive(false);
        circuit3.transform.GetChild(2).gameObject.SetActive(false);
        circuit3.transform.GetChild(3).gameObject.SetActive(false);
        circuit3.transform.GetChild(4).gameObject.SetActive(false);

        circuit4.SetActive(false);
        circuit4.transform.GetChild(1).gameObject.SetActive(false);
        circuit4.transform.GetChild(2).gameObject.SetActive(false);
        circuit4.transform.GetChild(3).gameObject.SetActive(false);
        circuit4.transform.GetChild(4).gameObject.SetActive(false);
        tbB.SetActive(false);
    }

    void connectWire() {

        pointA.GetComponent<PlaceWire>().loadWire(pointB);
        pointB.GetComponent<CircleCollider2D>().enabled = false;

    }

}
