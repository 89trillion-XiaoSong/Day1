using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Save       //数据存储类
{
    public int productId;
    public int type;
    public int subType;
    public int num;
    public int costGold;
    public int isPurchased;
}


public class JsonModel<T>       //用于加载Json文件数据
{
    public List<T> dailyProduct;
}
