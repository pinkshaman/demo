using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class QuestHandle : MonoBehaviour
{
    public QuestData questdatas;
    public QuestProcessData progessdatas;
    public Text DecriptionText;
    public Text title;
    public Image reward;  
    public Image Fill;   
    public Text QuestProgessTxt;
    public Text rewardQualityText;
    public Button Claim;
    public Image RewardClaimed;
    public void Start()
    {
        Claim.onClick.AddListener(OnButtonClick);
        
    }
    public void SetData(QuestData dataX, QuestProcessData progessX)
    {
        Debug.Log("Setdata");
        this.progessdatas = progessX;
        this.questdatas = dataX;
        UpdateUi();
    }
    public void UpdateUi()
    {
        Debug.Log("UiUpdated");
        DecriptionText.text = questdatas.QuestDecription;
        title.text = questdatas.QuestName;
        reward.sprite = questdatas.QuestReward;
        rewardQualityText.text = questdatas.rewardQuality.ToString();
        QuestProgessTxt.text = $"{progessdatas.currentQuestProgess}/{questdatas.TaskCount}";
        

    }
    public void CheckQuest()
    {
        if (progessdatas.currentQuestProgess >= questdatas.TaskCount)
        {
            progessdatas.isComplete = true;
            Debug.Log("Mission Complete");
            Claim.interactable = true;
            Claim.image.color = Color.white;
        }
        else if (progessdatas.currentQuestProgess < questdatas.TaskCount)
        {
            progessdatas.isComplete = false;
            Claim.interactable =false;
            Claim.image.color = Color.gray;
        }   
    }
    public void OnButtonClick()
    {
        Claim.image.color = Color.black;
        RewardClaimed.gameObject.SetActive(true);
    }
    public void ProgressFill()
    {      
        float currentPercent = questdatas.TaskCount / 100.0f * progessdatas.currentQuestProgess;
        Fill.fillAmount = currentPercent;
        CheckQuest();

    }
    public void UpdateProgess()
    {
        
    }






}
