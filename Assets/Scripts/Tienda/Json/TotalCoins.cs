using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

[CreateAssetMenu(menuName = "ScriptableObjects/TotalCoins")]
public class TotalCoins : Data
{
    public int totalCoins;
    public override void DeSeriealize(string jsonString)
    {
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonString);
        totalCoins = sd.totalCoins;
    }
    public override JObject Serialize()
    {
        SaveData sd = new SaveData(totalCoins);
        string jsonString = JsonUtility.ToJson(sd);
        JObject retVal = JObject.Parse(jsonString);
        return retVal;
    }
    private class SaveData
    {
        public int totalCoins;
        public SaveData(int totalCoins)
        {
            this.totalCoins = totalCoins;
        }
    }
}
