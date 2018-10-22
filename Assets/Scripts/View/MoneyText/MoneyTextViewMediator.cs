using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MoneyTextViewMediator : EventMediator {

    [Inject]
    public MoneyTextView view { get; set; }

    public override void OnRegister()
    {
        view.InitView();

        dispatcher.AddListener(MediatorEvent.GetMoney,GetMoney);

        dispatcher.Dispatch(CommandEvent.GetMoney);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(MediatorEvent.GetMoney,GetMoney);
    }

    void GetMoney(IEvent evt)
    {
        view.UpdateMoney((int)evt.data);
    }
}
