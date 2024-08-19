using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class QuestData
{
    //public QuestProcessData ProcessDatas;
    public int id;
    public string QuestName;
    public string QuestDecription;
    public Sprite QuestReward;
    public int TaskCount;
    public int rewardQuality;


}
//public struct DataQuest
//{
//    public QuestProcessData ProcessDatas;
//    public string QuestKey;
//    public string QuestName;
//    public string QuestDecription;
//    public string QuestProgressTxT;
//    public string QuestCurrentProgess;
//}
