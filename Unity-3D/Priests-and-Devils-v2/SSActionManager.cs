using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是动作管理的基类，其他所有动作管理器都是其子类
public class SSActionManager : MonoBehaviour {
    //保存已经注册的动作
    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();  
    //等待将要注册的动作的队列 
    private List<SSAction> waitingAdd = new List<SSAction>();      //等待将要删除的动作的队列            
    private List<int> waitingDelete = new List<int>();             
    protected void Start()
    {

    }
    protected void Update()
    {
        //注册所有待注册的动作
        foreach (SSAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        //管理所有动作
        foreach (KeyValuePair<int, SSAction> kv in actions)
        {
            SSAction ac = kv.Value;
            if (ac.destroy)
            {
                waitingDelete.Add(ac.GetInstanceID());
            }
            else if (ac.enable)
            {
                ac.Update();
            }
        }

        //删除待删除的所有动作
        foreach (int key in waitingDelete)
        {
            SSAction ac = actions[key];
            actions.Remove(key);
            DestroyObject(ac);
        }
    }

    //初始化一个动作
    public void RunAction(GameObject gameobject, SSAction action, ISSActionCallback manager)
    {
        action.gameobject = gameobject;
        action.transform = gameobject.transform;
        action.callback = manager;
        waitingAdd.Add(action);
        action.Start();
    }
}