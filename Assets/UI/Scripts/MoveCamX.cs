using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamX : MonoBehaviour
{
    public float dragSpeed;
    private Vector3 dragOrigin;
    private Vector3 cursorPos;
    public RaycastHit2D hit;

    public bool res = false;
    public bool restart = false;
    public bool move = false;
    public bool canMove = false;
    

    void Update() {
        if (move) {

            //updates cursor position upon click/tap
            if (Input.GetMouseButtonDown(0)) {
                dragOrigin = Input.mousePosition;
                cursorUpd();
                Vector2 cursor2Dpos = new Vector2(cursorPos.x, cursorPos.y);
                hit = Physics2D.Raycast(cursor2Dpos, Vector2.zero);
                return;
            }


            //resets everything upon release
            if (Input.GetMouseButtonUp(0)) {
                canMove = false;
                res = false;
                restart = false;
                return;
            }

            //drags the screen while clicked/tapped
            if (Input.GetMouseButton(0) && ((Input.GetAxis("Mouse X") > 0) || (Input.GetAxis("Mouse X") < 0) || (Input.GetAxis("Mouse Y") > 0) || (Input.GetAxis("Mouse Y") < 0)) && !restart) {

                res = true;

                if ((Input.GetAxis("Mouse X") < 0) && (this.transform.position.x < 20f) && hit.collider == null) {

                    Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
                    Vector3 move = new Vector3(pos.x * (-dragSpeed), 0, 0);
                    transform.Translate(move, Space.World);

                } else if ((Input.GetAxis("Mouse X") > 0) && (this.transform.position.x > -20f) && hit.collider == null) {

                    Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
                    Vector3 move = new Vector3(pos.x * (-dragSpeed), 0, 0);
                    transform.Translate(move, Space.World);

                } 
            
            }
            else if (Input.GetMouseButton(0) && res && !restart) {

                restart = true;

            }
        }
    }

    public void Movable() {

        canMove = true;

    }

    //toggles mover when called
    public void MoverToggle() {

        move = !move;

    }

    //disables mover when called
    public void MoverForceOff() {

        move = false;

    }

    //updates cursor position
    void cursorUpd() {

        cursorPos = Input.mousePosition;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

    }
}
