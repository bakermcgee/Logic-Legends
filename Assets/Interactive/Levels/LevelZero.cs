using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelZero : MonoBehaviour
{

    public int lvlState;
    public GameObject gates;
    public GameObject blockers;
    
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
                    this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                    ToPlacing();
                }
                break;

            case 2:
                if (gates.GetComponent<PlaceLogic>().gateClones.Count > 0) {//to the next prompt when logic placed
                    this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
                }
                break;

        }
    }

    public void ToPicking() {//displays picking prompt and unblocks the toolbar

        lvlState = 1;
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        blockers.transform.GetChild(3).gameObject.SetActive(false);

    }

    public void ToPlacing() {//displays the placement prompt and blocks the toolbar 

        lvlState = 2;
        this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
        blockers.transform.GetChild(3).gameObject.SetActive(true);

    }
}
