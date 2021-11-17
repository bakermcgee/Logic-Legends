using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomSlider : MonoBehaviour
{

    public Camera cam;

    //zooms in the camera according to the slider's value
    public void zoomUpd(float newZoom) {

        cam.orthographicSize = newZoom;

    }
}
