using System.Collections;
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
        commandBinder.Bind(MainPanelCommandEvent.UpdateMainInfo).To<UpdateMainInfoCommand>();
        commandBinder.Bind(FubenFightEvent.loadFightCharacter).To<LoadFightCharacterCommand>();


        commandBinder.Bind(MainPanelCommandEvent.ChapterFight).To<ChapterFightCommand>();
        commandBinder.Bind(MainPanelCommandEvent.GetChapterInfo).To<GetChapterInfoCommand>();

        commandBinder.Bind(CommandEvent.GetMoney).To<GetMoneyCommand>();

        //mediator
        mediationBinder.Bind<MainPanel>().To<MainPanelMediator>();
        mediationBinder.Bind<FightView>().To<FigthViewMediator>();
        mediationBinder.Bind<MoneyTextView>().To<MoneyTextViewMediator>();


        mediationBinder.Bind<ChapterView>().To<ChapterViewMediator>();


        commandBinder.Bind(ContextEvent.START).To<StartCommand>();
    }
}
