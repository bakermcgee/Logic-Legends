using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;

public class GateBehavior : MonoBehaviour
{
    private Vector3 cursorPos;

    GameObject txt;

    public Sprite andGate;
    public Sprite nandGate;
    public Sprite orGate;
    public Sprite norGate;
    public Sprite xorGate;
    public Sprite node;
    public Sprite inverter;
    public Sprite battery;
    public Sprite ground;
    public Sprite button;
    public Sprite buttonDn;
    public Sprite swtch;
    public Sprite swtchOn;
    public Sprite counter;
    public Sprite timer;
    public Sprite lit;

    bool inp1On = false;
    bool inp2On = false;
    bool resetOn = false;
    bool outOn = false;
    bool toggle = false;

    int count = 0;
    float timed = 0;
    int sec = 0;

    bool playOn = true;
    
    // Start is called before the first frame update
    void Start()
    {

        txt = this.transform.GetChild(0).gameObject;

        print(lit);

        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<BoxCollider2D>().enabled = true;

        if (this.GetComponent<SpriteRenderer>().sprite == counter || this.GetComponent<SpriteRenderer>().sprite == timer) {

            txt.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playOn) {
            if (this.GetComponent<SpriteRenderer>().sprite == andGate) {
                andG();
            } else if (this.GetComponent<SpriteRenderer>().sprite == nandGate) {
                nandG();
            } else if (this.GetComponent<SpriteRenderer>().sprite == orGate) {
                orG();
            } else if (this.GetComponent<SpriteRenderer>().sprite == norGate) {
                norG();
            } else if (this.GetComponent<SpriteRenderer>().sprite == xorGate) {
                xorG();
            } else if (this.GetComponent<SpriteRenderer>().sprite == node) {
                nodes();
            } else if (this.GetComponent<SpriteRenderer>().sprite == inverter) {
                invr();
            } else if (this.GetComponent<SpriteRenderer>().sprite == battery) {
                bat();
            } else if (this.GetComponent<SpriteRenderer>().sprite == ground) {
                grnd();
            } else if (this.GetComponent<SpriteRenderer>().sprite == button || this.GetComponent<SpriteRenderer>().sprite == buttonDn) {
                btn();
            } else if (this.GetComponent<SpriteRenderer>().sprite == swtch || this.GetComponent<SpriteRenderer>().sprite == swtchOn) {
                swt();
            } else if (this.GetComponent<SpriteRenderer>().sprite == counter) {
                cnt();
            } else if (this.GetComponent<SpriteRenderer>().sprite == timer) {
                tmr();
            } else if (this.GetComponent<SpriteRenderer>().sprite == lit) {
                lt();
            }
        }
    }

    void andG() {
        
        if(inp1On && inp2On) {

            outOn = true; 

        } else {

            outOn = false;

        }

    }

    void nandG() {

        if (inp1On && inp2On) {

            outOn = false;

        } else {

            outOn = true;

        }

    }

    void orG() {

        if (inp1On || inp2On) {

            outOn = true;

        } else {

            outOn = false;

        }

    }

    void norG() {

        if (inp1On || inp2On) {

            outOn = false;

        } else {

            outOn = true;

        }

    } 

    void xorG() {

        if ((inp1On && !inp2On) || (!inp1On && inp2On)) {

            outOn = true;

        } else {

            outOn = false;

        }

    }

    void nodes() {

        if (inp1On) {

            outOn = true;

        } else {

            outOn = false;

        }
    
    
    }

    void invr() {

        if (inp1On) {

            outOn = false;

        } else {

            outOn = true;

        }

    }

    void bat() {

        outOn = true;
    
    }
    
    void grnd() { }

    void btn() {
        if (Input.GetMouseButton(0)) {
            cursorUpd();
            Vector2 cursor2Dpos = new Vector2(cursorPos.x, cursorPos.y);
            RaycastHit2D hit = Physics2D.Raycast(cursor2Dpos, Vector2.zero);

            if (hit.collider == this.GetComponent<BoxCollider2D>()) {

                this.GetComponent<SpriteRenderer>().sprite = buttonDn;
                outOn = true;

            }

        } else if (this.GetComponent<SpriteRenderer>().sprite == buttonDn && outOn) {

            this.GetComponent<SpriteRenderer>().sprite = button;
            outOn = false;

        }
    }

    void swt() {
        if (Input.GetMouseButtonDown(0)) {
            cursorUpd();
            Vector2 cursor2Dpos = new Vector2(cursorPos.x, cursorPos.y);
            RaycastHit2D hit = Physics2D.Raycast(cursor2Dpos, Vector2.zero);

            if (hit.collider == this.GetComponent<BoxCollider2D>() && !outOn) {

                this.GetComponent<SpriteRenderer>().sprite = swtchOn;
                outOn = true;

            } else if (hit.collider == this.GetComponent<BoxCollider2D>() && outOn) {

                this.GetComponent<SpriteRenderer>().sprite = swtch;
                outOn = false;

            }

        }
    }

    void cnt() {

        int goal = 10;
        
        if (inp1On && !toggle && (count < goal)) {

            count += 1;
            toggle = true;

        } else if (!inp1On && toggle) {

            toggle = false;

        }

        if(count == goal) {

            outOn = true;

        }

        if (resetOn) {

            count = 0;
            outOn = false;

        }

        txt.GetComponent<TextMeshPro>().text = ("" + count);

    }

    void tmr() {

        int goal = 100;
        //inp1On = true;

        if (inp1On && (sec < goal)) {

            timed += Time.deltaTime;
            sec = (int)(timed % 60);            

        }

        if (timed == goal) {

            outOn = true;

        }

        if (resetOn) {

            timed = 0;
            sec = 0;
            outOn = false;
        
        }

        txt.GetComponent<TextMeshPro>().text = ("" + sec);
    
    }

    void lt() {

        if (inp1On) {

            this.GetComponent<Light2D>().enabled = true;

        } else {

            this.GetComponent<Light2D>().enabled = false;

        } 

    }

    //updates cursor position
    void cursorUpd() {

        cursorPos = Input.mousePosition;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

    }

}
