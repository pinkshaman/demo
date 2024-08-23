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
    public TestBoadHandleII boadHandle2;
    public Transform rootTestUI;
    public Dictionary<int, QuestHandle> IdQuestHandle;

    public void Start()
    {       
        LoadDataJson();
        IdQuestHandle = new Dictionary<int, QuestHandle>();
        Debug.Log("IdQuestHanle is Created");
        foreach (var datas in questDataBases.questDatas)
        {
            QuestProcessData processData = processDataBases.questProgessDatas.Find(processData => processData.id == datas.id);
            CreateQuest(datas, processData);
        }      
    }
    public void CreateQuest(QuestData dataX, QuestProcessData progessX)
    {
        var quest = Instantiate(questHandleItem, rootUi);
        quest.SetData(dataX, progessX);       
        IdQuestHandle.Add(dataX.id, quest);
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
        var defaultValue = JsonUtility.ToJson(processDataBases);
        var json = PlayerPrefs.GetString(nameof(processDataBases), defaultValue);
        processDataBases = JsonUtility.FromJson<QuestProgessDataBase>(json);
        Debug.Log("LoadDataJson is Loaded");
    }
    public void ClearData()
    {
        if (PlayerPrefs.HasKey(nameof(processDataBases)))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    [ContextMenu("LoadData")]
    public T  LoadData<T>()
    {       string key = typeof(T).Name;
        if (PlayerPrefs.HasKey(key))
        {          
            var value = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(value);
        }
        else
        {
            return default(T);
        }
    }

    [ContextMenu("SaveData")]
    public void SaveData<T>(T data)
    {

        var value = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(typeof(T).Name, value);
        PlayerPrefs.Save();
    }

    public void OnApplicationQuit()
    {
        SaveDataJson();
    }
    public void UpdateQuestProgess(QuestProcessData questProgess)
    {
        var questIndex = processDataBases.questProgessDatas.FindIndex(progess => questProgess.id == progess.id);
        processDataBases.questProgessDatas[questIndex] = questProgess;
        IdQuestHandle[questProgess.id].UpdateProgess(questProgess);
    }
}
