using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EditorData {
    public string[] gateName;
    public int[] cntGoal;
    public bool[] flp;
    public int numGates;
    public float[,] position;
    public float[,] wirePosS;
    public float[,] wirePosE;

    public EditorData(PlaceLogic gates, TrackWires wr) {

        gateName = readNames(gates);
        cntGoal = readCnt(gates);
        numGates = gates.numCln;
        position = readPosition(gates);
        wirePosS = readWrPosS(wr);
        wirePosE = readWrPosE(wr);
        flp = readFlp(gates);

    }

    string[] readNames(PlaceLogic gates) {

        string[] tmp = new string[gates.gateClones.Count];
        int c = 0; 

        foreach(var i in gates.gateClones) {

            tmp[c] = i.GetComponent<SpriteRenderer>().sprite.name;
            c++;

        }

        return tmp;
    }

    int[] readCnt(PlaceLogic gates) {

        int[] tmp = new int[gates.gateClones.Count];
        int c = 0;

        foreach (var i in gates.gateClones) {

            tmp[c] = i.GetComponent<GateBehavior>().goal;
            c++;

        }

        return tmp;
    }


    float[,] readPosition(PlaceLogic gates) {

        float[,] tmp = new float[(gates.gateClones.Count), 3];
        int c = 0;

        foreach(var i in gates.gateClones) {

            tmp[c, 0] = i.transform.position.x;
            tmp[c, 1] = i.transform.position.y;
            tmp[c, 2] = i.transform.position.z;
            c++;

        }

        return tmp;

    }

    float[,] readWrPosS(TrackWires wr) {

        float[,] tmp = new float[(wr.wires.Count), 3];
        int c = 0;

        foreach (var i in wr.wires) {

            tmp[c, 0] = i.GetComponent<LineRenderer>().GetPosition(0).x;
            tmp[c, 1] = i.GetComponent<LineRenderer>().GetPosition(0).y;
            tmp[c, 2] = i.GetComponent<LineRenderer>().GetPosition(0).z;
            c++;

        }

        return tmp;

    }

    float[,] readWrPosE(TrackWires wr) {

        float[,] tmp = new float[(wr.wires.Count), 3];
        int c = 0;

        foreach (var i in wr.wires) {

            tmp[c, 0] = i.GetComponent<LineRenderer>().GetPosition(1).x;
            tmp[c, 1] = i.GetComponent<LineRenderer>().GetPosition(1).y;
            tmp[c, 2] = i.GetComponent<LineRenderer>().GetPosition(1).z;
            c++;

        }

        return tmp;

    }

    bool[] readFlp(PlaceLogic gates) {

        bool[] tmp = new bool[gates.gateClones.Count];
        int c = 0;

        foreach (var i in gates.gateClones) {

            tmp[c] = i.GetComponent<MoveLogic>().flipped;
            c++;
        
        }

        return tmp;
    }

}
