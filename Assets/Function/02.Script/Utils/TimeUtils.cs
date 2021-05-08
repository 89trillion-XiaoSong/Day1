﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUtils : MonoBehaviour
{
    public static string GetTime(int seconds)
    {
        int h = seconds / 60 / 60;
        int m = seconds / 60 % 60;
        int s = seconds % 60;
        return string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
    }
    
    public static IEnumerator CountDown(int timeCount, Text txtCountDown)
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
    }
}
