﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver{
    public UIPanelType panelType;
    public string panelTypeString;
    public string path;

    public void OnAfterDeserialize()
    {
        UIPanelType type = (UIPanelType)System.Enum.Parse(typeof(UIPanelType),panelTypeString);
        panelType = type;
    }

    public void OnBeforeSerialize()
    {
        //throw new NotImplementedException();
    }
}
