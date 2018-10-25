using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MainPanelMediator : EventMediator {

    [Inject]
    public MainPanel mainPanel { get; set; }

    public override void OnRegister()
    {
        
    }

    public override void OnRemove()
    {
        
    }
}
