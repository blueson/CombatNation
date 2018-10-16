﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MediatorEvent {
    // command 回调 mediator
    UpdateMainInfo,

    // view 调用 mediator
    LoadInfo
}
