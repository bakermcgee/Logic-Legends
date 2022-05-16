using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelFour : MonoBehaviour
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

    public GameObject grd1;
    public GameObject bat1;
    public GameObject bat2;
    public GameObject swt1;
    public GameObject nod1;
    public GameObject nod2;
    public GameObject xor1;
    public GameObject xor2;
    public GameObject inv1;
    public GameObject inv2;
    public GameObject lit1;
    public GameObject cnt1;
    public GameObject tmr1;
    public GameObject and1;

    public GameObject pointA;
    public GameObject pointB;

    // Update checks for which lvlState the player is on
    void Update() {

        // this switch works similar to a FSM; when the conditions are met within a level, move to the next state
        switch (lvlState) { 
        
            case 0:
                if (gates.GetComponent<PlaceLogic>().gateClones.Count > 5) {
                    grd1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    bat1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    swt1 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    xor1 = gates.GetComponent<PlaceLogic>().gateClones[3];
                    nod1 = gates.GetComponent<PlaceLogic>().gateClones[4];
                    nod2 = gates.GetComponent<PlaceLogic>().gateClones[5];

                    pointA = xor1.transform.GetChild(3).gameObject;
                    pointB = grd1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nod1.transform.GetChild(3).gameObject;
                    pointB = xor1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nod2.transform.GetChild(3).gameObject;
                    pointB = xor1.transform.GetChild(2).gameObject;
                    connectWire();

                    pointA = bat1.transform.GetChild(3).gameObject;
                    pointB = nod1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = swt1.transform.GetChild(3).gameObject;
                    pointB = nod2.transform.GetChild(1).gameObject;
                    connectWire();

                    playB.GetComponent<PlayMode>().play = true;
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

                    lvlState = 1;
                }
                break;

            case 1:
                if (circuit2.activeInHierarchy && gates.GetComponent<PlaceLogic>().gateClones.Count > 7) {
                    grd1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    bat1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    swt1 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    xor1 = gates.GetComponent<PlaceLogic>().gateClones[3];
                    nod1 = gates.GetComponent<PlaceLogic>().gateClones[4];
                    nod2 = gates.GetComponent<PlaceLogic>().gateClones[5];
                    bat2 = gates.GetComponent<PlaceLogic>().gateClones[6];
                    xor2 = gates.GetComponent<PlaceLogic>().gateClones[7];

                    pointA = xor1.transform.GetChild(3).gameObject;
                    pointB = grd1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nod1.transform.GetChild(3).gameObject;
                    pointB = xor1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = xor2.transform.GetChild(3).gameObject;
                    pointB = xor1.transform.GetChild(2).gameObject;
                    connectWire();

                    pointA = bat1.transform.GetChild(3).gameObject;
                    pointB = nod1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = swt1.transform.GetChild(3).gameObject;
                    pointB = nod2.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = bat2.transform.GetChild(3).gameObject;
                    pointB = xor2.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nod2.transform.GetChild(3).gameObject;
                    pointB = xor2.transform.GetChild(2).gameObject;
                    connectWire();

                    playB.GetComponent<PlayMode>().play = true;
                    this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                    lvlState = 2;
                }
                break;

            case 2:
                if (circuit3.activeInHierarchy && gates.GetComponent<PlaceLogic>().gateClones.Count > 8) {
                    grd1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    bat1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    swt1 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    xor1 = gates.GetComponent<PlaceLogic>().gateClones[3];
                    nod1 = gates.GetComponent<PlaceLogic>().gateClones[4];
                    nod2 = gates.GetComponent<PlaceLogic>().gateClones[5];
                    bat2 = gates.GetComponent<PlaceLogic>().gateClones[6];
                    xor2 = gates.GetComponent<PlaceLogic>().gateClones[7];
                    inv1 = gates.GetComponent<PlaceLogic>().gateClones[8];

                    pointA = xor1.transform.GetChild(3).gameObject;
                    pointB = inv1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nod1.transform.GetChild(3).gameObject;
                    pointB = xor1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = xor2.transform.GetChild(3).gameObject;
                    pointB = xor1.transform.GetChild(2).gameObject;
                    connectWire();

                    pointA = bat1.transform.GetChild(3).gameObject;
                    pointB = nod1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = swt1.transform.GetChild(3).gameObject;
                    pointB = nod2.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = bat2.transform.GetChild(3).gameObject;
                    pointB = xor2.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = nod2.transform.GetChild(3).gameObject;
                    pointB = xor2.transform.GetChild(2).gameObject;
                    connectWire();

                    pointA = inv1.transform.GetChild(3).gameObject;
                    pointB = grd1.transform.GetChild(1).gameObject;
                    connectWire();

                    playB.GetComponent<PlayMode>().play = true;
                    this.gameObject.transform.GetChild(5).gameObject.SetActive(true);
                    lvlState = 3;
                }
                break;

            case 3:
                if (circuit4.activeInHierarchy && gates.GetComponent<PlaceLogic>().gateClones.Count > 8) {
                    lit1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    and1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    inv1 = gates.GetComponent<PlaceLogic>().gateClones[2];
                    xor1 = gates.GetComponent<PlaceLogic>().gateClones[3];
                    xor2 = gates.GetComponent<PlaceLogic>().gateClones[4];
                    tmr1 = gates.GetComponent<PlaceLogic>().gateClones[5];
                    tmr1.GetComponent<GateBehavior>().goal = 3;
                    tmr1.transform.GetChild(5).gameObject.GetComponent<TMP_Text>().text = "3";
                    tmr1.transform.GetChild(6).gameObject.SetActive(false);
                    cnt1 = gates.GetComponent<PlaceLogic>().gateClones[6];
                    cnt1.GetComponent<GateBehavior>().goal = 3;
                    cnt1.transform.GetChild(5).gameObject.GetComponent<TMP_Text>().text = "3";
                    cnt1.transform.GetChild(6).gameObject.SetActive(false);
                    inv2 = gates.GetComponent<PlaceLogic>().gateClones[7];
                    bat1 = gates.GetComponent<PlaceLogic>().gateClones[8];

                    pointA = and1.transform.GetChild(3).gameObject;
                    pointB = lit1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = xor1.transform.GetChild(3).gameObject;
                    pointB = and1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = inv1.transform.GetChild(3).gameObject;
                    pointB = and1.transform.GetChild(2).gameObject;
                    connectWire();

                    pointA = xor2.transform.GetChild(3).gameObject;
                    pointB = inv1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = tmr1.transform.GetChild(3).gameObject;
                    pointB = xor1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = cnt1.transform.GetChild(3).gameObject;
                    pointB = xor2.transform.GetChild(2).gameObject;
                    connectWire();

                    pointA = inv2.transform.GetChild(3).gameObject;
                    pointB = cnt1.transform.GetChild(4).gameObject;
                    connectWire();

                    pointA = bat1.transform.GetChild(3).gameObject;
                    pointB = tmr1.transform.GetChild(1).gameObject;
                    connectWire();

                    lvlState = 4;
                }
                break;

            case 4:
                if (gates.GetComponent<PlaceLogic>().gateClones[0].transform.GetChild(1)
                    .gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {

                    this.gameObject.transform.GetChild(7).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(8).gameObject.SetActive(true);
                    lvlState = 5;

                }
                break;

            case 5:
                if (!playB.GetComponent<PlayMode>().play) {
                    ToEnd();
                }
                break;
        }

    }

    public void ToExpanded() {
        gates.GetComponent<PlaceLogic>().ClearScreen();
        playB.GetComponent<PlayMode>().play = false;
        circuit1.SetActive(false);

        circuit2.SetActive(true);
        circuit2.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();
    }

    public void ToNegated() {
        gates.GetComponent<PlaceLogic>().ClearScreen();
        playB.GetComponent<PlayMode>().play = false;
        circuit2.SetActive(false);

        circuit3.SetActive(true);
        circuit3.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();
    }

    public void ToChallenge() {
        gates.GetComponent<PlaceLogic>().ClearScreen();
        playB.GetComponent<PlayMode>().play = false;
        circuit3.SetActive(false);

        blockers.transform.GetChild(3).gameObject.SetActive(false);
        blockers.transform.GetChild(0).gameObject.SetActive(false);
        blockers.transform.GetChild(5).gameObject.SetActive(false);
        blockers.transform.GetChild(6).gameObject.SetActive(false);
        blockers.transform.GetChild(8).gameObject.SetActive(false);
        blockers.transform.GetChild(9).gameObject.SetActive(false);

        tbA.SetActive(true);

        circuit4.SetActive(true);
        circuit4.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();
    }

    void ToEnd() {
        gates.GetComponent<PlaceLogic>().ClearScreen();
        tbA.SetActive(false);
        circuit4.SetActive(false);

        if (PlayerPrefs.GetInt("TutorLevel") < 5) {
            PlayerPrefs.SetInt("TutorLevel", 5);
            PlayerPrefs.Save();
        }
        this.gameObject.transform.GetChild(8).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(9).gameObject.SetActive(true);
    }

    public void restart() {

        lvlState = 0;
        lvl.SetActive(true);

        blockers.transform.GetChild(3).gameObject.SetActive(true);
        blockers.transform.GetChild(0).gameObject.SetActive(true);
        blockers.transform.GetChild(5).gameObject.SetActive(true);
        blockers.transform.GetChild(6).gameObject.SetActive(true);
        blockers.transform.GetChild(8).gameObject.SetActive(true);
        blockers.transform.GetChild(9).gameObject.SetActive(true);

        circuit1.SetActive(true);
        circuit1.transform.GetChild(1).gameObject.SetActive(false);
        circuit1.transform.GetChild(2).gameObject.SetActive(false);
        circuit1.transform.GetChild(3).gameObject.SetActive(false);
        circuit1.transform.GetChild(4).gameObject.SetActive(false);
        circuit1.transform.GetChild(5).gameObject.SetActive(false);
        circuit1.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();

        circuit2.SetActive(false);
        circuit2.transform.GetChild(1).gameObject.SetActive(false);
        circuit2.transform.GetChild(2).gameObject.SetActive(false);
        circuit2.transform.GetChild(3).gameObject.SetActive(false);
        circuit2.transform.GetChild(4).gameObject.SetActive(false);
        circuit2.transform.GetChild(5).gameObject.SetActive(false);
        circuit2.transform.GetChild(6).gameObject.SetActive(false);
        circuit2.transform.GetChild(7).gameObject.SetActive(false);

        circuit3.SetActive(false);
        circuit3.transform.GetChild(1).gameObject.SetActive(false);
        circuit3.transform.GetChild(2).gameObject.SetActive(false);
        circuit3.transform.GetChild(3).gameObject.SetActive(false);
        circuit3.transform.GetChild(4).gameObject.SetActive(false);
        circuit3.transform.GetChild(5).gameObject.SetActive(false);
        circuit3.transform.GetChild(6).gameObject.SetActive(false);
        circuit3.transform.GetChild(7).gameObject.SetActive(false);
        circuit3.transform.GetChild(8).gameObject.SetActive(false);

        circuit4.SetActive(false);
        circuit4.transform.GetChild(1).gameObject.SetActive(false);
        circuit4.transform.GetChild(2).gameObject.SetActive(false);
        circuit4.transform.GetChild(3).gameObject.SetActive(false);
        circuit4.transform.GetChild(4).gameObject.SetActive(false);
        circuit4.transform.GetChild(5).gameObject.SetActive(false);
        circuit4.transform.GetChild(6).gameObject.SetActive(false);
        circuit4.transform.GetChild(7).gameObject.SetActive(false);
        circuit4.transform.GetChild(8).gameObject.SetActive(false);
        tbA.SetActive(false);

    }

    void connectWire() {

        pointA.GetComponent<PlaceWire>().loadWire(pointB);
        pointB.GetComponent<CircleCollider2D>().enabled = false;

    }
}
