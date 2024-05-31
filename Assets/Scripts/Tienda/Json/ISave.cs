using Newtonsoft.Json.Linq;

public interface ISave
{
    public JObject Serialize();

    public void DeSeriealize(string jsonString);
}
