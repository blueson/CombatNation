using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class SaveAliveHeroCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    [Inject]
    public IUserInfoService userInfoService { get; set; }

    public override void Execute()
    {
        var heroList = (List<Role>)evt.data;

        var delHeroIdList = new List<HeroInfoModel>();
        for (var i = 0; i < userInfoModel.heroList.Count; i++)
        {
            bool isHaveHero = false;
            foreach (var hero in heroList)
            {
                if (hero.HeroInfoId == userInfoModel.heroList[i].id)
                {
                    isHaveHero = true;

                    userInfoModel.heroList[i].lastHp = hero.Hp;
                }
            }

            if (!isHaveHero)
            {
                delHeroIdList.Add(userInfoModel.heroList[i]);
            }
        }

        foreach (var del in delHeroIdList)
        {
            userInfoModel.heroList.Remove(del);
        }

        userInfoService.SaveUserInfo(userInfoModel);
    }
}
