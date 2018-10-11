using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour {

    public GameObject hpBar;
    private GameObject roleGo;
    private bool isFightOver = false;
    private ChapterData currentChapterData;

	// Use this for initialization
	void Start () {
        roleGo = GameObject.Find("Role");

        var userInfo = DataManager.GetInstance().GetUserInfo();
        var characterTable = CharacterTableData.CreateFromJson();

        // 加载英雄数据
        for (int i = 0; i < userInfo.heroList.Count;i++){
            var heroInfo = userInfo.heroList[i];
            var characterData = characterTable.GetCharacterInfoById(heroInfo.characterId);
            var heroPrefab = (GameObject)Resources.Load(characterData.heroPath);

            GameObject go = Instantiate(heroPrefab,new Vector3(-12,-i,0),Quaternion.identity,roleGo.transform);

            Role role = go.GetComponent<Role>();
            role.Atk = characterData.atk;
            role.Hp = heroInfo.lastHp; // 英雄剩下的血量
            role.MaxHp = characterData.hp;
            role.HeroInfoId = heroInfo.id; // 战斗模型跟英雄数据的关系
            role.AtkDis = characterData.atkDis;
            role.AtkSpeed = characterData.atkSpeed;
            role.RoleType1 = Role.RoleType.HERO;
            role.MoveSpeed = characterData.moveSpeed;

            Instantiate(hpBar, go.transform); // 创建血条
        }

        var chapterTable = ChapterTableData.CreateFromJson();
        currentChapterData = chapterTable.GetChapterInfoById(userInfo.fightChapterId);

        //  加载副本怪物数据
        for (int i = 0; i < currentChapterData.enemy.Length; i++)
        {
            var characterData = characterTable.GetCharacterInfoById(currentChapterData.enemy[i]);
            var heroPrefab = (GameObject)Resources.Load(characterData.heroPath);

            GameObject go = Instantiate(heroPrefab, new Vector3(12,-i, 0), Quaternion.identity, roleGo.transform);
            Role role = go.GetComponent<Role>();
            role.Atk = characterData.atk;
            role.Hp = characterData.hp;
            role.MaxHp = characterData.hp;
            role.AtkDis = characterData.atkDis;
            role.AtkSpeed = characterData.atkSpeed;
            role.RoleType1 = Role.RoleType.ENEMY;
            role.MoveSpeed = characterData.moveSpeed;

            Instantiate(hpBar, go.transform); // 创建血条
        }
	}

    private void Update()
    {
        var roleArray = roleGo.GetComponentsInChildren<Role>();

        bool enemyAllDie = true;
        bool heroAllDie = true;

        foreach(var role in roleArray)
        {
            if(role.RoleType1 == Role.RoleType.ENEMY && role.Hp > 0){
                enemyAllDie = false;
            }

            if (role.RoleType1 == Role.RoleType.HERO && role.Hp > 0)
            {
                heroAllDie = false;
            }
        }

        if(enemyAllDie){
            // 胜利
            isFightOver = true;
            FightWin();
            return;
        }

        if(heroAllDie){
            // 失败
            isFightOver = true;
            FightLose();
            return;
        }
    }

    void FightWin(){
        var userInfo = DataManager.GetInstance().GetUserInfo();
        userInfo.chapterId++; // 胜利后进入下一关
        userInfo.money += currentChapterData.money;
        FightOver();
    }

    void FightLose(){
        FightOver();
    }

    void FightOver()
    {
        var roleArray = roleGo.GetComponentsInChildren<Role>();

        var heroList = new List<Role>();
        foreach (var role in roleArray)
        {
            if (role.RoleType1 == Role.RoleType.HERO)
            {
                heroList.Add(role);
            }
        }

        var userInfo = DataManager.GetInstance().GetUserInfo();
        var delHeroIdList = new List<HeroInfo>();
        for (var i = 0; i < userInfo.heroList.Count; i++)
        {
            bool isHaveHero = false;
            foreach (var hero in heroList)
            {
                if (hero.HeroInfoId == userInfo.heroList[i].id)
                {
                    isHaveHero = true;

                    userInfo.heroList[i].lastHp = hero.Hp;
                }
            }

            if (!isHaveHero)
            {
                delHeroIdList.Add(userInfo.heroList[i]);
            }
        }

        foreach (var del in delHeroIdList){
            userInfo.heroList.Remove(del);
        }

        DataManager.GetInstance().SaveUserInfo();


        SceneManager.LoadScene("MainScene");
    }

    private void ShowAd(){
        if (!UnityAdsHelper.isSupported)
            return;
        if (!UnityAdsHelper.isInitialized)
            return;
        if (UnityAdsHelper.isShowing)
            return;
        UnityAdsHelper.ShowAd(null, ShowAdFinish);
    }

    private void ShowAdFinish(){
        Debug.Log("观看结束");
    }
}
