using System.Collections.Generic;
using Function._02.Script.StorePurchase;
using UnityEngine;

namespace Function._02.Script.StoreLoad
{
    public class StoreLoad : MonoBehaviour
    {
        [SerializeField]private GameObject prefab1; //三种商品类型
        [SerializeField]private GameObject prefab2;
        [SerializeField]private GameObject prefab3;
    
        [SerializeField] private Sprite coin;       //金币和钻石
        [SerializeField] private Sprite diamonds;
    
        [SerializeField] private Transform content;       //实例化对象父级
        private void Awake()
        {
            CardLoad();
        }

        /// <summary>
        /// 卡片初始化   
        /// </summary>
        private void CardLoad()
        {
            List<Save> list = new JsonLoad().PurseJson() ;      //数据列表

            foreach (var card in list)                     //数据列表遍历
            {
                if (card.type == 1 || card.type == 2)           //钻石或金币
                {
                    GameObject prefab = Instantiate(prefab1, content);                  //生成免费物品
                    Purchase purchase = prefab.GetComponent<Purchase>();                //获得相关脚本组件
                    UIParameter uiParameter = prefab.GetComponent<UIParameter>();

                    if (card.isPurchased == 1)                                           //是否购买
                    {
                        purchase.PurchaseOperation();
                    }
                
                    uiParameter.SetTxtCardNumber("x" + card.num.ToString());            //数量
                    uiParameter.SetImgCard(card.type == 1 ? coin : diamonds);           //钻石或金币
                    uiParameter.SetTxtCardTitle(card.type == 1 ? "Coins" : "Diamonds"); //标题
                }
                else if (card.type == 3)        //卡片
                {
                    GameObject prefab = Instantiate(prefab2, content);                  //生成卡片类型商品
                    Purchase purchase = prefab.GetComponent<Purchase>();                //获取相关组件
                    UIParameter uiParameter = prefab.GetComponent<UIParameter>();

                    if (card.isPurchased == 1)                                          //是否购买
                    {
                        purchase.PurchaseOperation();
                    }

                    uiParameter.SetImgCard(Resources.Load<Sprite>("Card/" + card.subType));   //商品子类型
                    uiParameter.SetTxtCostCold(card.costGold.ToString());               //花费
                    uiParameter.SetTxtCardNumber("x" + card.num.ToString());            //数量
                }
            }
    
            for (int i = list.Count; i < 6; i++)        //剩余空位设置为未解锁卡片
            {
                Instantiate(prefab3, content);
            }
        }
    }
}
