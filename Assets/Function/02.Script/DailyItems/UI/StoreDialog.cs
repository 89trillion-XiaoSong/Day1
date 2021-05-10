using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreDialog : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private DailyItem prefabCard;
    [SerializeField] private DailyItem prefabLock;
    [SerializeField] private Transform content;
    [SerializeField] private Text txtCountDown;

    private ItemConfig _itemConfig;
    private List<DailyProduct> _dailyProducts = new List<DailyProduct>();
    private List<DailyItem> _dailyItems = new List<DailyItem>();

    private int countDownTime;

    private const int maxShow = 6;

    //商店页面打开
    public void Init()
    {
        _itemConfig = new ItemConfig();
        _dailyProducts = _itemConfig.dailyProducts;
        countDownTime = _itemConfig.dailyProductCountDown;
        
        InitItems();
        InitCountDown();
    }

    //商店页面关闭
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }

    //生成商品，加入商品列表
    private void InitItems()
    {
        foreach (DailyProduct dailyProduct in _dailyProducts)
        {
            DailyItem item = Instantiate(prefabCard, content);
            item.InitItem(dailyProduct);
            _dailyItems.Add(item);
        }

        int cardCount = _dailyProducts.Count;
        for (int i = cardCount; i < maxShow; i++)
        {
            DailyItem item = Instantiate(prefabLock, content);
            item.isLock = true;
            _dailyItems.Add(item);
        }
    }

    //启动倒计时协程
    private void InitCountDown()
    {
        StartCoroutine(CountDown(countDownTime));
    }
    
    
    //倒计时协程
    private IEnumerator CountDown(int timeCount)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (timeCount > 0)
        {
            string timeString = GetTime(timeCount);
            txtCountDown.text = "Refresh Time : " + timeString;
            yield return waitForSeconds;
            timeCount--;
            string time = GetTime(timeCount);
            txtCountDown.text = "Refresh Time : " + time;
        }

        if (timeCount <= 0)
        {
            foreach (DailyItem item in _dailyItems)
            {
                if (!item.isLock)
                {
                    item.Refresh();    
                }
            }
            StartCoroutine(CountDown(countDownTime));
        }
    }
    
    //时间格式化
    private static string GetTime(int seconds)
    {
        int h = seconds / 60 / 60;
        int m = seconds / 60 % 60;
        int s = seconds % 60;
        return string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
    }
}
