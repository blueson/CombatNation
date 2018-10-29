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
        view.InitView();

        view.dispatcher.AddListener(RecruitPanelMediatorEvent.RecruitButtonClick,RecruitButtonClick);
        //dispatcher.AddListener(MediatorEvent.GetRecruitMoney,GetRecruitMoney);

        //dispatcher.Dispatch(CommandEvent.GetRecruitMoney);
    }

    public override void OnRemove()
    {
        //dispatcher.RemoveListener(MediatorEvent.GetRecruitMoney,GetRecruitMoney);
    }

    //void GetRecruitMoney(IEvent evt)
    //{
    //    view.UpdateRecruitMoneyText((int)evt.data);
    //}

    void RecruitButtonClick(IEvent evt)
    {
        dispatcher.Dispatch(CommandEvent.RecruitHero,(int)evt.data);
    }
}
