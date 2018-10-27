using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

public class FightContextView : ContextView {

    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        context = new FightContext(this);
    }
}
