using UnityEngine;

namespace Function._02.Script.StoreOpen
{
    public class Click : MonoBehaviour
    {
        [SerializeField] private GameObject pnlStore;       //商店页面

        public void StoreClick()                            //按钮点击事件
        {
            gameObject.SetActive((false));                  //隐藏按钮
            pnlStore.SetActive((true));                     //展示商店页面
        }
    }
}
