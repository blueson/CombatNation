using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour {

    public Text chapterText;
    public Text moneyText;

    private void Start()
    {
        var userInfo = DataManager.GetInstance().GetUserInfo();
        chapterText.text = "第" + userInfo.chapterId + "关";
        moneyText.text = "石头：" + userInfo.money;
    }

    public void ChouKaButtonClick(){
        var characterTable = CharacterTableData.CreateFromJson();
        var count = characterTable.data.Count;
        var randomIndex = (int)Random.Range(0,count);

        var userInfo = DataManager.GetInstance().GetUserInfo();
        userInfo.AddHero(characterTable.data[randomIndex]);

        DataManager.GetInstance().SaveUserInfo();
    }

    public void FightButtonClick(){

        var userinfo = DataManager.GetInstance().GetUserInfo();

        foreach(var info in userinfo.heroList){
            Debug.Log(info.characterId);
        }

        SceneManager.LoadSceneAsync(1,LoadSceneMode.Single);
    }
}
