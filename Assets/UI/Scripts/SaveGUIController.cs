using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;


public class SaveGUIController : MonoBehaviour
{

    public GameObject listBox;
    public GameObject boxClones;
    public GameObject pgTxt;
    int cln = -1;
    string[] files;
    int page = 0;

    void Start() {

        boxClones = this.transform.GetChild(0).gameObject;
        listBox = this.transform.GetChild(1).gameObject;
        pgTxt = this.transform.GetChild(2).gameObject
            .transform.GetChild(2).gameObject;

    }

    public void prepareSaves() {
        
        try {
            
            if (!Directory.Exists(Application.persistentDataPath + "/Circuits/")) Directory.CreateDirectory(Application.persistentDataPath + "/Circuits/");
        
            string[] tmp = Enumerable.ToArray<string>(Directory
                .GetFiles((Application.persistentDataPath + "/Circuits/"), "*.lbc")
                .Select(f => Path.GetFileNameWithoutExtension(f)));

            print(tmp.Length);
            files = tmp;

        }
        catch { print("error loading saves"); }

        print(files.Length);

        if(files.Length > 0) {

            listBox.transform.GetChild(3).gameObject
               .SetActive(false);

            listBox.SetActive(false);            

            int c = 0;
            createClone();
            foreach(string fln in files) {

                if(c < 3) {

                    GameObject lb = boxClones.transform.GetChild(cln).gameObject;

                    lb.transform.GetChild(c).gameObject
                        .transform.GetChild(0).gameObject
                        .GetComponent<TextMeshProUGUI>().text = fln;

                    lb.transform.GetChild(c).gameObject.SetActive(true);

                    c++;
                
                } else {

                    createClone();
                    GameObject lb = boxClones.transform.GetChild(cln).gameObject;

                    lb.transform.GetChild(0).gameObject
                        .transform.GetChild(0).gameObject
                        .GetComponent<TextMeshProUGUI>().text = fln;

                    lb.transform.GetChild(0).gameObject.SetActive(true);

                    c = 1;

                }


            }

            showPage();

        } else {

            listBox.SetActive(true);

            listBox.transform.GetChild(3).gameObject
                .SetActive(true);

        }

    }

    void showPage() {

        int x = 0;
        foreach(Transform boxClone in boxClones.transform) {
            if (boxClone.gameObject.activeInHierarchy) boxClones.transform.GetChild(x).gameObject.SetActive(false);
            x++;
        }

        boxClones.transform.GetChild(page).gameObject
            .SetActive(true);

    }

    public void nextPage() {

        if(page < boxClones.transform.childCount - 1) {

            page++;
            pgTxt.GetComponent<TextMeshProUGUI>().text = ("Page " + (page + 1));
            showPage();

        }

    }

    public void prevPage() {

        if (page > 0) {

            page = page - 1;
            pgTxt.GetComponent<TextMeshProUGUI>().text = ("Page " + (page + 1));
            showPage();

        }

    }

    void createClone() {

        cln++;
        GameObject lb = Instantiate(listBox);
        lb.name = ("box" + cln);
        lb.transform.SetParent(boxClones.transform, false);
        lb.transform.position = listBox.transform.position;
        lb.transform.localScale = new Vector3(1f, 1f, 1f);
     
    }

    public void show() {

        prepareSaves();
        this.gameObject.SetActive(true);

    }
    
    public void exit() {

        foreach(Transform boxClone in boxClones.transform) Destroy(boxClone.gameObject);
        cln = -1;
        this.gameObject.SetActive(false);

    }
}
