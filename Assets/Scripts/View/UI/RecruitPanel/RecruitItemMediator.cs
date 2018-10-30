using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class RecruitItemMediator : EventMediator {

    [Inject]
    public RecruitItemView view { get; set; }

    public override void OnRegister()
    {
        view.dispatcher.AddListener(RecruitPanelMediatorEvent.RecruitButtonClick,RecruitButtonClick);
    }

    public override void OnRemove()
    {
        
    }

    void RecruitButtonClick()
    {
        dispatcher.Dispatch(CommandEvent.RecruitHero,(int)view.summonInfo["lv"]);
    }
}
