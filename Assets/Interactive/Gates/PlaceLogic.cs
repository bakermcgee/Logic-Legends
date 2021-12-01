using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlaceLogic : MonoBehaviour
{

    private Vector3 cursorPos;
    public SpriteRenderer gate;
    public Camera cam;

    public GameObject loadingGame;
    public GameObject Gates;
    public List<GameObject> gateClones = new List<GameObject>();

    public GameObject inp1;
    public GameObject inp2;
    public GameObject outp;
    public GameObject reset;

    public Sprite[] sprites = new Sprite[14];

    public float moveSpd = 0.1f;
    bool addOn = false;
    bool subOn = false;
    public int numCln = -1;
    public bool done = true;

    void Update()
    {
        cursorUpd();
        //if(addOn) transform.position = new Vector3(GameObject.Find("Origin").transform.position.x, GameObject.Find("Origin").transform.position.y, 0f);
        //allows for logic to be placed within editor
        if (addOn) {
         
            //transform.position = Vector2.Lerp(transform.position, cursorPos, moveSpd);

            Vector2 cursor2Dpos = new Vector2(cursorPos.x, cursorPos.y);
            RaycastHit2D hit = Physics2D.Raycast(cursor2Dpos, Vector2.zero);

            if (Input.GetMouseButtonDown(0) && hit.collider == null) {

                transform.position = Vector2.Lerp(transform.position, cursorPos, 1f);
                Invoke("cloneGate", 0.3f);
                //transform.position = cam.transform.position;
                /*GameObject newGate = Instantiate(Gates);

                newGate.AddComponent<MoveLogic>();
                newGate.GetComponent<GateBehavior>().enabled = true;
                Destroy(newGate.GetComponent<PlaceLogic>());

                numCln += 1;
                newGate.name = ("clone" + numCln);

                gateClones.Add(newGate);

                inp1.SetActive(false);
                inp2.SetActive(false);
                outp.SetActive(false);
                reset.SetActive(false);

                addOn = false;
                gate.enabled = false;*/

            }

                /*
                //if tapped/clicked and there are no other objects in the way, the object is placed
                if (Input.GetMouseButtonDown(0) && hit.collider == null) {

                    addOn = false;
                    gate.enabled = false;

                    cursorUpd();
                    transform.position = Vector2.Lerp(transform.position, cursorPos, 0.1f);
                    GameObject newGate = Instantiate(Gates);

                    newGate.AddComponent<MoveLogic>();
                    newGate.GetComponent<GateBehavior>().enabled = true;
                    Destroy(newGate.GetComponent<PlaceLogic>());

                    numCln += 1;
                    newGate.name = ("clone" + numCln);

                    gateClones.Add(newGate);

                    inp1.SetActive(false);
                    inp2.SetActive(false);
                    outp.SetActive(false);
                    reset.SetActive(false);

                }*/


            }

        //allows for logic to be removed from the editor
        if (subOn) {

            cursorUpd();
            transform.position = Vector2.Lerp(transform.position, cursorPos, moveSpd);

            Vector2 cursor2Dpos = new Vector2(cursorPos.x, cursorPos.y);
            RaycastHit2D hit = Physics2D.Raycast(cursor2Dpos, Vector2.zero);

            if (Input.GetMouseButtonDown(0) 
                && hit.collider != null
                && !(hit.collider.gameObject.name == "Input1"
                || hit.collider.gameObject.name == "Input2"
                || hit.collider.gameObject.name == "Output"
                || hit.collider.gameObject.name == "Reset"
                || hit.collider.gameObject.name == "AddVal")) {

                gateClones.Remove(hit.collider.gameObject);
                Destroy(hit.collider.gameObject);

            }

        }
    }

    //called if a button on the toolbar was pressed
    public void logicPicked() {

        addOn = true;
        transform.position = new Vector3(GameObject.Find("Origin").transform.position.x, GameObject.Find("Origin").transform.position.y, 0f);
        //Gates.GetComponent<BoxCollider2D>().enabled = false; 

    }

    public void toggleErase() {

        subOn = !subOn;

    }

    public void forceOffErase() {

        subOn = false;

    }

    //updates cursor position
    void cursorUpd() {

        cursorPos = Input.mousePosition;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

    }

    void cloneGate() {

        GameObject newGate = Instantiate(Gates);

        newGate.AddComponent<MoveLogic>();
        newGate.GetComponent<GateBehavior>().enabled = true;
        Destroy(newGate.GetComponent<PlaceLogic>());

        numCln += 1;
        newGate.name = ("clone" + numCln);

        gateClones.Add(newGate);

        inp1.SetActive(false);
        inp2.SetActive(false);
        outp.SetActive(false);
        reset.SetActive(false);

        addOn = false;
        gate.enabled = false;
        

    }

    public void SaveGates() {

        SaveData.Save(this.gameObject);

    }

    public void LoadGates() {

        EditorData data = SaveData.Load();
        
        if(gateClones.Count > 0) {//destroys all gates in case loading while in editor
            foreach(GameObject g in gateClones) {
                Destroy(g);
            }
        }

        gateClones = new List<GameObject>();

        if (this.GetComponent<TrackWires>().wires.Count > 0) {//destroys all gates in case loading while in editor
            foreach (GameObject w in this.GetComponent<TrackWires>().wires) {
                Destroy(w);
            }
        }

        this.GetComponent<TrackWires>().wires = new List<GameObject>();

        numCln = data.numGates;

        StartCoroutine(cloneLoad(data));

        /*for (int x = 0; x < data.wirePosS.GetLength(0); x++) {//loops to instantiate all wires

            bool loop = true;
            int y = 0;

            GameObject outg = null;
            GameObject ing = null;

            while (loop) {//loops to find wire's output point

                Vector3 tmpOut = new Vector3(data.wirePosS[x, 0], data.wirePosS[x, 1], data.wirePosS[x, 2]);
                Vector3 tmpIn = new Vector3(data.wirePosE[x, 0], data.wirePosE[x, 1], data.wirePosE[x, 2]);

                try {

                    Vector3 outPosition = gateClones[y].transform.Find("Output")
                        .gameObject.transform.position;

                    if (tmpOut == outPosition) {

                        loop = false;
                        outg = gateClones[y].transform.Find("Output").gameObject;
                        bool loop2 = true;
                        int z = 0;

                        while (loop2) {//loops to find wire's input point

                            Vector3 inPosition1 = gateClones[z].transform.Find("Input1")
                                .gameObject.transform.position;

                            Vector3 inPosition2 = gateClones[z].transform.Find("Input2")
                                .gameObject.transform.position;

                            if (tmpIn == inPosition1) {

                                ing = gateClones[z].transform.Find("Input1").gameObject;
                                loop2 = false;

                            } else if (tmpIn == inPosition2) {

                                ing = gateClones[z].transform.Find("Input2").gameObject;
                                loop2 = false;

                            }

                            z++;

                        }

                    }
                }
                catch { }

                y++;

            }
            
            if(outg != null) outg.GetComponent<PlaceWire>().loadWire(ing); //instantiates wire x

        }*/

    }

    IEnumerator cloneLoad(EditorData data) {

        for (int x = 0; x < data.gateName.Length; x++) {//loops to instaniate all gates

            bool loop = true;
            int y = 0;
            while (loop) {

                if (data.gateName[x] == sprites[y].name) {
                    print(data.gateName[x]);
                    print(sprites[y].name);
                    loop = false;
                    Gates.GetComponent<SpriteRenderer>().sprite = sprites[y];
                }

                y++;

            }

            movePoints();

            inp1.SetActive(true);
            inp2.SetActive(true);
            outp.SetActive(true);
            reset.SetActive(true);

            Gates.transform.position = new Vector3(data.position[x, 0], data.position[x, 1], data.position[x, 2]);
            print(new Vector3(data.position[x, 0], data.position[x, 1], data.position[x, 2]));

            yield return new WaitForSeconds(0.1f);

            GameObject gate = Instantiate(Gates); //instantiates gate x

            gate.AddComponent<MoveLogic>();
            gate.transform.position = new Vector3(data.position[x, 0], data.position[x, 1], data.position[x, 2]);

            gate.GetComponent<GateBehavior>().enabled = true;
            gate.GetComponent<GateBehavior>().goal = data.cntGoal[x];

            Destroy(gate.GetComponent<PlaceLogic>());
            gate.name = ("clone" + x);

            gateClones.Add(gate);

            loadingGame.GetComponent<LoadingGame>().changeValue(((float)x / (float)data.gateName.Length));

        }

        inp1.SetActive(false);
        inp2.SetActive(false);
        outp.SetActive(false);
        reset.SetActive(false);

        StartCoroutine(wireLoad(data));
    }

    IEnumerator wireLoad(EditorData data) {

        
        print(data.wirePosS.GetLength(0));

        for (int x = 0; x < data.wirePosS.GetLength(0); x++) {//loops to instantiate all wires

            print(data.wirePosS.GetLength(0));

            bool loop = true;
            int y = 0;

            GameObject outg = null;
            GameObject ing = null;

            while (loop) {//loops to find wire's output point

                Vector3 tmpOut = new Vector3(data.wirePosS[x, 0], data.wirePosS[x, 1], data.wirePosS[x, 2]);
                Vector3 tmpIn = new Vector3(data.wirePosE[x, 0], data.wirePosE[x, 1], data.wirePosE[x, 2]);

                try {

                    Vector3 outPosition = gateClones[y].transform.Find("Output")
                        .gameObject.transform.position;

                    if (tmpOut == outPosition) {

                        
                        loop = false;
                        outg = gateClones[y].transform.Find("Output").gameObject;
                        bool loop2 = true;
                        int z = 0;

                        
                        while (loop2) {//loops to find wire's input point
                            Vector3 inPosition1 = new Vector3(0f,0f,0f);
                            Vector3 inPosition2 = new Vector3(0f, 0f, 0f);
                            Vector3 inPosition3 = new Vector3(0f, 0f, 0f);
                            
                            try {
                                inPosition1 = gateClones[z].transform.Find("Input1")
                                    .gameObject.transform.position;
                            }
                            catch { }

                            try {
                                inPosition2 = gateClones[z].transform.Find("Input2")
                                    .gameObject.transform.position;
                            }
                            catch { }

                            try {
                                    inPosition3 = gateClones[z].transform.Find("Reset")
                                    .gameObject.transform.position;
                            }
                            catch { }

                            

                            if (tmpIn == inPosition1) {

                                ing = gateClones[z].transform.Find("Input1").gameObject;
                                loop2 = false;
                                

                            } else if (tmpIn == inPosition2) {

                                ing = gateClones[z].transform.Find("Input2").gameObject;
                                loop2 = false;
                                

                            } else if (tmpIn == inPosition3) {

                                ing = gateClones[z].transform.Find("Reset").gameObject;
                                loop2 = false;
                                

                            }

                            if (z > gateClones.Count) {
                                loop2 = false;
                            }
                            z++;

                        }

                        if (y > gateClones.Count) {
                            loop = false;
                        }

                    }
                }
                catch { print("oops"); }
                
                y++;

            }

            yield return new WaitForSeconds(0.1f);



            if (outg != null) {
                outg.GetComponent<PlaceWire>().loadWire(ing); //instantiates wire x
                loadingGame.GetComponent<LoadingGame>().changeValue((1f + ((float)x / (float)data.wirePosS.GetLength(0))));
            }


        }

        yield return new WaitForSeconds(0.1f);

        loadingGame.GetComponent<LoadingGame>().hide();
        loadingGame.GetComponent<LoadingGame>().changeValue(0f);

    }

    void movePoints() {

        float xPos = Gates.transform.position.x;
        float yPos = Gates.transform.position.y;

        if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[0]) {

            inp1.transform.position = new Vector3((xPos - 1.2f), (yPos + 0.43f), 0);
            inp2.transform.position = new Vector3((xPos - 1.2f), (yPos - 0.43f), 0);
            outp.transform.position = new Vector3((xPos + 1.2f), (yPos + 0.02f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[1]) {

            inp1.transform.position = new Vector3((xPos - 1.3f), (yPos + 0.43f), 0);
            inp2.transform.position = new Vector3((xPos - 1.3f), (yPos - 0.43f), 0);
            outp.transform.position = new Vector3((xPos + 1.3f), (yPos + 0.02f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[2]) {

            inp1.transform.position = new Vector3((xPos - 1.1f), (yPos + 0.37f), 0);
            inp2.transform.position = new Vector3((xPos - 1.1f), (yPos - 0.32f), 0);
            outp.transform.position = new Vector3((xPos + 1.1f), (yPos + 0.02f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[3]) {

            inp1.transform.position = new Vector3((xPos - 1.2f), (yPos + 0.37f), 0);
            inp2.transform.position = new Vector3((xPos - 1.2f), (yPos - 0.32f), 0);
            outp.transform.position = new Vector3((xPos + 1.2f), (yPos + 0.02f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[4]) {

            inp1.transform.position = new Vector3((xPos - 1.1f), (yPos + 0.37f), 0);
            inp2.transform.position = new Vector3((xPos - 1.1f), (yPos - 0.32f), 0);
            outp.transform.position = new Vector3((xPos + 1.1f), (yPos + 0.02f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[5]) {

            inp1.transform.position = new Vector3((xPos - 1.05f), (yPos + 0.0008f), 0);
            outp.transform.position = new Vector3((xPos + 1.05f), (yPos + 0.0008f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[6]) {

            inp1.transform.position = new Vector3((xPos - 1.05f), (yPos + 0.0008f), 0);
            outp.transform.position = new Vector3((xPos + 1.05f), (yPos + 0.03f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[7]) {

            outp.transform.position = new Vector3((xPos + 1.05f), (yPos - 0.02f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[8]) {

            inp1.transform.position = new Vector3((xPos - 1f), (yPos - 0.02f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[9]) {

            outp.transform.position = new Vector3((xPos + 1.2f), (yPos - 0.09f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[10]) {

            outp.transform.position = new Vector3((xPos + 1.05f), (yPos - 0.5f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[11]) {

            inp1.transform.position = new Vector3((xPos - 1.1f), (yPos + 0.15f), 0);
            outp.transform.position = new Vector3((xPos + 1.1f), (yPos + 0.14f), 0);
            reset.transform.position = new Vector3((xPos - 0.01f), (yPos - 1f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[12]) {

            inp1.transform.position = new Vector3((xPos - 1.1f), (yPos + 0.15f), 0);
            outp.transform.position = new Vector3((xPos + 1.1f), (yPos + 0.14f), 0);
            reset.transform.position = new Vector3((xPos - 0.01f), (yPos - 1f), 0);

        } else if (Gates.GetComponent<SpriteRenderer>().sprite == sprites[13]) {

            inp1.transform.position = new Vector3((xPos - 0.8f), (yPos - 0.9f), 0);

        }

    }


}
