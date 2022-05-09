using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLvl : MonoBehaviour
{

    public GameObject gates;
    public GameObject bat1;
    public GameObject lit1;
    public GameObject xor1;

    public GameObject pointA;
    public GameObject pointB;

    public int lvlState = 0;

    // Update is called once per frame
    void Update() {
        switch (lvlState) {
            case 0:
                if (gates.GetComponent<PlaceLogic>().gateClones.Count > 3) {
                    lit1 = gates.GetComponent<PlaceLogic>().gateClones[0];
                    bat1 = gates.GetComponent<PlaceLogic>().gateClones[1];
                    xor1 = gates.GetComponent<PlaceLogic>().gateClones[3];

                    pointA = bat1.transform.GetChild(3).gameObject;
                    pointB = xor1.transform.GetChild(1).gameObject;
                    connectWire();

                    pointA = xor1.transform.GetChild(3).gameObject;
                    pointB = lit1.transform.GetChild(1).gameObject;
                    connectWire();

                    lvlState++;
                }
                break;
        }
    }

    void connectWire() {

        pointA.GetComponent<PlaceWire>().loadWire(pointB);
        pointB.GetComponent<CircleCollider2D>().enabled = false;

    }

}
