﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CommandEvent {
    GetChapterInfo, // 获取章节信息
    ChapterFight, // 章节战斗
    GetMoney, // 获取所有的钱
    GetRecruitMoney, // 获取招募一次需要的钱
    GetRecruitInfo, // 获取招募信息
    RecruitHero, // 招募英雄
    UnlockSummon, // 解锁招募池
    SaveAliveHero, // 保存剩下的英雄信息
    ChapterFightWin, // 章节挑战胜利
    AddMoney // 添加钱币
}
