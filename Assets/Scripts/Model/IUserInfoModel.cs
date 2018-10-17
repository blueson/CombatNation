using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserInfoModel {
    // 拥有的英雄的数据
    List<HeroInfoModel> heroList { get; set; }

    // 章节id
    int chapterId { get; set; }

    // 战斗章节id (只有战斗时才用)
    int fightChapterId { get; set; }

    // 钱币
    int money { get; set; }

    // 召唤池等级
    int summonLv { get; set; }

    void InitByUserInfoData(UserInfoData userInfoData);
}
