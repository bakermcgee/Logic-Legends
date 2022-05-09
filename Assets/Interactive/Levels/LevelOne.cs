using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour
{
    public int lvlState;
    public GameObject gates;
    public GameObject blockers;
    public GameObject playB;
    public GameObject lvl1;
    public GameObject circuit1;
    public GameObject circuit2;
    public GameObject tbA;
    public GameObject tbB;

    // Start sets up variable defaults
    /*void Start() {
        lvlState = 0;
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        blockers.transform.GetChild(3).gameObject.SetActive(false);
        lvl1.SetActive(true);
        circuit1.SetActive(true);
        circuit1.transform.GetChild(1).gameObject.SetActive(false);
        circuit1.transform.GetChild(2).gameObject.SetActive(false);
        tbA.SetActive(true);
        circuit2.SetActive(false);
        circuit2.transform.GetChild(1).gameObject.SetActive(false);
        circuit2.transform.GetChild(2).gameObject.SetActive(false);
        tbB.SetActive(false);
    }*/

    // Update checks for which lvlState the player is on
    void Update() {

        switch (lvlState) {

            case 0:
                if (gates.GetComponent<PlaceLogic>().gateClones.Count > 3) {
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    ToDrawing();
                }
                break;

            case 1:
                if (gates.GetComponent<TrackWires>().wires.Count > 0) {
                    this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    ToTesting();
                }
                break;

            case 2:
                if (gates.GetComponent<PlaceLogic>().gateClones[3].transform.GetChild(3)
                    .gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {
                    this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                    ToSuccessA();
                }
                break;

            case 3:
                if (gates.GetComponent<PlaceLogic>().gateClones[1].transform.GetChild(3)
                    .gameObject.GetComponent<SpriteRenderer>().color != new Color(1f, 0.984f, 0.447f, 1f)) {
                    this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
                    ToOr();
                }
                break;

            case 4:
                try {
                    if (gates.GetComponent<PlaceLogic>().gateClones[3].transform.GetChild(3)
                        .gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {
                        this.gameObject.transform.GetChild(5).gameObject.SetActive(false);
                        ToSuccessB();
                    }
                }
                catch { }
                break;

            case 5:
                if (playB.GetComponent<PlayMode>().play == false) {
                    this.gameObject.transform.GetChild(6).gameObject.SetActive(false);
                    ToEnd();
                }
                break;
        }

    }

    void ToDrawing() {
        lvlState = 1;
        blockers.transform.GetChild(3).gameObject.SetActive(true);
        blockers.transform.GetChild(0).gameObject.SetActive(false);
        blockers.transform.GetChild(8).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

    void ToTesting() {
        lvlState = 2;
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        blockers.transform.GetChild(5).gameObject.SetActive(false);
    }

    void ToSuccessA() {
        lvlState = 3;
        this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }

    void ToOr() {
        lvlState = 4;
        this.gameObject.transform.GetChild(5).gameObject.SetActive(true);
        gates.GetComponent<PlaceLogic>().ClearScreen();
        circuit1.SetActive(false);
        tbA.SetActive(false);
        circuit2.SetActive(true);
        circuit2.transform.GetChild(0).gameObject.GetComponent<SpawnItem>().spawn();
        tbB.SetActive(true);
        blockers.transform.GetChild(3).gameObject.SetActive(false);
    }

    void ToSuccessB() {
        lvlState = 5;
        this.gameObject.transform.GetChild(6).gameObject.SetActive(true);
    }

    void ToEnd() {
        lvlState = 6;
        gates.GetComponent<PlaceLogic>().ClearScreen();
        tbB.SetActive(false);
        circuit2.SetActive(false);

        PlayerPrefs.SetInt("TutorLevel", 2);
        PlayerPrefs.Save();
        this.gameObject.transform.GetChild(7).gameObject.SetActive(true);
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
        tbB.SetActive(false);
    }
}
