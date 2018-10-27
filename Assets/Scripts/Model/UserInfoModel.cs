using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UserInfoModel : IUserInfoModel
{
    public UserInfoModel()
    {
        heroList = new List<HeroInfoModel>();
        summonLv = 0;
        chapterId = 1;
        money = 200;
    }

    public List<HeroInfoModel> heroList { get; set; }

    public int chapterId { get; set; }
    public int fightChapterId { get; set; }
    public int money { get; set; }
    public int summonLv { get; set; }

    public void InitByUserInfoData(UserInfoData userInfoData)
    {
        chapterId = userInfoData.chapterId;
        money = userInfoData.money;
        summonLv = userInfoData.summonLv;
        fightChapterId = userInfoData.fightChapterId;

        foreach (var data in userInfoData.heroInfoData)
        {
            heroList.Add(new HeroInfoModel
            {
                id = data.id,
                lastHp = data.lastHp,
                characterId = data.characterId,
                lv = data.lv
            });
        }
    }
}
