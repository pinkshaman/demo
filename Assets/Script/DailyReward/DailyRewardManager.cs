using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DailyRewardManager : MonoBehaviour
{
    public DailyRewardProgessBase dailyRewardProgessBases;
    public DailyRewarded dailyRewadedss; 
    public Transform RootUiDailyReward;
    public DailyRewardHandle dailyRewardHandle;
   
    public Dictionary<int, DailyRewardHandle> DicDailyRewards;
    public void Start()
    {
        LoadDailyReward();
        DicDailyRewards = new Dictionary<int, DailyRewardHandle>();
        foreach (var datas in dailyRewadedss.DailyRewardeds)
        {
            DailyRewardProgess rewards = dailyRewardProgessBases.dailyRewardProgesses.Find(rewards => rewards.day == datas.day);
            CreateDailyReward(datas, rewards);
        }
    }
    public void CreateDailyReward(DailyReward reward , DailyRewardProgess progess)
    {
        var reWard = Instantiate(dailyRewardHandle, RootUiDailyReward);
        reWard.SetData(reward, progess);
        DicDailyRewards.Add(reward.day, reWard);
    }
    public void SaveDailyReward()
    {
        var value = JsonUtility.ToJson(dailyRewardProgessBases);
        PlayerPrefs.SetString(nameof(dailyRewardProgessBases), value);
        PlayerPrefs.Save();
    }
    public void LoadDailyReward()
    {
        var defaultValue = JsonUtility.ToJson(dailyRewardProgessBases);
        var json = PlayerPrefs.GetString(nameof(dailyRewardProgessBases), defaultValue);
        dailyRewardProgessBases = JsonUtility.FromJson<DailyRewardProgessBase>(json);
        Debug.Log("DailyReward is Loaded");
    }
    public void UpdateDailyRewardProgess(DailyRewardProgess progess)
    {
        var progessIndex = dailyRewardProgessBases.dailyRewardProgesses.FindIndex(progessreward => progess.day == progessreward.day);
        dailyRewardProgessBases.dailyRewardProgesses[progessIndex] = progess;
        DicDailyRewards[progess.day].UpdateDailyRewardProgess(progess);
    }
    
}
