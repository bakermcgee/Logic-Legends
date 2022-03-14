using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;

public class GateBehavior : MonoBehaviour
{
    private Vector3 cursorPos;

    GameObject txt;
    GameObject txt2;
    GameObject cntSlider;
    GameObject vals;

    public GameObject pl;
    public GameObject dr;

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
    public Sprite mOn;
    public Sprite mOff;

    bool inp1On = false;
    bool inp2On = false;
    bool resetOn = false;
    bool outOn = false;
    bool toggle = false;
    public bool perma;

    int count = 0;
    float timed = 0;
    int sec = 0;
    public int goal = 0;

    public bool playOn = false;

    Color defOut;
    Color defInp;
    Color defRes;

    void Start()
    {

        vals = GameObject.Find("Values");
        txt = this.transform.GetChild(0).gameObject;
        txt2 = this.transform.GetChild(5).gameObject;
        defOut = this.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color;
        defInp = this.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color;
        defRes = this.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color;

        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        if (!perma) {
            this.GetComponent<BoxCollider2D>().enabled = true;
        } else {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        txt2.GetComponent<TextMeshPro>().text = ("" + goal);

        //sets up the logic gate that was placed to its proper format 
        if (this.GetComponent<SpriteRenderer>().sprite == counter || this.GetComponent<SpriteRenderer>().sprite == timer) {

            this.transform.GetChild(2).gameObject.SetActive(false);
            txt.SetActive(true);
            txt2.SetActive(true);
            this.transform.GetChild(6).gameObject.SetActive(true);

        }

        if(this.GetComponent<SpriteRenderer>().sprite == andGate
            || this.GetComponent<SpriteRenderer>().sprite == nandGate
            || this.GetComponent<SpriteRenderer>().sprite == orGate
            || this.GetComponent<SpriteRenderer>().sprite == norGate
            || this.GetComponent<SpriteRenderer>().sprite == xorGate) {

            txt.SetActive(false);
            this.transform.GetChild(4).gameObject.SetActive(false);
            this.transform.GetChild(5).gameObject.SetActive(false);
            this.transform.GetChild(6).gameObject.SetActive(false);

        }

        if (this.GetComponent<SpriteRenderer>().sprite == node || this.GetComponent<SpriteRenderer>().sprite == inverter) {

            txt.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(4).gameObject.SetActive(false);
            this.transform.GetChild(5).gameObject.SetActive(false);
            this.transform.GetChild(6).gameObject.SetActive(false);

        }

        if (this.GetComponent<SpriteRenderer>().sprite == battery 
            || this.GetComponent<SpriteRenderer>().sprite == button
            || this.GetComponent<SpriteRenderer>().sprite == swtch) {

            txt.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(4).gameObject.SetActive(false);
            this.transform.GetChild(5).gameObject.SetActive(false);
            this.transform.GetChild(6).gameObject.SetActive(false);

        }

        if (this.GetComponent<SpriteRenderer>().sprite == lit || this.GetComponent<SpriteRenderer>().sprite == ground) {

            txt.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(3).gameObject.SetActive(false);
            this.transform.GetChild(4).gameObject.SetActive(false);
            this.transform.GetChild(5).gameObject.SetActive(false);
            this.transform.GetChild(6).gameObject.SetActive(false);

        }

    }

    void Update()
    {

        boxUpd();

        if (this.GetComponent<SpriteRenderer>().sprite == counter || this.GetComponent<SpriteRenderer>().sprite == timer) valUpd();

        if (!playOn) { //resets the scene if out of playmode

            inp1On = false;
            inp2On = false;
            resetOn = false;
            outOn = false;
            toggle = false;

            if (this.GetComponent<SpriteRenderer>().sprite == counter || this.GetComponent<SpriteRenderer>().sprite == timer) {
                txt2.SetActive(true);
                this.transform.GetChild(6).gameObject.SetActive(true);
            }

            try {
                this.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = defOut;
            } catch { }

            if(this.GetComponent<SpriteRenderer>().sprite == counter) {

                resetOn = true;
                cnt();

            }

            if (this.GetComponent<SpriteRenderer>().sprite == timer) {

                resetOn = true;
                tmr();

            }

            if (this.GetComponent<SpriteRenderer>().sprite == swtchOn) {

                this.GetComponent<SpriteRenderer>().sprite = swtch;

            }

            if (this.GetComponent<SpriteRenderer>().sprite == buttonDn) {

                this.GetComponent<SpriteRenderer>().sprite = button;

            }

            if (this.GetComponent<SpriteRenderer>().sprite == lit) {

                this.GetComponent<Light2D>().enabled = false;

            }

        }

        if (playOn) { //allows for the circuit to be tested

            if (this.GetComponent<SpriteRenderer>().sprite == counter || this.GetComponent<SpriteRenderer>().sprite == timer) {
                txt2.SetActive(false);
                this.transform.GetChild(6).gameObject.SetActive(false);
            }

            try {
                if (outOn) {

                    this.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.984f, 0.447f, 1f);

                } else {

                    this.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = defOut;

                }
            } catch { }

            try {
                if (this.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {

                    inp1On = true;

                } else {

                    inp1On = false;

                }
            } catch { }

            try {
                if (this.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {

                    inp2On = true;

                } else {

                    inp2On = false;

                }
            }
            catch { }

            try {
                if (this.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color == new Color(1f, 0.984f, 0.447f, 1f)) {

                    resetOn = true;

                } else {

                    resetOn = false;

                }
            } catch { }

            //calls the correct method depending on the type of logic placed
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

    //and gate's function
    void andG() {
        
        if(inp1On && inp2On) {

            outOn = true; 

        } else {

            outOn = false;

        }

    }

    //nand gate's function
    void nandG() {

        if (inp1On && inp2On) {

            outOn = false;

        } else {

            outOn = true;

        }

    }

    //or gate's function
    void orG() {

        if (inp1On || inp2On) {

            outOn = true;

        } else {

            outOn = false;

        }

    }

    //nor gate's function
    void norG() {

        if (inp1On || inp2On) {

            outOn = false;

        } else {

            outOn = true;

        }

    }

    //xor gate's function
    void xorG() {

        if ((inp1On && !inp2On) || (!inp1On && inp2On)) {

            outOn = true;

        } else {

            outOn = false;

        }

    }

    //node's function
    void nodes() {

        if (inp1On) {

            outOn = true;

        } else {

            outOn = false;

        }
    
    
    }

    //inverter's function
    void invr() {

        if (inp1On) {

            outOn = false;

        } else {

            outOn = true;

        }

    }

    //battery's function
    void bat() {

        outOn = true;
    
    }
    
    //ground's function
    void grnd() { }

    //button's function
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

    //switch's function
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

    //counter's function
    void cnt() {
        
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

    //timer's function
    void tmr() {

        if (inp1On && (sec < goal)) {

            timed += Time.deltaTime;
            sec = (int)(timed % 60);            

        }

        if (sec == goal) {

            outOn = true;

        }

        if (resetOn) {

            timed = 0;
            sec = 0;
            outOn = false;
        
        }

        txt.GetComponent<TextMeshPro>().text = ("" + sec);
    
    }

    //light's function
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

    //updates the box collider depending on if drawing wires or not. automatically true if playmode is on
    void boxUpd() {

        playOn = pl.GetComponent<PlayMode>().play;
        try { 
            bool draw = dr.GetComponent<Toggle>().moverOn;
            if (draw) {

                this.GetComponent<BoxCollider2D>().enabled = false;

            } else if(!perma) {

                this.GetComponent<BoxCollider2D>().enabled = true;

            }
        } catch { }
        
        if (playOn) {

            this.GetComponent<BoxCollider2D>().enabled = true;

        } else if (perma) {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    void valUpd() {//updates the counter/timer max values


        if (Input.GetMouseButtonDown(0)) {
            cursorUpd();
            Vector2 cursor2Dpos = new Vector2(cursorPos.x, cursorPos.y);
            RaycastHit2D hit = Physics2D.Raycast(cursor2Dpos, Vector2.zero);

            if(this.GetComponent<SpriteRenderer>().sprite == counter) {//instaniates a value slider if the component is a counter/timer and the hit collider detects the modify button

                if (hit.collider != null && hit.collider.gameObject == this.transform.GetChild(6).gameObject && this.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().sprite == mOn) {

                    this.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().sprite = mOff;
                    cntSlider = Instantiate(vals.transform.GetChild(0).gameObject);
                    cntSlider.transform.SetParent(vals.transform);
                    cntSlider.transform.position = vals.transform.GetChild(0).position;
                    cntSlider.transform.localScale = new Vector3(1f, 1f, 1f);
                    cntSlider.GetComponent<Image>().enabled = true;
                    cntSlider.transform.GetChild(0).gameObject.SetActive(true);
                    
                } else if (hit.collider != null) {

                    this.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().sprite = mOn;
                    Destroy(cntSlider);

                }

            } else if(this.GetComponent<SpriteRenderer>().sprite == timer) {

                if (hit.collider != null && hit.collider.gameObject == this.transform.GetChild(6).gameObject && this.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().sprite == mOn) {

                    this.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().sprite = mOff;
                    cntSlider = Instantiate(vals.transform.GetChild(0).gameObject);
                    cntSlider.transform.SetParent(vals.transform);
                    cntSlider.transform.position = vals.transform.GetChild(0).position;
                    cntSlider.transform.localScale = new Vector3(1f, 1f, 1f);
                    cntSlider.GetComponent<Image>().enabled = true;
                    cntSlider.transform.GetChild(1).gameObject.SetActive(true);

                } else if (hit.collider != null) {

                    this.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().sprite = mOn;
                    Destroy(cntSlider);

                }

            }
        }

        if(this.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().sprite == mOff) {

            if (this.GetComponent<SpriteRenderer>().sprite == counter) {
                
                goal = (int)cntSlider.transform.GetChild(0).GetComponent<Slider>().value;
            
            } else if (this.GetComponent<SpriteRenderer>().sprite == timer) {
            
                goal = (int)cntSlider.transform.GetChild(1).GetComponent<Slider>().value;
            
            }

            txt2.GetComponent<TextMeshPro>().text = ("" + goal);

            if (playOn) {

                this.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().sprite = mOn;
                Destroy(cntSlider);

            }

        }

    }

}
