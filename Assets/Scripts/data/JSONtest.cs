using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class PlayerInfo
{
    public int ID;
    public string Name;
    public double Gold;

    public PlayerInfo(int id, string name, double gold)
    {
        ID = id;
        Name = name;
        Gold = gold;
    }
}

public class JSONtest : MonoBehaviour
{
    public List<PlayerInfo> playerInfoList = new List<PlayerInfo>();

    // Start is called before the first frame update
    void Start()
    {
        SavePlayerInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerInfo()
    {
        playerInfoList.Add(new PlayerInfo(1, "Name #1", 10001));
        playerInfoList.Add(new PlayerInfo(2, "Name #2", 10002));
        playerInfoList.Add(new PlayerInfo(3, "Name #3", 10003));
        playerInfoList.Add(new PlayerInfo(4, "Name #4", 10004));

        JsonData infoJson = JsonMapper.ToJson(playerInfoList);
        File.WriteAllText(Application.dataPath + "/Resource/JSONData/PlayerInfoData.json", infoJson.ToString());
    }

    public void LoadPlayerInfo()
    {
        if (File.Exists(Application.dataPath + "/Resource/JSONData/PlayerInfoData.json"))
        {
            string jsonString = File.ReadAllText(Application.dataPath + "/Resource/JSONData/PlayerInfoData.json");
            Debug.Log(jsonString);

            JsonData playerData = JsonMapper.ToObject(jsonString);
            ParsingJsonPlayerInfo(playerData);
        }
    }

    private void ParsingJsonPlayerInfo(JsonData data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            Debug.Log(data[i]["ID"].ToString() + " , " +
                data[i]["Name"] + " , " + data[i]["Gold"]);

            int id = (int)data[i]["ID"];
            Debug.Log(id.ToString());
        }
    }
}
