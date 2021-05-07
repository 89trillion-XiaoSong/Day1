using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject storePanel;   //商店页面

    public void StoreClick()        //按钮点击事件
    {
        gameObject.SetActive((false));
        storePanel.SetActive((true));
    }
}
