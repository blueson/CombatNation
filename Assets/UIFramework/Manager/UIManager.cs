using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {
    private static UIManager _instance;
    private Transform canvas;

    public static UIManager Instance(){
        if (_instance == null){
            _instance = new UIManager();
        }
        return _instance;
    }

    public Dictionary<UIPanelType, string> pathDic;

    public Dictionary<UIPanelType, BasePanel> panelDic;
    public Stack<BasePanel> panelStack;

    public void PushPanel(UIPanelType type){
        if (panelStack == null){
            panelStack = new Stack<BasePanel>();
        }

        if (panelStack.Count > 0){
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        BasePanel panel = GetPanel(type);
        panel.OnEnter();
        panelStack.Push(panel);
    }

    public void PopPanel(){
        if (panelStack == null) panelStack = new Stack<BasePanel>();

        if (panelStack.Count <= 0) return;
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        if (panelStack.Count <= 0) return;
        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResuMe();
    }

    private UIManager(){
        pathDic = new Dictionary<UIPanelType, string>();
        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        ParseUIPanelInfo();
    }

    class UIPanelInfoList{
        public List<UIPanelInfo> panelInfoList = new List<UIPanelInfo>();
    }

    private void ParseUIPanelInfo(){
        TextAsset ta = Resources.Load("UIPanelType") as TextAsset;
        UIPanelInfoList infoList = JsonUtility.FromJson<UIPanelInfoList>(ta.text);

        foreach(UIPanelInfo info in infoList.panelInfoList){
            pathDic.Add(info.panelType,info.path);
        }
    }

    private BasePanel GetPanel(UIPanelType type){
        if (panelDic == null){
            panelDic = new Dictionary<UIPanelType, BasePanel>();
        }

        BasePanel panel = panelDic.TryGet(type);

        if (panel == null){
            string path = pathDic.TryGet(type);
            GameObject go = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            if(canvas == null){
                canvas = GameObject.Find("Canvas").GetComponent<Transform>();
            }
            go.transform.SetParent(canvas, false);

            if(panelDic.ContainsKey(type)){
                panelDic[type] = go.GetComponent<BasePanel>();
            }else{
                panelDic.Add(type, go.GetComponent<BasePanel>());
            }
            panel = go.GetComponent<BasePanel>();
        }

        return panel;
    }
}
