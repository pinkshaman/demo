using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadMethod : MonoBehaviour
{
    [ContextMenu("LoadData")]
    public T LoadData<T>()
    {
        string key = typeof(T).Name;
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
}
