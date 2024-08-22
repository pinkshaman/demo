using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class TestBoadHandleII : MonoBehaviour
{
    public QuestManager questManager;
    public InputField progessInputText;
    public Button saveButon;
    public Button loadButon;
    public Button updateButon;
    public Button clearButton;
    public Text message;
    public Text inforShow;
    public Text questShow;
    public Dropdown questList;

    private int SelectedQuestKey;
    private void Start()
    {

        questManager = FindObjectOfType<QuestManager>();
        if (questManager == null)
        {
            Debug.LogError("QuestManager not found. Make sure there is a QuestManager in the scene.");

        }

        if (questManager.IdQuestHandle == null)
        {
            Debug.LogError("IdQuestHandle is null in QuestManager.");

        }

        if (questList == null)
        {
            Debug.LogError("Dropdown questList is not assigned.");

        }
        SetDropdown(questManager.IdQuestHandle);
        saveButon.onClick.AddListener(OnSaveButtonClick);
        loadButon.onClick.AddListener(OnLoadButtonClick);
        updateButon.onClick.AddListener(OnUpDateButtonClick);
        clearButton.onClick.AddListener(OnClearButtonClick);
        questList.onValueChanged.AddListener(OnDropdownValueChanged);
    }
    public void OnUpDateButtonClick()
    {
        if (questManager.IdQuestHandle.ContainsKey(SelectedQuestKey))
        {
            QuestHandle selecQuestHandle = questManager.IdQuestHandle[SelectedQuestKey];
            int newValue = int.Parse(progessInputText.text);
            selecQuestHandle.progessdatas.currentQuestProgess = newValue;
            questManager.UpdateQuestProgess(selecQuestHandle.progessdatas);

            ShowInfor(SelectedQuestKey);
        }
    }
    public void OnClearButtonClick()
    {
        PlayerPrefs.DeleteAll();
        message.text = "Data Deleted";
        ShowInfor(SelectedQuestKey);
    }
    public void OnSaveButtonClick()
    {
        questManager.SaveDataJson();
        message.text = "DataSaved";
    }
    public void OnLoadButtonClick()
    {
        questManager.LoadDataJson();
        SetDropdown(questManager.IdQuestHandle);
        ShowInfor(SelectedQuestKey);
    }
    public void ShowInfor(int keyIndex)
    {
        var selectedQuest = questManager.IdQuestHandle[keyIndex];

        inforShow.text = $"Quest ID :{selectedQuest.progessdatas.id}\n" +
            $"Progess :{selectedQuest.progessdatas.currentQuestProgess}\n" +
            $"isComplete : {selectedQuest.progessdatas.isComplete}\n" +
            $"hasClaim :{selectedQuest.progessdatas.hasClaimed}\n";
        ShowInforDataQuest(keyIndex);
    }
    public void ShowInforDataQuest(int keyIndex)
    {
        var selectedQuest = questManager.IdQuestHandle[keyIndex];

        questShow.text =
            $"QuestDataID :{selectedQuest.questdatas.id}\n" +
            $"TotalProgess:{selectedQuest.questdatas.TaskCount}\n" +
            $"QuestName : {selectedQuest.questdatas.QuestName}\n" +
            $"QuestDecripton: {selectedQuest.questdatas.QuestDecription}\n" +
            $" Quest Reward :{selectedQuest.questdatas.QuestReward}\n" +
            $"Quality :{selectedQuest.questdatas.rewardQuality} \n";
    }
    public void OnDropdownValueChanged(int keyIndex)
    {

        SelectedQuestKey = new List<int>(questManager.IdQuestHandle.Keys)[keyIndex];
        ShowInfor(SelectedQuestKey);
    }

    public void SetDropdown(Dictionary<int, QuestHandle> data)
    {
        questList.ClearOptions();

        List<string> options = new List<string>();
        foreach (var quest in data)
        {          
            string datas = $"Quest ID: {quest.Value.progessdatas.id} - {quest.Value.questdatas.QuestName}";
            options.Add(datas);
        }
        questList.AddOptions(options);
        Debug.Log($"Dropdown is Set: {options.Count}");

        SelectedQuestKey = data.Keys.ElementAt(0); 
        ShowInfor(SelectedQuestKey);
      

    }
}
