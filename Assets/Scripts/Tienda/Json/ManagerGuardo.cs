using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;


public class ManagerGuardo : MonoBehaviour
{
    private static ManagerGuardo instance;
    public string saveFileName = "/CatEscapeSave.sav";
    public Data[] objectToSave;

   public static ManagerGuardo Instance
   {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(ManagerGuardo)) as ManagerGuardo;
            return instance;
        }
        set
        {
            instance = value;
        }
   }
    public void Save()
    {
        JObject jSaveGame = new JObject();

        foreach (Data data in objectToSave)
        {
            Data currentData = data;
            JObject seriealizedData = currentData.Serialize();
            jSaveGame.Add(currentData.name, seriealizedData);
        }

        string saveFilePath = Application.persistentDataPath + saveFileName;

        byte[] encryptSavegame = Encrypt(jSaveGame.ToString());

        File.WriteAllBytes(saveFilePath, encryptSavegame);
        Debug.Log("Saving to: " + saveFilePath);
    }
    public void Load()
    {
        string saveFilePath = Application.persistentDataPath + saveFileName;
        Debug.Log("Loading from : " + saveFilePath);

        byte[] descryptedSaveGames = File.ReadAllBytes(saveFilePath);
        string jsonString = Decrypt(descryptedSaveGames);
        JObject jSaveGame = JObject.Parse(jsonString);

        foreach(Data data in objectToSave)
        {
            Data currentData = data;
            string dataJsonString = jSaveGame[currentData.name].ToString();
            currentData.DeSeriealize(dataJsonString);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    byte[] _key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
    byte[] _initializationVector = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

    byte[] Encrypt(string message)
    {
        AesManaged aes = new AesManaged();
        ICryptoTransform encryptor = aes.CreateEncryptor(_key, _initializationVector);
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        StreamWriter streamWriter = new StreamWriter(cryptoStream);

        streamWriter.WriteLine(message);

        streamWriter.Close();
        cryptoStream.Close();
        memoryStream.Close();

        return memoryStream.ToArray();
    }
    string Decrypt(byte[] message)
    {
        AesManaged aes = new AesManaged();
        ICryptoTransform decrypter = aes.CreateDecryptor(_key, _initializationVector);
        MemoryStream memoryStream = new MemoryStream(message);
        CryptoStream cryptoStream = new CryptoStream(memoryStream, decrypter, CryptoStreamMode.Read);
        StreamReader streamReader = new StreamReader(cryptoStream);

        string decryptedMessage = streamReader.ReadToEnd();

        streamReader.Close();
        cryptoStream.Close();
        memoryStream.Close();

        return decryptedMessage;
    }
}
