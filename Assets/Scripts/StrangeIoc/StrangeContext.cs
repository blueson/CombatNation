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
        commandBinder.Bind(MainPanelCommandEvent.FubenFight).To<FightFubenCommand>();
        commandBinder.Bind(MainPanelCommandEvent.ChangeChapter).To<ChangeChapterCommmand>();
        commandBinder.Bind(FubenFightEvent.loadFightCharacter).To<LoadFightCharacterCommand>();


        commandBinder.Bind(MainPanelCommandEvent.GetChapterInfo).To<GetChapterInfoCommand>();

        //mediator
        mediationBinder.Bind<MainPanel>().To<MainPanelMediator>();
        mediationBinder.Bind<FightView>().To<FigthViewMediator>();


        mediationBinder.Bind<ChapterView>().To<ChapterViewMediator>();


        commandBinder.Bind(ContextEvent.START).To<StartCommand>();
    }
}
