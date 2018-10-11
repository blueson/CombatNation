using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UserInfo
{
    // 拥有的英雄的数据
    public List<HeroInfo> heroList;

    // 章节id
    public int chapterId = 1;

    // 战斗章节id (只有战斗时才用)
    public int fightChapterId = 0;

    // 钱币
    public int money = 200;

    // 召唤池等级
    public int SummonLv = 0;


    public void AddHero(CharacterData info)
    {
        if (heroList == null)
        {
            heroList = new List<HeroInfo>();
        }

        heroList.Add(new HeroInfo { id = System.Guid.NewGuid().ToString(), characterId = info.id, lastHp = info.hp, lv = 1 });
    }


}
