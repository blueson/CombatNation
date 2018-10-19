using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class LoadFightCharacterCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    public override void Execute()
    {
        var heroDataList = new List<Dictionary<string, System.Object>>();
        var characterTable = CharacterTableData.CreateFromJson();

        // 获取英雄数据
        for (int i = 0; i < userInfoModel.heroList.Count; i++)
        {
            var heroInfo = userInfoModel.heroList[i];
            var characterData = characterTable.GetCharacterInfoById(heroInfo.characterId);
            var heroPrefab = (GameObject)Resources.Load(characterData.heroPath);

            heroDataList.Add(new Dictionary<string, object>
            {
                {"atk",characterData.atk},
                {"hp",heroInfo.lastHp},
                {"maxHp",characterData.hp},
                {"heroInfoId",heroInfo.id},
                {"atkDis",characterData.atkDis},
                {"atkSpeed",characterData.atkSpeed},
                {"roleType1",Role.RoleType.HERO},
                {"moveSpeed",characterData.moveSpeed}
            });
        }

        var monsterDataList = new List<Dictionary<string, System.Object>>();
        var chapterTable = ChapterTableData.CreateFromJson();
        var currentChapterData = chapterTable.GetChapterInfoById(userInfoModel.fightChapterId);

        //  获取副本怪物数据
        for (int i = 0; i < currentChapterData.enemy.Length; i++)
        {
            var characterData = characterTable.GetCharacterInfoById(currentChapterData.enemy[i]);
            var heroPrefab = (GameObject)Resources.Load(characterData.heroPath);

            monsterDataList.Add(new Dictionary<string, object>
            {
                {"atk",characterData.atk},
                {"hp",characterData.hp},
                {"maxHp",characterData.hp},
                {"atkDis",characterData.atkDis},
                {"atkSpeed",characterData.atkSpeed},
                {"roleType1",Role.RoleType.ENEMY},
                {"moveSpeed",characterData.moveSpeed}
            });
        }

        dispatcher.Dispatch(MediatorEvent.LoadFightCharacter,new System.Object[]{heroDataList,monsterDataList});
    }
}
