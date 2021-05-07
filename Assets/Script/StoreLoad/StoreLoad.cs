using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreLoad : MonoBehaviour
{
    public GameObject prefab_1; //三种主商品类型
    public GameObject prefab_2;
    public GameObject prefab_3;
    
    public Transform content;       //实例化对象父级
    private void Awake()
    {
        CardLoad();
    }

    private void CardLoad()
    {
        List<Save> list = new JsonLoad().PurseJson() ;      //数据列表

        foreach (var card in list)      //数据列表遍历
        {
            if (card.type == 1 || card.type == 2)             //钻石或金币
            {
                GameObject prefab = Instantiate(prefab_1, content);
                Purchase purchase = prefab.GetComponent<Purchase>();    //获得相关脚本组件
                UIParameter uiParameter = prefab.GetComponent<UIParameter>();
            
                if(card.isPurchased == 1)
                    purchase.PurchaseOperation();

                uiParameter.cardNumber.text = "x" + card.num.ToString();
                uiParameter.cardImage.sprite = Resources.Load<Sprite>("Coin/" + card.type);    //钻石或金币
                uiParameter.titleText.text = card.type == 1 ? "Coins" : "Diamonds";
            }
            else if (card.type == 3)        //卡片
            {
                GameObject prefab = Instantiate(prefab_2, content);
                Purchase purchase = prefab.GetComponent<Purchase>();
                UIParameter uiParameter = prefab.GetComponent<UIParameter>();
            
                if(card.isPurchased == 1)
                    purchase.PurchaseOperation();
            
                uiParameter.cardImage.sprite = Resources.Load<Sprite>("Card/" + card.subType);     //商品子类型
                uiParameter.costGold.text = card.costGold.ToString();
                uiParameter.cardNumber.text = "x" + card.num.ToString();
            }
        }
    
        for (int i = list.Count; i < 6; i++)        //剩余空位设置为未解锁
        {
            Instantiate(prefab_3, content);
        }
    }
}
