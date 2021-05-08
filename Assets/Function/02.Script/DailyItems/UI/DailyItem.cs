using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyItem : MonoBehaviour
{
    [SerializeField] private List<Sprite> itemPanelImg;
    [SerializeField] private List<Sprite> itemImgs;
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject checkMark;
    [SerializeField] private GameObject purchaseTip;
    [SerializeField] private GameObject btnPurchase;
    [SerializeField] private Text txtCardNum;
    [SerializeField] private Text txtCardCost;
    [SerializeField] private Text txtTitle;
    [SerializeField] private Text txtRare;
    [SerializeField] private Image imgCard;
    [SerializeField] private Image imgCardPanel;
    [SerializeField] private Image imgCardBackGround;

    //生成商品
    public void InitItem(DailyProduct dailyProduct)
    {
        CardCost(dailyProduct.costGold);
        CardImage((RewardType)dailyProduct.type,dailyProduct.subType);
        CardNum(dailyProduct.num);
    }

    //商品花费
    private void CardCost(int costGold)
    {
        if (costGold > 0)
        {
            txtCardCost.text = costGold.ToString();
        }
    }

    //商品image
    private void CardImage(RewardType type,int subType)
    {
        if (type == RewardType.Cards)
        {
            switch (subType)
            {
                case 7:
                    imgCard.sprite = itemImgs[2];
                    break;
                case 13:
                    imgCard.sprite = itemImgs[3];
                    break;
                case 18:
                    imgCard.sprite = itemImgs[4];
                    break;
                case 20:
                    imgCard.sprite = itemImgs[5];
                    break;
            }
        }
        else if (type == RewardType.Coins)
        {
            imgCard.sprite = itemImgs[0];
            txtTitle.text = "Coins";
            imgCardPanel.sprite = itemPanelImg[0];
            imgCardBackGround.sprite = itemPanelImg[1];
            slider.gameObject.SetActive(false);
            txtRare.gameObject.SetActive(false);
        }
        else if (type == RewardType.Diamonds)
        {
            imgCard.sprite = itemImgs[1];
            txtTitle.text = "Diamonds";
            imgCardPanel.sprite = itemPanelImg[0];
            imgCardBackGround.sprite = itemPanelImg[1];
            slider.gameObject.SetActive(false);
            txtRare.gameObject.SetActive(false);
        }
    }

    //商品数量
    private void CardNum(int num)
    {
        txtCardNum.text = "x" + num.ToString();
    }

    //打开商店
    public void OnPurchaseClick()
    {
        slider.SetActive(false);
        btnPurchase.SetActive((false));
        checkMark.SetActive(true);
        purchaseTip.SetActive(true);
    }
    
    //商店刷新
    public void Refresh()
    {
        slider.SetActive(true);
        btnPurchase.SetActive(true);
        checkMark.SetActive(false);
        purchaseTip.SetActive(false);
    }
}
