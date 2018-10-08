using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public string timeURL = "http://www.time.ac.cn/timeflash.asp?user=flash";//授时中心地址
    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetTime());
    }

    IEnumerator GetTime()
    {
        Debug.Log("Start get web time");
        WWW www = new WWW(timeURL);
        while (!www.isDone)
        {
            Debug.Log("Getting web time");
            yield return www;
            Debug.Log("Finish getting web time and whole xml is :   " + www.text);
            ParseXml(www);
        }
    }

    public void ParseXml(WWW www)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(www.text);
        XmlElement root = xmlDoc.DocumentElement;
        XmlNodeList nodeList = root.SelectNodes("/ntsc/time");
        foreach (XmlElement xe in nodeList)
        {
            foreach (XmlElement x1 in xe.ChildNodes)
            {
                if (x1.Name == "year")
                    Debug.Log("Current year:      " + x1.InnerText);
                if (x1.Name == "month")
                    Debug.Log("Current month:      " + x1.InnerText);
                if (x1.Name == "day")
                    Debug.Log("Current day:      " + x1.InnerText);
                if (x1.Name == "hour")
                    Debug.Log("Current hour:      " + x1.InnerText);
                if (x1.Name == "minite")
                    Debug.Log("Current minite:      " + x1.InnerText);
                if (x1.Name == "second")
                    Debug.Log("Current second:      " + x1.InnerText);
            }
        }
    }
}
