using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{

    public GameObject gates;
    public GameObject nextOne;
    public int sprt;
    int cnt;
    bool popped;


    // Start is called before the first frame update
    void Start() {
        popped = false;
        cnt = gates.GetComponent<PlaceLogic>().gateClones.Count;
        gates.transform.position = this.gameObject.transform.position;
        gates.GetComponent<SpriteRenderer>().sprite = gates.GetComponent<PlaceLogic>().sprites[sprt];
        gates.GetComponent<PlaceLogic>().movePoints();
        gates.GetComponent<PlaceLogic>().Invoke("clonePermaGate", 0.1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!popped && gates.GetComponent<PlaceLogic>().gateClones.Count > cnt) {
            
            try {
                nextOne.SetActive(true);
            }
            catch { }

            popped = true;
        }
    }
}
