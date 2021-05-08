using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public struct DailyProduct
{
    public int productId;
    public int type;
    public int subType;
    public int num;
    public int costGold;
    public int costGem;
    public int isPurchased;
}

public class ItemConfig
{
    public List<DailyProduct> dailyProducts = new List<DailyProduct>();     //数据列表
    public int dailyProductCountDown;

    //加载商品数据
    public ItemConfig()
    {
        JsonLoad();
    }

    //解析Json文件，读取数据
    private void JsonLoad()
    {
        var jsonFile = Resources.Load<TextAsset>("Json/Data");
        JSONNode jsonData = JSONNode.Parse(jsonFile.text);

        JSONArray dataArray = jsonData["dailyProduct"].AsArray;

        foreach (JSONNode node in dataArray)
        {
            DailyProduct dailyProduct = new DailyProduct();
            dailyProduct.productId = node["productId"].AsInt;
            dailyProduct.type = node["type"].AsInt;
            dailyProduct.subType = node["subType"].AsInt;
            dailyProduct.num = node["num"].AsInt;
            dailyProduct.costGold = node["costGold"].AsInt;
            dailyProduct.costGem = node["costGem"].AsInt;
            dailyProduct.isPurchased = node["isPurchased"].AsInt;
            this.dailyProducts.Add(dailyProduct);
        }

        this.dailyProductCountDown = jsonData["dailyProductCountDown"];
    }
}
