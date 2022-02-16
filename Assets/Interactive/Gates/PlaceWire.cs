using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWire : MonoBehaviour
{
    private Vector3 cursorPos;

    
    static GameObject lg;
    public GameObject inp1;
    public GameObject inp2;
    public GameObject reset;
    public GameObject drw;

    //public float moveSpd = 0.1f;
    bool drawMode = false;
    bool clk = false;
    bool addOn = false;
    //int numCln = -1;
    Vector3 outpoint;
    Vector3 inpoint;


    void Start() {

        lg = GameObject.Find("Logic Gates");

    }

    // Update is called once per frame
    void Update() {

        try {
            drawMode = drw.GetComponent<Toggle>().moverOn;
        } catch {
            drawMode = false;
        }

        if (drawMode) { 

            cursorUpd();

            Vector2 cursor2Dpos = new Vector2(cursorPos.x, cursorPos.y);
            RaycastHit2D hit = Physics2D.Raycast(cursor2Dpos, Vector2.zero);

            if (Input.GetMouseButtonDown(0)
                && this.gameObject.name == "Output"
                && hit.collider != null
                && hit.collider.gameObject == this.gameObject) {

                //print("clicked");
                clk = true;
                outpoint = this.transform.position;

            }

            if (!Input.GetMouseButtonDown(0) && clk) {
                clk = false;
                addOn = true;
                //print(addOn);
            }

            //if (Input.GetMouseButtonDown(0)) print(hit.collider);

            if (Input.GetMouseButtonDown(0)
                && addOn
                && hit.collider != null
                && (hit.collider.gameObject.name == "Input1"
                || hit.collider.gameObject.name == "Input2"
                || hit.collider.gameObject.name == "Reset")) {

                GameObject tmp = hit.collider.gameObject;
                inpoint = tmp.transform.position;
                addOn = false;

                GameObject wr = Instantiate(this.transform.GetChild(0).gameObject);
                
                LineRenderer wire = wr.GetComponent<LineRenderer>();
                wire.startColor = new Color(0.1f, 0.1f, 0.1f, 1f);
                wire.endColor = new Color(0.1f, 0.1f, 0.1f, 1f);
                wire.startWidth = 0.06f;
                wire.endWidth = 0.06f;
                wire.SetPosition(0, outpoint);
                wire.SetPosition(1, inpoint);
                
                wr.AddComponent<WireBehavior>();
                wr.GetComponent<WireBehavior>().orig = this.gameObject;
                wr.GetComponent<WireBehavior>().endp = tmp;
                wr.SetActive(true);

                lg.GetComponent<TrackWires>().wires.Add(wr);

            } else if (Input.GetMouseButtonDown(0) && addOn
                && (hit.collider == null
                || !(hit.collider.gameObject.name == "Input1"
                || hit.collider.gameObject.name == "Input2"
                || hit.collider.gameObject.name == "Reset"))) {

                addOn = false;

              }
        }
    }
    
    public void loadWire(GameObject tmp) {

        GameObject wr = Instantiate(this.transform.GetChild(0).gameObject);

        Vector3 startP = this.transform.position;
        Vector3 endP = tmp.transform.position;

        LineRenderer wire = wr.GetComponent<LineRenderer>();
        wire.startColor = new Color(0.1f, 0.1f, 0.1f, 1f);
        wire.endColor = new Color(0.1f, 0.1f, 0.1f, 1f);
        wire.startWidth = 0.06f;
        wire.endWidth = 0.06f;
        wire.SetPosition(0, startP);
        wire.SetPosition(1, endP);

        wr.AddComponent<WireBehavior>();
        wr.GetComponent<WireBehavior>().orig = this.gameObject;
        wr.GetComponent<WireBehavior>().endp = tmp;
        wr.SetActive(true);

        lg.GetComponent<TrackWires>().wires.Add(wr);

    }

    void cursorUpd() {

        cursorPos = Input.mousePosition;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

    }

}
