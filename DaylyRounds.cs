
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylyRounds : MonoBehaviour
{

    private void Start()
    {
        if (chick_DailyEntry())
        {
            Debug.Log("first entry today");
            PlayerPrefs.SetInt(IConstance.playeRonds, 0);

        }
    }
    bool chick_DailyEntry()
    {
        int CollectOn = 24;
        bool status;
        DateTime CurentDate = new DateTime();
        CurentDate = DateTime.Now;
        int OD = PlayerPrefs.GetInt(IConstance.Day, CurentDate.Day);
        int OM = PlayerPrefs.GetInt(IConstance.month, CurentDate.Month);
        int OY = PlayerPrefs.GetInt(IConstance.Year, CurentDate.Year);
        DateTime oldDate = new DateTime(OY, OM, OD);

        var Different = (CurentDate - oldDate).TotalHours;
        int hr = (int)Different;
        if (hr >= CollectOn || PlayerPrefs.GetInt(IConstance.FirstEntry, 0) == 0)
        {
            status = true;
            PlayerPrefs.SetInt(IConstance.Day, CurentDate.Day);
            PlayerPrefs.SetInt(IConstance.month, CurentDate.Month);
            PlayerPrefs.SetInt(IConstance.Year, CurentDate.Year);
            PlayerPrefs.SetInt(IConstance.FirstEntry, 1);
        }
        else
            status = false;

        return status;
    }
}
