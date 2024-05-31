using Newtonsoft.Json.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/LevelData")]

public class LevelData : Data
{
    public int ratonesMoneda;
    public int distanciaRecord;

    public override void DeSeriealize(string jsonString)
    {
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonString);

        ratonesMoneda = sd.ratonesMoneda;
        distanciaRecord = sd.distanciaRecord;

    }

    public override JObject Serialize()
    {
        SaveData sd = new SaveData(ratonesMoneda, distanciaRecord);
        string jsonString = JsonUtility.ToJson(sd);
        JObject retVal = JObject.Parse(jsonString);

        return retVal;
    }



    private class SaveData
    {
        public int ratonesMoneda;
        public int distanciaRecord;

        public SaveData(int ratonesMoneda, int distanciaRecord)
        {
            this.ratonesMoneda = ratonesMoneda;
            this.distanciaRecord = distanciaRecord;
        }
    }

}
