using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class RecruitScrollView : View {

    public GameObject recruitItemGo;
    public RectTransform contentTransform;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    List<RecruitItemView> recruitItemViewList = new List<RecruitItemView>();

    public void UpdateRecruitView(List<Dictionary<string,System.Object>> summonInfoList){
        
        foreach (var summonInfo in summonInfoList)
        {
            var go = Instantiate(recruitItemGo);
            go.transform.SetParent(contentTransform);
            var recruitItemView = go.GetComponent<RecruitItemView>();
            recruitItemViewList.Add(recruitItemView);
        }

        var width = recruitItemViewList[recruitItemViewList.Count - 1].transform.position.x + 100;
        contentTransform.rect.Set(contentTransform.rect.x,contentTransform.rect.y,width,contentTransform.rect.height);
    }
}
