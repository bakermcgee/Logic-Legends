using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLogic : MonoBehaviour
{

    public SpriteRenderer gates;
    public Sprite newGate;

    public void selectGate() {

        print(gates.sprite);
        gates.sprite = newGate;
        Invoke("showGate", 0.15f);

    }

    void showGate() {
        gates.enabled = true;
    }

}
