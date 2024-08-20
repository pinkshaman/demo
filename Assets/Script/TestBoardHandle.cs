
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class TestBoardHandle : MonoBehaviour
{
    //public Button SetBTData;
    //public Button Clear;
    //public Button Update;
    ////public InputField questProgessInputField;
    //public Text Message;
    //public QuestProcessData progessDatas;
    //public Text infor;
    //public InputField CurrentProgessInputField;
    //public Toggle IsCompleteToggle; 
    //public Toggle HasClaimedToggle;
    //private void Start()
    //{
        
    //    SetBTData.onClick.AddListener(OnSetButtonClick);
    //    Clear.onClick.AddListener(OnLoadButtonCLick);
    //    Update.onClick.AddListener(OnSaveButtonClick);
    //    IsCompleteToggle.onValueChanged.AddListener(IsComplete);
    //    HasClaimedToggle.onValueChanged.AddListener(HasClaimed);
    //}

    //public void SetData(QuestProcessData progessX)
    //{
    //    Debug.Log("Setdata");
    //    this.progessDatas = progessX;
    //    UpdateUi();
    //}

    //public void UpdateUi()
    //{
        
    //    infor.text =
    //        $"Quest ID:{progessDatas.id}\n" +
    //        $"isComplete: {progessDatas.isComplete}\n" +
    //        $"hasClaimed{progessDatas.hasClaimed} \n" +
    //        $"CurrentPG: {progessDatas.currentQuestProgess}";
        
    //}
 
    //public void IsComplete(bool isOn)
    //{             
    //    progessDatas.isComplete = isOn;
    //    Message.text = $"isComplete: {progessDatas.isComplete}";
    //    Debug.Log($"{progessDatas.isComplete}");
    //}

    //public void HasClaimed(bool isOn)
    //{      
    //    progessDatas.hasClaimed = isOn;
    //    Message.text = $"hasClaimed: {progessDatas.hasClaimed}";
    //    Debug.Log($"Claimed: {progessDatas.hasClaimed}");

    //}
    //public void OnSetButtonClick()
    //{
    //    int newValue = int.Parse(CurrentProgessInputField.text);
    //    progessDatas.currentQuestProgess = newValue;
    //    Message.text = $"NewProgessDataSet:{progessDatas.currentQuestProgess}";
    //    UpdateUi();
    //}

    //public void OnLoadButtonCLick()
    //{
    //    var defautValue = JsonUtility.ToJson(progessDatas);
    //    var value = PlayerPrefs.GetString(nameof(progessDatas), defautValue);
    //    progessDatas = JsonUtility.FromJson<QuestProcessData>(value);
    //    UpdateUi();
    //}
    
    //public void OnSaveButtonClick()
    //{
    //    var value = JsonUtility.ToJson(progessDatas);
    //    PlayerPrefs.SetString(nameof(progessDatas), value);
    //    PlayerPrefs.Save();
    //}
  
}

