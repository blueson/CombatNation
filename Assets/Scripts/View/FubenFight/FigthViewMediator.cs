using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FigthViewMediator : EventMediator {

    [Inject]
    public FightView fightView { get; set; }

    public override void OnRegister()
    {
        dispatcher.AddListener(MediatorEvent.LoadFightCharacter,LoadFightCharacter);
        dispatcher.AddListener(MediatorEvent.ChapterFightWin,ChapterFightWin);
        fightView.dispatcher.AddListener(FightView.FightUpdate,FightUpdate);

        dispatcher.Dispatch(FubenFightEvent.loadFightCharacter);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(MediatorEvent.LoadFightCharacter,LoadFightCharacter);
        dispatcher.RemoveListener(MediatorEvent.ChapterFightWin, ChapterFightWin);
    }

    void LoadFightCharacter(IEvent evt){
        var dataArray = (System.Object[])evt.data;

        var heroList = (List<Dictionary<string,System.Object>>)dataArray[0];
        var monsterList = (List<Dictionary<string, System.Object>>)dataArray[1];

        fightView.AddCharacter(heroList, true); //添加英雄模型
        fightView.AddCharacter(monsterList, false); //添加怪物模型
    }

    void FightUpdate()
    {
        bool isHeroAlive = false;
        bool isMonsterAlive = false;
        foreach(var role in fightView.roleList)
        {
            if(role.RoleType1 == Role.RoleType.HERO && role.Hp > 0){
                isHeroAlive = true;
            }

            if(role.RoleType1 == Role.RoleType.ENEMY && role.Hp > 0){
                isMonsterAlive = true;
            }
        }

        if(!isMonsterAlive)
        {
            Debug.Log("战斗胜利");
            FightWin();
        }
        else if (!isHeroAlive)
        {
            Debug.Log("战斗失败");
            FightOver();
        }
    }

    void FightWin()
    {
        dispatcher.Dispatch(CommandEvent.ChapterFightWin);
    }

    void FightOver()
    {
        fightView.dispatcher.RemoveListener(FightView.FightUpdate, FightUpdate);
        dispatcher.Dispatch(CommandEvent.SaveAliveHero, GetHeroList());


        SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
    }

    void ChapterFightWin()
    {
        FightOver();
    }

    List<Role> GetHeroList(){
        var heroList = new List<Role>();
        foreach (var role in fightView.roleList)
        {
            if (role.RoleType1 == Role.RoleType.HERO)
            {
                heroList.Add(role);
            }
        }
        return heroList;
    }
}
