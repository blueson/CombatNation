using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

public class StrangeContextView : ContextView {

    void Awake(){
        context = new StrangeContext(this);
    }
}
