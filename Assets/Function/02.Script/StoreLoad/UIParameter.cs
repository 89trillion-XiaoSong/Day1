using UnityEngine;
using UnityEngine.UI;

namespace Function._02.Script.StoreLoad
{
    public class UIParameter : MonoBehaviour        //UI相关参数
    {
        [SerializeField] private Text txtCostGold;      //卡片花费
        [SerializeField] private Image imgCard;         //卡片类型
        [SerializeField] private Text txtCardNumber;    //卡片数量
        [SerializeField] private Text txtCardTitle;     //卡片标题

        /// <summary>
        /// 设置卡片花费
        /// </summary>
        /// <param name="txt"></param>
        public void SetTxtCostCold(string txt)
        {
            txtCostGold.text = txt;
        }

        /// <summary>
        /// 设置卡片类型
        /// </summary>
        /// <param name="sprite"></param>
        public void SetImgCard(Sprite sprite)
        {
            imgCard.sprite = sprite;
        }

        /// <summary>
        /// 设置卡片数量
        /// </summary>
        /// <param name="txt"></param>
        public void SetTxtCardNumber(string txt)
        {
            txtCardNumber.text = txt;
        }

        /// <summary>
        /// 设置卡片标题
        /// </summary>
        /// <param name="txt"></param>
        public void SetTxtCardTitle(string txt)
        {
            txtCardTitle.text = txt;
        }
    }
}
