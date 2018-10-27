using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

public class FightContext : MVCSContext {

    public FightContext(MonoBehaviour view):base(view){ }

    protected override void mapBindings()
    {
        //model
        injectionBinder.Bind<IUserInfoModel>().To<UserInfoModel>().ToSingleton();

        //service
        injectionBinder.Bind<IUserInfoService>().To<UserInfoService>().ToSingleton();

        commandBinder.Bind(FubenFightEvent.loadFightCharacter).To<LoadFightCharacterCommand>();
        commandBinder.Bind(CommandEvent.SaveAliveHero).To<SaveAliveHeroCommand>();
        commandBinder.Bind(CommandEvent.ChapterFightWin).To<ChapterFightWinCommand>();

        mediationBinder.Bind<FightView>().To<FigthViewMediator>();

        commandBinder.Bind(ContextEvent.START).To<StartCommand>();
    }
}
