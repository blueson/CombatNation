using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

public class StrangeContextView : ContextView {

    void Awake(){
        DontDestroyOnLoad(gameObject);
        context = new StrangeContext(this);
    }
}
