using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class FigthViewMediator : EventMediator {

    [Inject]
    public FightView fightView { get; set; }

    public override void OnRegister()
    {
        dispatcher.AddListener(MediatorEvent.LoadFightCharacter,LoadFightCharacter);

        dispatcher.Dispatch(FubenFightEvent.loadFightCharacter);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(MediatorEvent.LoadFightCharacter,LoadFightCharacter);
    }

    void LoadFightCharacter(IEvent evt){
        var dataArray = (System.Object[])evt.data;

        var heroList = (List<Dictionary<string,System.Object>>)dataArray[0];
        var monsterList = (List<Dictionary<string, System.Object>>)dataArray[1];

        Debug.Log("输出获取的英雄个数");
        Debug.Log(heroList.Count);

        Debug.Log("输出获取的怪物的个数");
        Debug.Log(monsterList.Count);
    }
}
