using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public interface IUserInfoService {
    IEventDispatcher dispatcher { get; set; }

    void GetUserInfo(string savePath);
    void SaveUserInfo(string savePath, string userInfo);
}
