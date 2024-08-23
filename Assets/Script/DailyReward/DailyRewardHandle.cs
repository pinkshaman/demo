using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardHandle : MonoBehaviour
{
    public DailyReward days;
    public DailyRewardProgess dailyRewardProgesss;
    public Text DayNumber;
    public Text RewardQuality;
    public Image RewardIMG;
    public Button Claim;
    public Image ClaimedIMG;


    public void Start()
    {
        Claim.onClick.AddListener(OnClickButtonDailyRewardClaim);
    }
    public void OnClickButtonDailyRewardClaim()
    {
        dailyRewardProgesss.hasClaim = true;
        ClaimedIMG.gameObject.SetActive(true);
        Claim.interactable = false;

    }
    public void SetData(DailyReward dayNumber, DailyRewardProgess progess)
    {
        this.days = dayNumber;
        this.dailyRewardProgesss = progess;
        UpdateUI();
    }
    public void UpdateUI()
    {
        DayNumber.text = $"Day {days.day}";
        RewardQuality.text = $"{days.Quality}";
        RewardIMG.sprite = days.RewardImage;
        CheckReward();
        CheckInteractable();
    }
    public void CheckReward()
    {
        if (dailyRewardProgesss.hasClaim == false)
        {

            Claim.interactable = true;
        }
        else
        {
            Claim.interactable = false;

        }
    }
    public void CheckInteractable()
    {
        if (dailyRewardProgesss.interactable == false)
        {
            Claim.interactable = false;
        }
        else
        {
            Claim.interactable = true;
            Debug.Log($"canClaim: {dailyRewardProgesss.day}-{dailyRewardProgesss.interactable=true}");
        }

    }
    public void UpdateDailyRewardProgess(DailyRewardProgess progess)
    {
        this.dailyRewardProgesss = progess;
        UpdateUI();
    }
}
