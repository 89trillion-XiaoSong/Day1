using UnityEngine;

public class HomePage : MonoBehaviour
{
    [SerializeField] private GameObject pnlStore;       //商店页面
    [SerializeField] private GameObject btnOpenStore;
    
    public void StoreClick()                            //按钮点击事件
    {
        GameObject stroePanel = Instantiate(pnlStore, transform);
        StoreDialog storeDialog = stroePanel.GetComponent<StoreDialog>();
        storeDialog.OnShowClick();
    }
}

