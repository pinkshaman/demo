using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DailyRewardProgess
{
    public int day;
    public bool hasClaim;
    public bool interactable;
}
[Serializable]
public class DailyRewardProgessBase
{
    public List<DailyRewardProgess> dailyRewardProgesses;

}
