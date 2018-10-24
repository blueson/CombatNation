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

        Debug.Log("招募英雄");

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



            // 保存英雄信息
            var heroInfoList = new List<HeroInfoData>();
            foreach (var model in userInfoModel.heroList)
            {
                heroInfoList.Add(new HeroInfoData
                {
                    id = model.id,
                    characterId = model.characterId,
                    lastHp = model.lastHp,
                    lv = model.lv
                });
            }

            // 保存用户信息
            var userInfoData = new UserInfoData
            {
                chapterId = userInfoModel.chapterId,
                summonLv = userInfoModel.summonLv,
                money = userInfoModel.money,
                heroInfoData = heroInfoList
            };

            userInfoService.SaveUserInfo(savePath, JsonUtility.ToJson(userInfoData));

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
