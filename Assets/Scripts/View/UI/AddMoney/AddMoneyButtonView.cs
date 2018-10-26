using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class AddMoneyButtonView : View {

    public static int BUTTON_CLICK = 0;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void ButtonClick()
    {
        dispatcher.Dispatch(BUTTON_CLICK);
    }
}
