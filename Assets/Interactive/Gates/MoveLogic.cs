using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveLogic : MonoBehaviour {
    
    private Vector3 cursorPos;
    public float moveSpd = 0.1f;
    bool clickedOn = false;
    bool canMove = false;
    bool canFlip = false;
    bool flipped = false;

    public GameObject pl;
    public GameObject mv;
    public GameObject fl;

    void Start() {

        pl = GameObject.Find("Play");
        mv = GameObject.Find("Move");
        fl = GameObject.Find("Flip");

    }

    void Update()
    {     

        if (pl.GetComponent<PlayMode>().play) {
            canMove = false;
            canFlip = false;
        } else {
            canMove = mv.GetComponent<Toggle>().moverOn;
            canFlip = fl.GetComponent<Toggle>().moverOn;
        }

        if (canMove) {
            //checks if mouse is clicked on the object
            if (Input.GetMouseButtonDown(0) && !clickedOn) {

                cursorUpd();
                Vector2 cursor2Dpos = new Vector2(cursorPos.x, cursorPos.y);
                RaycastHit2D hit = Physics2D.Raycast(cursor2Dpos, Vector2.zero);

                if (hit.collider == this.GetComponent<BoxCollider2D>()) {

                    clickedOn = true;

                }

            }


            //allows a clicked object to be dragged
            if (Input.GetMouseButton(0) && clickedOn) {

                cursorUpd();
                transform.position = Vector2.Lerp(transform.position, cursorPos, moveSpd);

            }


            //resets input if object released
            if (Input.GetMouseButtonUp(0) && clickedOn) {

                clickedOn = false;

            }
        }

        if (canFlip) {
            //checks if mouse is clicked on the object
            if (Input.GetMouseButtonDown(0)) {

                cursorUpd();
                Vector2 cursor2Dpos = new Vector2(cursorPos.x, cursorPos.y);
                RaycastHit2D hit = Physics2D.Raycast(cursor2Dpos, Vector2.zero);

                if (hit.collider == this.GetComponent<BoxCollider2D>() && !flipped) {

                    this.transform.localScale = new Vector3(-1, 1, 1);
                    flipped = true;

                } else if (hit.collider == this.GetComponent<BoxCollider2D>() && flipped) {

                    this.transform.localScale = new Vector3(1, 1, 1);
                    flipped = false;

                }

            }

        }

    }

    //updates cursor position
    void cursorUpd(){

        cursorPos = Input.mousePosition;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

    }


}
