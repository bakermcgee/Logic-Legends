using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToPage : MonoBehaviour
{

    public GameObject pages;
    int page;

    // Called when the button is pressed
    public void nextPage(){

        for(int i = 0; i < pages.transform.childCount - 1; i++) {

            if (pages.transform.GetChild(i).gameObject.activeSelf) {

                page = i;
                pages.transform.GetChild(page).gameObject.SetActive(false);
                pages.transform.GetChild((page + 1)).gameObject.SetActive(true);
                break;

            }

        }

    }

    public void prevPage() {

        for (int i = pages.transform.childCount - 1; i > 0; i--) {

            if (pages.transform.GetChild(i).gameObject.activeSelf) {

                page = i;
                pages.transform.GetChild(page).gameObject.SetActive(false);
                pages.transform.GetChild((page - 1)).gameObject.SetActive(true);
                break;

            }

        }

    }
}
