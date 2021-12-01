using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData : MonoBehaviour
{

    public static string circName;

    public static void Save(GameObject gates) {

        try {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/Circuits/" + circName + ".lbc";
            print(Application.persistentDataPath + "/Circuits/" + circName + ".lbc");
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);

            EditorData data = new EditorData(gates.GetComponent<PlaceLogic>(), gates.GetComponent<TrackWires>());

            formatter.Serialize(fileStream, data);
            fileStream.Close();
        } catch {

            string errMessage = "Oops! Circuit not saved. Be sure that there are no special characters in your circuit's title!";
            print(errMessage);

        }

    }

    public static EditorData Load() {

        try {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/Circuits/" + circName + ".lbc";
            FileStream fileStream = new FileStream(path, FileMode.Open);

            EditorData data = formatter.Deserialize(fileStream) as EditorData;

            fileStream.Close();

            return data;

        }
        catch {

            string errMessage = "Oops! Circuit could not be loaded. The file might be missing or corrupt!";
            print(errMessage);
            return null;
        }

    }

    public void changeName(string n) {

        circName = n;

    }

}
