using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MainPanelMediator : EventMediator {

    [Inject]
    public MainPanel mainPanel { get; set; }

    public override void OnRegister()
    {
        mainPanel.Init();


    }

    public override void OnRemove()
    {
        
    }
}
