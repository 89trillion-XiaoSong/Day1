using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    private Transform _slider;
    private Transform _button;
    private Transform _checkMark;
    private Transform _tip;

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
        if(_slider!=null)
            _slider.gameObject.SetActive(false);
        _button.gameObject.SetActive((false));
        _checkMark.gameObject.SetActive((true));
        _tip.gameObject.SetActive(true);
    }
}
