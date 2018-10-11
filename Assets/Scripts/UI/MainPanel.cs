using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : BasePanel {

    public Text chapterText;
    public Text summonConsumeText;
    public Text moneyText;
    public Text upgradeText;

    private SummonTableData summonTable;
    private CharacterTableData characterTable;
    private int chooseChapter = 0;

    private void Start()
    {
        summonTable = SummonTableData.CreateFromJson();
        characterTable = CharacterTableData.CreateFromJson();
        UpdateTextInfo();
    }

    // 更新界面信息
    void UpdateTextInfo(){
        var userInfo = DataManager.GetInstance().GetUserInfo();
        if (chooseChapter == 0)
        {
            chapterText.text = "第" + userInfo.chapterId + "关";
        }
        else
        {
            chapterText.text = "第" + chooseChapter + "关";
        }
        moneyText.text = userInfo.money + "";
        summonConsumeText.text = "召唤消耗" + summonTable.GetSummonDataByLv(userInfo.SummonLv).consume;
        upgradeText.text = "升级消耗" + GetSummonUpgradeMoney();
    }

    // 抽卡按钮事件
    public void ChouKaButtonClick(){
        var userInfo = DataManager.GetInstance().GetUserInfo();
        var summonData = summonTable.GetSummonDataByLv(userInfo.SummonLv);
        if(userInfo.money >= summonData.consume){

            userInfo.money -= summonData.consume;
            DataManager.GetInstance().SaveUserInfo();

            var index = GetProbabilityIndex(summonData.probability);
            var heroId = summonData.heroList[index];
            userInfo.AddHero(characterTable.GetCharacterInfoById(heroId));
            DataManager.GetInstance().SaveUserInfo();

            UpdateTextInfo();
        }
    }

    // 战斗按钮事件
    public void FightButtonClick(){
        var userinfo = DataManager.GetInstance().GetUserInfo();
        userinfo.fightChapterId = chooseChapter == 0 ? userinfo.chapterId : chooseChapter;
        UIManager.Instance().PopPanel();
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

    // 章节切换按钮事件
    public void ChapterChangeButtonClick(int changeNum){
        var userInfo = DataManager.GetInstance().GetUserInfo();
        chooseChapter = userInfo.chapterId;
        chooseChapter += changeNum;
        chooseChapter =  Mathf.Min(chooseChapter,userInfo.chapterId);
        chooseChapter = Mathf.Max(chooseChapter, 1);

        UpdateTextInfo();
    }

    // 获取召唤池升级需要的金钱
    int GetSummonUpgradeMoney(){
        var summonData = summonTable.GetSummonDataByLv(DataManager.GetInstance().GetUserInfo().SummonLv);
        return summonData.upgrade;
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
