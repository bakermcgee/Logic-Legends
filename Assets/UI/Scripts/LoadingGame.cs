using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingGame : MonoBehaviour
{
    public void changeValue(float val) {

        this.gameObject.GetComponent<Slider>().value = val;

    }

    public void hide() {

        this.transform.parent.gameObject.SetActive(false);

    }
}
