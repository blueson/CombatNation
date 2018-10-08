using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UserInfo
{
    // 拥有的英雄的数据
    public List<HeroInfo> heroList;

    // 章节id
    public int chapterId;

    // 钱币
    public int money;

    // 召唤池等级
    public int SummonLv;


    public void AddHero(CharacterData info)
    {
        if (heroList == null)
        {
            heroList = new List<HeroInfo>();
        }

        heroList.Add(new HeroInfo { id = System.Guid.NewGuid().ToString(), characterId = info.id, lastHp = info.hp, lv = 1 });
    }


}
