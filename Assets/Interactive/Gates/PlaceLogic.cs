using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLogic : MonoBehaviour
{

    private Vector3 cursorPos;
    public SpriteRenderer gate;
    public GameObject Gates;
    public ArrayList gateClones = new ArrayList();
    public float moveSpd = 0.1f;
    bool addOn = false;
    bool subOn = false;
    int numCln = 0;

    void Update()
    {
        //allows for logic to be placed within editor
        if (addOn) {

            cursorUpd();
            transform.position = Vector2.Lerp(transform.position, cursorPos, moveSpd);

            Vector2 cursor2Dpos = new Vector2(cursorPos.x, cursorPos.y);
            RaycastHit2D hit = Physics2D.Raycast(cursor2Dpos, Vector2.zero);

            //if tapped/clicked and there are no other objects in the way, the object is placed
            if (Input.GetMouseButtonDown(0) && hit.collider == null) {

                addOn = false;
                gate.enabled = false;
                GameObject newGate = Instantiate(Gates);
                
                newGate.AddComponent<MoveLogic>();
                newGate.GetComponent<GateBehavior>().enabled = true;
                Destroy(newGate.GetComponent<PlaceLogic>());
                
                numCln += 1;
                newGate.name = ("clone" + numCln);
                
                //print(numCln);
                gateClones.Add(newGate);

            }


        }
    }

    //called if a button on the toolbar was pressed
    public void buttonPressed() {

        addOn = true;
        Gates.GetComponent<BoxCollider2D>().enabled = false; 

    }

    //updates cursor position
    void cursorUpd() {

        cursorPos = Input.mousePosition;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

    }
}
