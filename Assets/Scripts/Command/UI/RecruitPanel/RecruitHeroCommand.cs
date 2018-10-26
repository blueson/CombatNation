using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class RecruitHeroCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    [Inject]
    public IUserInfoService userInfoService { get; set; }

    string savePath = Application.persistentDataPath + "/" + "userInfoData.txt";
    SummonData summonData;
    CharacterTableData characterTable;

    public override void Execute()
    {
        int recruitCount = (int)evt.data; // 招募次数

        var summonTable = SummonTableData.CreateFromJson();
        characterTable = CharacterTableData.CreateFromJson();
        summonData = summonTable.GetSummonDataByLv(userInfoModel.summonLv);


        if(userInfoModel.money >= summonData.consume * recruitCount)
        {
            // 扣除需要的钱
            userInfoModel.money -= summonData.consume * recruitCount;

            for (int i = 0; i < recruitCount;i++)
            {
                RecruitHero();
            }

            userInfoService.SaveUserInfo(userInfoModel);
            dispatcher.Dispatch(CommandEvent.GetMoney);

        }
        else
        {
            Debug.Log("钱不够");   
        }
    }

    // 招募一次英雄
    void RecruitHero(){
        var index = GetProbabilityIndex(summonData.probability);
        var heroId = summonData.heroList[index];
        var characterData = characterTable.GetCharacterInfoById(heroId);
        userInfoModel.heroList.Add(new HeroInfoModel
        {
            id = System.Guid.NewGuid().ToString(),
            characterId = characterData.id,
            lastHp = characterData.hp,
            lv = 1
        });
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
