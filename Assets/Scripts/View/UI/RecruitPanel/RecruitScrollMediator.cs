using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class RecruitScrollMediator : EventMediator {



    [Inject]
    public RecruitScrollView view { get; set; }

    public override void OnRegister()
    {
        dispatcher.AddListener(MediatorEvent.GetRecruitInfo,GetRecruitInfo);

        dispatcher.Dispatch(CommandEvent.GetRecruitInfo);
    }

    public override void OnRemove()
    {
        
    }

    void GetRecruitInfo(IEvent evt){
        var summonInfoList = (List<Dictionary<string, System.Object>>)evt.data;
        view.UpdateRecruitView(summonInfoList);
    }
}
