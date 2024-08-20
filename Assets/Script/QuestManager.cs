using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public QuestProgessDataBase processDataBases;
    public QuestDataBase questDataBases;
    public QuestHandle questHandleItem;
    public Transform rootUi;
    public Transform RootUiTest;
    public TestBoardHandle boardHandle;
    public Dictionary<int, QuestHandle> IdQuestHandle;
    public void Start()
    {
        LoadDataJson();

        IdQuestHandle = new Dictionary<int, QuestHandle>();
        foreach (var datas in questDataBases.questDatas)
        {
            QuestProcessData processData = processDataBases.questProgessDatas.Find(processData => processData.id == datas.id);
            CreateQuest(datas, processData);
        }
    }
    public void CreateQuest(QuestData dataX, QuestProcessData progessX)
    {
        var quest = Instantiate(questHandleItem, rootUi);
        var questTest = Instantiate(boardHandle, RootUiTest);
        quest.SetData(dataX, progessX);
        questTest.SetData(progessX);
        IdQuestHandle.Add()
    }

    [ContextMenu("SaveDataJson")]
    public void SaveDataJson()
    {

        var value = JsonUtility.ToJson(processDataBases);
        PlayerPrefs.SetString(nameof(processDataBases), value);
        PlayerPrefs.Save();
    }


    [ContextMenu("LoadDataJson")]
    public void LoadDataJson()
    {
        var defautValue = JsonUtility.ToJson(processDataBases);
        var value = PlayerPrefs.GetString(nameof(processDataBases), defautValue);
        processDataBases = JsonUtility.FromJson<QuestProgessDataBase>(value);

    }

    [ContextMenu("LoadData")]
    public void LoadData()
    {
        var defautValue = JsonUtility.ToJson(questDataBases);
        var value = PlayerPrefs.GetString(nameof(questDataBases), defautValue);
        questDataBases = JsonUtility.FromJson<QuestDataBase>(value);

    }
    [ContextMenu("SaveData")]
    public void SaveData()
    {

        var value = JsonUtility.ToJson(questDataBases);
        PlayerPrefs.SetString(nameof(questDataBases), value);
        PlayerPrefs.Save();

    }
    public void OnApplicationQuit()
    {
        SaveDataJson();
    }
    public void UpdateQuestProgess(QuestProcessData questProcess)
    {
        var questIndex = processDataBases.questProgessDatas.FindIndex(progess => questProcess.id == progess.id);
        processDataBases.questProgessDatas[questIndex] = questProcess;
    }



}
