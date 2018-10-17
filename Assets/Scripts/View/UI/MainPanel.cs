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
    public Text summonConsumeText;
    public Text moneyText;
    public Text upgradeText;

    private int chooseChapter = 0;


    public void Init(){
        dispatcher.Dispatch(MediatorEvent.LoadInfo);
    }

    // 更新界面信息
    public void UpdateTextInfo(int chapterId,int money,int summonMoney,int upMoney){
        chapterText.text = "第" + chapterId + "关";
        moneyText.text = money + "";
        summonConsumeText.text = "召唤消耗" + summonMoney;
        upgradeText.text = "升级消耗" + upMoney;
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
        var userinfo = DataManager.GetInstance().GetUserInfo();
        userinfo.fightChapterId = chooseChapter == 0 ? userinfo.chapterId : chooseChapter;
        SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive);
    }

    // 召唤池升级按钮事件
    public void UpgradeButtonClick(){
        var userInfo = DataManager.GetInstance().GetUserInfo();

        var consumeMoney = GetSummonUpgradeMoney();
        if(userInfo.money >= consumeMoney){

            userInfo.money -= consumeMoney;
            userInfo.summonLv += 1;

            DataManager.GetInstance().SaveUserInfo();

            //UpdateTextInfo();
        }
    }

    // 章节切换按钮事件
    public void ChapterChangeButtonClick(int changeNum){
        var userInfo = DataManager.GetInstance().GetUserInfo();
        chooseChapter = userInfo.chapterId;
        chooseChapter += changeNum;
        chooseChapter =  Mathf.Min(chooseChapter,userInfo.chapterId);
        chooseChapter = Mathf.Max(chooseChapter, 1);

        //UpdateTextInfo();
    }

    // 获取召唤池升级需要的金钱
    int GetSummonUpgradeMoney(){
        //var summonData = summonTable.GetSummonDataByLv(DataManager.GetInstance().GetUserInfo().SummonLv);
        //return summonData.upgrade;
        return 0;
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
