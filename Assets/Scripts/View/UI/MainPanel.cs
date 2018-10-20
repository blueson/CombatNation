using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : View {

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public Text chapterText;
    public Text moneyText;

    private int chooseChapter = 0;


    public void Init(){
        dispatcher.Dispatch(MainPanelMediatorEvent.LoadInfo);
    }

    // 更新界面信息
    public void UpdateTextInfo(int chapterId,int money,int summonMoney,int upMoney){
        UpdateChapterInfo(chapterId);
        moneyText.text = money + "";
        //summonConsumeText.text = "召唤消耗" + summonMoney;
        //upgradeText.text = "升级消耗" + upMoney;
    }

    // 更新关卡信息
    public void UpdateChapterInfo(int chapterId){
        chapterText.text = "第" + chapterId + "关";
    }

    // 抽卡按钮事件
    public void ChouKaButtonClick(){
        //var userInfo = DataManager.GetInstance().GetUserInfo();
        //var summonData = summonTable.GetSummonDataByLv(userInfo.SummonLv);
        //if(userInfo.money >= summonData.consume){

        //    userInfo.money -= summonData.consume;
        //    DataManager.GetInstance().SaveUserInfo();

        //    var index = GetProbabilityIndex(summonData.probability);
        //    var heroId = summonData.heroList[index];
        //    userInfo.AddHero(characterTable.GetCharacterInfoById(heroId));
        //    DataManager.GetInstance().SaveUserInfo();

        //    UpdateTextInfo();
        //}
    }

    // 战斗按钮事件
    public void FightButtonClick(){
        dispatcher.Dispatch(MainPanelMediatorEvent.FightClick);
    }

    // 召唤池升级按钮事件
    public void UpgradeButtonClick(){
        //var userInfo = DataManager.GetInstance().GetUserInfo();

        //var consumeMoney = GetSummonUpgradeMoney();
        //if(userInfo.money >= consumeMoney){

        //    userInfo.money -= consumeMoney;
        //    userInfo.summonLv += 1;

        //    DataManager.GetInstance().SaveUserInfo();

        //    UpdateTextInfo();
        //}
    }

    // 章节切换按钮事件
    public void ChapterChangeButtonClick(int changeNum){
        dispatcher.Dispatch(MainPanelMediatorEvent.ChangeChooseChapter,changeNum);
    }

    // 根据概率获取物品 [0.2,0.4,0.8,1]
    int GetProbabilityIndex(float[] probabilityArray)
    {
        var random = Random.Range(0, 1);

        for (int i = 0; i < probabilityArray.Length; i++)
        {
            if (random <= probabilityArray[i])
            {
                return i;
            }
        }
        return probabilityArray.Length - 1; // 获取最后一个
    }
}
