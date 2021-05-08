using UnityEngine;

public class HomePage : MonoBehaviour
{
    [SerializeField] private GameObject pnlStore;       //商店页面
    [SerializeField] private GameObject btnOpenStore;
    
    //主页面按钮点击事件
    public void StoreClick()                            
    {
        GameObject stroePanel = Instantiate(pnlStore, transform);
        StoreDialog storeDialog = stroePanel.GetComponent<StoreDialog>();
        storeDialog.OnShowClick();
    }
}

