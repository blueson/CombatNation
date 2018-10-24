using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class RecruitItemMediator : EventMediator {

    [Inject]
    public RecruitItemView view { get; set; }

    int chooseSummonLv = 0;

    public override void OnRegister()
    {
        view.dispatcher.AddListener(RecruitPanelMediatorEvent.RecruitButtonClick,RecruitButtonClick);
        dispatcher.AddListener(MediatorEvent.GetRecruitMoney,GetRecruitMoney);

        dispatcher.Dispatch(CommandEvent.GetRecruitMoney);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(MediatorEvent.GetRecruitMoney,GetRecruitMoney);
    }

    void GetRecruitMoney(IEvent evt)
    {
        chooseSummonLv = (int)evt.data;
        view.UpdateRecruitMoneyText((int)evt.data);
    }

    void RecruitButtonClick()
    {
        dispatcher.Dispatch(CommandEvent.RecruitHero,chooseSummonLv);
    }
}
