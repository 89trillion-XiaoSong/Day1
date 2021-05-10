using UnityEngine;

public class HomePage : MonoBehaviour
{
    [SerializeField] private StoreDialog pnlStore;       //商店页面

    //主页面按钮点击事件
    public void StoreClick()                            
    {
        StoreDialog storeDialog = Instantiate(pnlStore, transform);
        
        storeDialog.gameObject.SetActive(true);
        storeDialog.Init();
    }
}

