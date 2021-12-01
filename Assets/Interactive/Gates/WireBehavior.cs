using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBehavior : MonoBehaviour
{

    public GameObject orig;
    public GameObject endp;
    Vector3 defOrg;
    Vector3 defEnd;
    Color defEndC;
    Color defC;
    Color onC = new Color(1f, 0.984f, 0.447f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        defOrg = this.GetComponent<LineRenderer>().GetPosition(0);
        defEnd = this.GetComponent<LineRenderer>().GetPosition(1);
        defEndC = endp.GetComponent<SpriteRenderer>().color;
        defC = this.GetComponent<LineRenderer>().startColor;

    }

    // Update is called once per frame
    void Update() {
        try {
            
            if (orig.transform.position != defOrg) {
                this.GetComponent<LineRenderer>().SetPosition(0, orig.transform.position);
                defOrg = orig.transform.position;
            }

            if (endp.transform.position != defEnd) {
                this.GetComponent<LineRenderer>().SetPosition(1, endp.transform.position);
                defEnd = endp.transform.position;
            }

            if (orig.GetComponent<SpriteRenderer>().color == onC) {

                this.GetComponent<LineRenderer>().startColor = onC;
                this.GetComponent<LineRenderer>().endColor = onC;
                endp.GetComponent<SpriteRenderer>().color = onC;

            } else {

                this.GetComponent<LineRenderer>().startColor = defC;
                this.GetComponent<LineRenderer>().endColor = defC;
                endp.GetComponent<SpriteRenderer>().color = defEndC;

            }
        }
        catch {
            Destroy(this.gameObject);
        }
    }

}
