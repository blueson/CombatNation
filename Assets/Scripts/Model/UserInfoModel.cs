using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UserInfoModel : IUserInfoModel
{
    public UserInfoModel(){
        heroList = new List<HeroInfoModel>();
        SummonLv = 0;
        chapterId = 1;
        money = 200;
    }

    public List<HeroInfoModel> heroList { get; set; }

    public int chapterId { get; set; }
    public int fightChapterId { get; set; }
    public int money { get; set; }
    public int SummonLv { get; set; }
}
