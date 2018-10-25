using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public interface IUserInfoService {
    IEventDispatcher dispatcher { get; set; }

    void GetUserInfo();
    void SaveUserInfo(IUserInfoModel userInfoModel);
}
