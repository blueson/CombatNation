using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class AddMoneyButtonMediator : EventMediator {

    [Inject]
    public AddMoneyButtonView view { get; set; }

    public override void OnRegister()
    {
        view.dispatcher.AddListener(AddMoneyButtonView.BUTTON_CLICK,ButtonClick);
    }

    public override void OnRemove()
    {
        
    }

    void ButtonClick()
    {
        dispatcher.Dispatch(CommandEvent.AddMoney,100);
    }
}
