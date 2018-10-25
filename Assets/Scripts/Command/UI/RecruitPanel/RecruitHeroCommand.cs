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

    public override void Execute()
    {
        var summonTable = SummonTableData.CreateFromJson();
        var characterTable = CharacterTableData.CreateFromJson();
        var summonData = summonTable.GetSummonDataByLv(userInfoModel.summonLv);

        if(userInfoModel.money >= summonData.consume)
        {
            userInfoModel.money -= summonData.consume;
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

            userInfoService.SaveUserInfo(userInfoModel);


            dispatcher.Dispatch(CommandEvent.GetMoney);

        }
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
