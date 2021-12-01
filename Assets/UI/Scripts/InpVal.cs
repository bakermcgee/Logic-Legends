using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InpVal : MonoBehaviour
{
    public int value = 0;
    
    public void changeVal(string val) {

        try {

            value = Convert.ToInt32(val);

        } catch {

        }

    }
}
