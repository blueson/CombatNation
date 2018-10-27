using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UserInfoData {
    public List<HeroInfoData> heroInfoData;

    // 章节id
    public int chapterId;

    // 钱币
    public int money;

    // 召唤池等级
    public int summonLv;

    // 战斗章节id
    public int fightChapterId;
	
}

[Serializable]
public class HeroInfoData{
    public string id;
    public int characterId;
    public int lastHp;
    public int lv;
}
