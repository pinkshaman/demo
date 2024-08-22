using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[Serializable]

public class LoginDay
{
    public string Day = System.DateTime.Now.ToString("yyyy-MM-dd");
    bool IsTodayLogged;

}


public class Date : MonoBehaviour
{
    public QuestManager questManager;
    public string Today;
    public string LastLoginDay;
    

    public void Start()
    {       
         questManager = FindAnyObjectByType<QuestManager>();
        CheckDateAndResetIfNewDay();
    }

    public void CheckDateAndResetIfNewDay()
    {

    }
    public void SetNewDay()
    {
        Today = System.DateTime.Now.ToString("yyyy-MM-dd");


    }
    public void SetDayLogged()
    {
      
    }


}
