using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoad
{
    public List<Save> PurseJson()          //解析Json文件数据到List
    {
        var textAsset= Resources.Load<TextAsset>("Data");
        
        JsonModel<Save> jsonObject = JsonUtility.FromJson<JsonModel<Save>>(textAsset.text);

        return jsonObject.dailyProduct;
    }
}
