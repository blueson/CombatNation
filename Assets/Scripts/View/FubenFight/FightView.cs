using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class FightView : View {

    [Inject]
    public IEventDispatcher dispatcher { get; set; }


}
