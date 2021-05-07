using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Click : MonoBehaviour
{
    public GameObject storePanel;   //商店页面

    public GameObject prefab_1; //三种主商品类型
    public GameObject prefab_2;
    public GameObject prefab_3;

    public Transform content;       //实例化对象父级

    public void StoreClick()        //按钮点击事件
    {
        gameObject.SetActive((false));
        storePanel.SetActive((true));

        List<Save> list = PurseJson();      //数据列表

        foreach (var card in list)      //数据列表遍历
        {
            if (card.type == 1 || card.type == 2)             //钻石或金币
            {
                GameObject prefab = Instantiate(prefab_1, content);
                Purchase purchase = prefab.GetComponent<Purchase>();    //获得相关脚本组件
                
                if(card.isPurchased == 1)
                    purchase.PurchaseOperation();

                purchase.cardNumber.text = "x" + card.num.ToString();
                purchase.cardImage.sprite = Resources.Load<Sprite>("Coin/" + card.type);    //钻石或金币
                purchase.titleText.text = card.type == 1 ? "Coins" : "Diamonds";
            }
            else if (card.type == 3)        //卡片
            {
                GameObject prefab = Instantiate(prefab_2, content);
                Purchase purchase = prefab.GetComponent<Purchase>();
                
                if(card.isPurchased == 1)
                    purchase.PurchaseOperation();
                
                purchase.cardImage.sprite = Resources.Load<Sprite>("Card/" + card.subType);     //商品子类型
                purchase.costGold.text = card.costGold.ToString();
                purchase.cardNumber.text = "x" + card.num.ToString();
            }
        }
        
        for (int i = list.Count; i < 6; i++)        //剩余空位设置为未解锁
        {
            Instantiate(prefab_3, content);
        }
    }

    private List<Save> PurseJson()          //解析Json文件数据到List
    {
        var textAsset= Resources.Load<TextAsset>("Data");
        
        JsonModel<Save> jsonObject = JsonUtility.FromJson<JsonModel<Save>>(textAsset.text);

        return jsonObject.dailyProduct;
    }
}
