using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//此类是动作管理器与动作通信的接口
public enum SSActionEventType:int { Started, Competeted }

public interface ISSActionCallback {
    void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Competeted,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null);

}