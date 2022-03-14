using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelZero : MonoBehaviour
{

    public int lvlState;
    public GameObject gates;
    public GameObject blockers;
    public GameObject mover;
    public GameObject cam;
    public GameObject flip;
    public GameObject eraser;
    
    // Start sets up variable defaults
    void Start()
    {
        lvlState = 0;
    }

    // Update checks for which lvlState the player is on
    void Update()
    {
        switch (lvlState) {

            case 1:
                if (gates.GetComponent<SpriteRenderer>().isVisible) {//to the next prompt when logic selected
                    this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    ToPlacing();
                }
                break;

            case 2:
                if (gates.GetComponent<PlaceLogic>().gateClones.Count > 0) {//to the next prompt when logic placed
                    this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                    ToMoverA();
                }
                break;

            case 3:
                if (mover.GetComponent<Toggle>().moverOn) {
                    this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
                    ToMoverB();
                }
                break;

            case 4:
                if ((cam.GetComponent<MoveCamX>().hit.collider == null) && (cam.GetComponent<MoveCamX>().restart || cam.GetComponent<MoveCamY>().restart)) {
                    this.gameObject.transform.GetChild(5).gameObject.SetActive(false);
                    ToZoom();
                }
                break;

            case 5:
                if(cam.GetComponent<Camera>().orthographicSize != 7.5f) {
                    this.gameObject.transform.GetChild(6).gameObject.SetActive(false);
                    ToFlip();
                }
                break;

            case 6:
                if (gates.GetComponent<PlaceLogic>().gateClones[0].GetComponent<MoveLogic>().flipped) {
                    this.gameObject.transform.GetChild(7).gameObject.SetActive(false);
                    ToEraser();
                }
                break;

            case 7:
                if(gates.GetComponent<PlaceLogic>().gateClones.Count == 0) {
                    this.gameObject.transform.GetChild(8).gameObject.SetActive(false);
                    ToEnd();
                }
                break;
        }
    }

    public void ToPicking() {//displays picking prompt and unblocks the toolbar

        lvlState = 1;
        this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        blockers.transform.GetChild(3).gameObject.SetActive(false);

    }

    public void ToPlacing() {//displays the placement prompt and blocks the toolbar 

        lvlState = 2;
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        blockers.transform.GetChild(3).gameObject.SetActive(true);

    }

    public void ToMoverA() {

        lvlState = 3;
        this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
        blockers.transform.GetChild(0).gameObject.SetActive(false);
        blockers.transform.GetChild(6).gameObject.SetActive(false);

    }

    public void ToMoverB() {

        lvlState = 4;
        this.gameObject.transform.GetChild(5).gameObject.SetActive(true);
        //blockers.transform.GetChild(0).gameObject.SetActive(false);
        //blockers.transform.GetChild(6).gameObject.SetActive(false);

    }

    public void ToZoom() {

        lvlState = 5;
        this.gameObject.transform.GetChild(6).gameObject.SetActive(true);
        blockers.transform.GetChild(0).gameObject.SetActive(true);
        blockers.transform.GetChild(6).gameObject.SetActive(true);
        blockers.transform.GetChild(2).gameObject.SetActive(false);

    }

    public void ToFlip() {

        lvlState = 6;
        this.gameObject.transform.GetChild(7).gameObject.SetActive(true);
        blockers.transform.GetChild(0).gameObject.SetActive(false);
        blockers.transform.GetChild(7).gameObject.SetActive(false);
        blockers.transform.GetChild(2).gameObject.SetActive(true);

    }

    public void ToEraser() {

        lvlState = 7;
        this.gameObject.transform.GetChild(8).gameObject.SetActive(true);
        blockers.transform.GetChild(7).gameObject.SetActive(true);
        blockers.transform.GetChild(9).gameObject.SetActive(false);

    }

    public void ToEnd() {

        lvlState = 8;
        this.gameObject.transform.GetChild(9).gameObject.SetActive(true);
        cam.transform.position = new Vector3(0, 0, -10);
        blockers.transform.GetChild(0).gameObject.SetActive(true);
        blockers.transform.GetChild(9).gameObject.SetActive(true);

    }
}
