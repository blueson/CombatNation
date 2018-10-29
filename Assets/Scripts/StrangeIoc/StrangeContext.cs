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
        //commandBinder.Bind(FubenFightEvent.loadFightCharacter).To<LoadFightCharacterCommand>();
        commandBinder.Bind(CommandEvent.ChapterFight).To<ChapterFightCommand>();
        commandBinder.Bind(CommandEvent.GetChapterInfo).To<GetChapterInfoCommand>();
        commandBinder.Bind(CommandEvent.GetMoney).To<GetMoneyCommand>();
        commandBinder.Bind(CommandEvent.GetRecruitMoney).To<GetRecruitMoneyCommand>();
        commandBinder.Bind(CommandEvent.RecruitHero).To<RecruitHeroCommand>();
        commandBinder.Bind(CommandEvent.AddMoney).To<AddMoneyCommand>();
        commandBinder.Bind(CommandEvent.GetRecruitInfo).To<GetRecruitInfoCommand>();

        //mediator
        mediationBinder.Bind<MainPanel>().To<MainPanelMediator>();

        mediationBinder.Bind<MoneyTextView>().To<MoneyTextViewMediator>();
        mediationBinder.Bind<ChapterView>().To<ChapterViewMediator>();
        mediationBinder.Bind<RecruitItemView>().To<RecruitItemMediator>();
        mediationBinder.Bind<AddMoneyButtonView>().To<AddMoneyButtonMediator>();
        mediationBinder.Bind<RecruitScrollView>().To<RecruitScrollMediator>();

        commandBinder.Bind(ContextEvent.START).To<StartCommand>();
    }
}
