using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour {

    public Text chapterText;
    public Text moneyText;
    public Text upgradeText;

    private void Start()
    {
        UpdateTextInfo();
    }

    // 更新界面信息
    void UpdateTextInfo(){
        var userInfo = DataManager.GetInstance().GetUserInfo();
        chapterText.text = "第" + userInfo.chapterId + "关";
        moneyText.text = "石头：" + userInfo.money;

        upgradeText.text = "升级消耗" + GetSummonUpgradeMoney();
    }

    // 抽卡按钮事件
    public void ChouKaButtonClick(){
        var characterTable = CharacterTableData.CreateFromJson();
        var count = characterTable.data.Count;
        var randomIndex = (int)Random.Range(0,count);

        var userInfo = DataManager.GetInstance().GetUserInfo();
        userInfo.AddHero(characterTable.data[randomIndex]);

        DataManager.GetInstance().SaveUserInfo();
    }

    // 战斗按钮事件
    public void FightButtonClick(){

        var userinfo = DataManager.GetInstance().GetUserInfo();

        foreach(var info in userinfo.heroList){
            Debug.Log(info.characterId);
        }

        SceneManager.LoadSceneAsync(1,LoadSceneMode.Single);
    }

    // 召唤池升级按钮事件
    public void UpgradeButtonClick(){
        var userInfo = DataManager.GetInstance().GetUserInfo();

        var consumeMoney = GetSummonUpgradeMoney();
        if(userInfo.money >= consumeMoney){

            userInfo.money -= consumeMoney;
            userInfo.SummonLv += 1;

            DataManager.GetInstance().SaveUserInfo();

            UpdateTextInfo();
        }
    }

    // 获取召唤池升级需要的金钱
    private int GetSummonUpgradeMoney(){
        var summonTable = SummonTableData.CreateFromJson();
        var summonData = summonTable.GetSummonDataById(DataManager.GetInstance().GetUserInfo().SummonLv + 1);
        return summonData.consume;
    }
}
