using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class TestBoadHandle2 : MonoBehaviour
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

        if (questManager.IdQuestHandle != null)
        {
            questManager = FindObjectOfType<QuestManager>();
        }
        if (questManager == null)
        {
            Debug.LogError("QuestManager not found. Make sure there is a QuestManager in the scene.");
            return;
        }

        if (questManager.IdQuestHandle == null)
        {
            Debug.LogError("IdQuestHandle is null in QuestManager.");
            return;
        }

        if (questList == null)
        {
            Debug.LogError("Dropdown questList is not assigned.");
            return;
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
        ShowInforDataQuest( keyIndex);
    }
    public void ShowInforDataQuest(int keyIndex)
    {
        var selectedQuest = questManager.IdQuestHandle[keyIndex];

        questShow.text =
            $"{selectedQuest.questdatas.id}:QuestDataID\n" +
            $"{selectedQuest.questdatas.TaskCount}: TotalProgess\n" +
            $" {selectedQuest.questdatas.QuestName} : QuestName \n" +
            $"{selectedQuest.questdatas.QuestDecription}: QuestDecripton\n" +
            $" :{selectedQuest.questdatas.QuestReward}: Quest Reward\n" +
            $"{selectedQuest.questdatas.rewardQuality}: Quality \n";
    }
    public void OnDropdownValueChanged(int keyIndex)
    {       
        if (questManager.IdQuestHandle.Count > keyIndex)
        {
            SelectedQuestKey = new List<int>(questManager.IdQuestHandle.Keys)[keyIndex]; 
            ShowInfor(SelectedQuestKey); 
        }
    }
    public void SetDropdown(Dictionary<int, QuestHandle> data)
    {
        questList.ClearOptions();   
        List<string> options = data.Values.Select(quest => $"Quest ID: {quest.progessdatas.id} - {quest.questdatas.QuestName}").ToList();

        questList.AddOptions(options);
        Debug.Log($"Dropdown is Set: {options.Count}");
        // Đặt giá trị mặc định cho Dropdown (chọn phần tử đầu tiên nếu có)
        if (options.Count > 0)
        {
            questList.value = 0;
            SelectedQuestKey = data.Keys.ElementAt(0); // Đặt SelectedQuestKey thành khóa của mục đầu tiên
            ShowInfor(SelectedQuestKey);
            // Hiển thị thông tin của mục đầu tiên
        }
        
    }
}
