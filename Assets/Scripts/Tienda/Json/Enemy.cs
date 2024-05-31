using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq; //Para poder usar Json.net y estructuras de datos
using System.IO; //Usar StreamWriter y StreamReader

public class Enemy : MonoBehaviour
{
    public int hp = 7;
    public string name = "Sasuke";

    public JObject Serialize()
    {
        //Creamos un string que guardará el jSon
        string jsonString = JsonUtility.ToJson(this);
        //Creamos un objeto en el jSon
        JObject retVal = JObject.Parse(jsonString);
        //Al ser un método de tipo, debe devolver este tipo
        return retVal;
    }

    public void Deserialize(string jsonString)
    {
        JsonUtility.FromJsonOverwrite(jsonString, this);
    }

    //Método para guardar la información
    void SaveGame()
    {
        string jsonString = JsonUtility.ToJson(this);
        string saveFilePath = Application.persistentDataPath + "/jsonSavingObjectsDemo.sav";
        StreamWriter sw = new StreamWriter(saveFilePath);
        Debug.Log("Saving to: " + saveFilePath);
        sw.WriteLine(jsonString);
        sw.Close();
    }
    //Método para cargar la información del archivo de guardado
    void LoadGame()
    {
        string saveFilePath = Application.persistentDataPath + "/jsonSavingObjectsDemo.sav";
        Debug.Log("Loading from: " + saveFilePath);
        StreamReader sr = new StreamReader(saveFilePath);
        string jsonString = sr.ReadToEnd();
        sr.Close();
        JsonUtility.FromJsonOverwrite(jsonString, this);
    }
}
