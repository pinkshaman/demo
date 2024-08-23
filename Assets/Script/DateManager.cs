using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    public QuestManager questManager;
    public DailyRewardManager dailyRewardManager;
    public string Today;

    public Dictionary<int, string> LoggedDay;
    private const string LastSaveDateKey = "LastSaveDateKey";
    private const string CurrentDayIndexKey = "LastSaveCurrentIndex";
    private int CurrentDayIndex = 1;

    public void Start()
    {
        questManager = FindAnyObjectByType<QuestManager>();
        dailyRewardManager = FindAnyObjectByType<DailyRewardManager>();
        CheckDateAndResetIfNewDay();
        LoggedDay = new Dictionary<int, string>();
    }

    public void CheckDateAndResetIfNewDay()
    {
        DateTime today = DateTime.UtcNow.Date;
        if (PlayerPrefs.HasKey(LastSaveDateKey))
        {
            string SavedDate = PlayerPrefs.GetString(LastSaveDateKey);
            DateTime savedDate = DateTime.Parse(SavedDate);
            if (savedDate.Date < today)
            {
                SetNewDay();
                ResetData();
                SetCurrentDay();
                UnlockReward();
            }
        }
        else
        {
            ResetData();           
            SetNewDay();
        }
    }

    public void SetNewDay()
    {
        Today = System.DateTime.UtcNow.ToString("yyyy-MM-dd");
        PlayerPrefs.SetString(LastSaveDateKey, Today);
        PlayerPrefs.Save();
    }
    public void SetCurrentDay()
    {
        DateTime today = DateTime.UtcNow.Date;
        string SavedDate = PlayerPrefs.GetString(LastSaveDateKey);
        DateTime savedDate = DateTime.Parse(SavedDate);
        int daysPassed = (today - savedDate.Date).Days;
        var daysaved = PlayerPrefs.GetInt(CurrentDayIndexKey);
        CurrentDayIndex = daysaved + daysPassed;
        PlayerPrefs.SetInt(CurrentDayIndexKey, CurrentDayIndex);
        PlayerPrefs.Save();
    }
    public void UnlockReward()
    {

        foreach (var key in dailyRewardManager.DicDailyRewards.Keys)
        {
            if (key > CurrentDayIndex)
            {
                dailyRewardManager.DicDailyRewards[key].dailyRewardProgesss.interactable = false;
            }
            else
            {
                dailyRewardManager.DicDailyRewards[key].dailyRewardProgesss.interactable = true;
            }
        }
    }
    public void ResetData()
    {
        questManager.ClearData();

    }

}
