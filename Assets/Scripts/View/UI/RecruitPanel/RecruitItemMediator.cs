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
        view.dispatcher.AddListener(RecruitPanelMediatorEvent.UnlockButtonClick,UnlockButtonClick);

        dispatcher.AddListener(MediatorEvent.UnlockSummonOver,UnlockSummonOver);
    }

    public override void OnRemove()
    {
        
    }

    void UnlockButtonClick()
    {
        dispatcher.Dispatch(CommandEvent.UnlockSummon,(int)view.summonInfo["lv"]);
    }

    void RecruitButtonClick()
    {
        dispatcher.Dispatch(CommandEvent.RecruitHero,(int)view.summonInfo["lv"]);
    }

    void UnlockSummonOver()
    {
        dispatcher.Dispatch(CommandEvent.GetMoney);

        view.isOpen = true;
        view.UpdateSummonState();
    }
}
