using System.Collections.Generic;
using UnityEngine;

namespace Function._02.Script.StoreLoad
{
    public class JsonLoad
    {
        /// <summary>
        /// 解析数据到 List
        /// </summary>
        /// <returns>数据列表</returns>
        public List<Save> PurseJson()          
        {
            var textAsset= Resources.Load<TextAsset>("Data");
        
            JsonModel<Save> jsonObject = JsonUtility.FromJson<JsonModel<Save>>(textAsset.text);

            return jsonObject.dailyProduct;
        }
    }
}
