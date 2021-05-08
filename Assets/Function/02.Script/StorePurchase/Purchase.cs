using UnityEngine;

namespace Function._02.Script.StorePurchase
{
    public class Purchase : MonoBehaviour
    {
        private Transform _slider;      //收集进度条
        private Transform _button;      //购买按钮
        private Transform _checkMark;   //对号，是否购买
        private Transform _tip;         //购买信息

        private void Awake()        
        {
            _slider = transform.Find("Slider");     //获得相应对象
            _button = transform.Find("Button");
            _checkMark = transform.Find("Check Mark");
            _tip = transform.Find("Tip");
        }

        public void PurchaseClick()     //购买按钮事件
        {
            PurchaseOperation();
        }

        public void PurchaseOperation()     //购买操作
        {
            if (_slider != null)
            {
                _slider.gameObject.SetActive(false);
            }
            _button.gameObject.SetActive((false));
            _checkMark.gameObject.SetActive((true));
            _tip.gameObject.SetActive(true);
        }
    }
}
