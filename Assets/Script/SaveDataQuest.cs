using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SaveDataQuest : MonoBehaviour
{
    public QuestDataBase dataX;

    [ContextMenu("SaveDataJson")]
    public void SaveDataJson()
    {
        string key = JsonUtility.ToJson(new QuestDataBase { questDatas = dataX.questDatas });
        PlayerPrefs.SetString("QuestDataList", key);
        PlayerPrefs.Save();
    }
    [ContextMenu("LoadDataJson")]
    public void LoadDataJson()
    {
        if (PlayerPrefs.HasKey("QuestDataList"))
        {
            string key = PlayerPrefs.GetString("QuestDataList");
            QuestDataBase value = JsonUtility.FromJson<QuestDataBase>(key);

            dataX.questDatas = value.questDatas;
        }
    }
    public void LoadData()
    {

    }
    public void UpdateData()
    {
        Debug.Log("updated data");
    }
}
