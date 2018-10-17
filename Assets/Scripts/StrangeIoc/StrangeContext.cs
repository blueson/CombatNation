﻿using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

public class StrangeContext : MVCSContext {

    public StrangeContext(MonoBehaviour view):base(view){}

    protected override void mapBindings()
    {
        //model
        injectionBinder.Bind<IUserInfoModel>().To<UserInfoModel>().ToSingleton();

        //service
        injectionBinder.Bind<IUserInfoService>().To<UserInfoService>().ToSingleton();

        //controller
        commandBinder.Bind(CommandEvent.UpdateMainInfo).To<UpdateMainInfoCommand>();

        //mediator
        mediationBinder.Bind<MainPanel>().To<MainPanelMediator>();


        commandBinder.Bind(ContextEvent.START).To<StartCommand>();
    }
}