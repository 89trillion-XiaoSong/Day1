﻿using System;
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

    public void OnShowClick()
    {
        gameObject.SetActive(true);
        _itemConfig = new ItemConfig();
        _dailyProducts = _itemConfig.dailyProducts;
        countDownTime = _itemConfig.dailyProductCountDown;
        
        InitItems();
        InitCountDown();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // foreach (var item in _dailyItems)
        // {
        //     Destroy(item.gameObject);
        // }
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

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
            _dailyItems.Add(item);
        }
    }

    private void InitCountDown()
    {
        StartCoroutine(TimeUtils.CountDown(countDownTime, txtCountDown));
    }
    
}
