using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Chatting : NetworkBehaviour
{
	//MainObject
    public GameObject mainObj;
	//Canvas
    private Transform content;
    private InputField inputBox;
    private Button sendButton;
	//private string[] names={"a","b"};
	private string[] names={"回憶揮之不去","妳别犯贱","折现浪漫づ","forever love","待我步履蹒跚.","笑看往事如花","任时光匆匆离去我只稀罕你","青衫憶笙〞","爱你至深","弧度\u3000Trajectory゜","忆苦思甜@","灬我们的感情灬","恍如隔世梦里见","の岁月茹梭╰つ","你的微笑温暖我的世界-","戒不掉的放纵","知遇我","畅所欲言≈","夜、如此安静","国际婚礼","努力爲妳改變∫","我愛上了黑夜。","no matter","躲避那颗心","话我知ii","7S毁人心","我很好心脏还能跳还能笑","╰ゝ 淡不掉","岁月无声","゛乱世浮沉、情缘宿命","马上有钱","半夜鬼来电","2022.更加爱你","卑贱的太过分","空城，旧坟待新人.","錢ォ是王道$","♀回忆的美好ＬХＥ","情场得意 考场失意","封心锁国I 画地为牢I","我愿溺海","─━═唯爱的年华ζ","从校服到婚纱°","﹏颜如玉°","难以抗拒你的容颜","_爱的沦陷_","是柠檬就不该羡慕西瓜的甜","曾經真可笑","神马都能张价。","习惯了、就好╮","世间唯一。","表情帝@","￡爱已★发芽彡","一起追过的exo","上秒恋人下秒陌生人","男生没有大姨父°","十指紧扣","时光￠很短暂","该用户已成仙","拆不穿的谎言、","像雾像雨又像风","怪人心医","谈感情、伤神","╘等迩宛在水中央","解冻的回忆","小冷漠‰"};

	//Random ran=new Random();
	int RandKey=Random.Range(1,60);

    [SyncVar]
	//在线聊天人数
    private int onlineNum = 0;
    void Start()
    {
		//获取聊天主面板transform属性
        content = GameObject.Find("Canvas/Scroll View/Viewport/Content").transform;
		//获取输入框
        inputBox = GameObject.Find("Canvas/InputField").GetComponent<InputField>();
		//获取发送按钮
        sendButton = GameObject.Find("Canvas/Button").GetComponent<Button>();
		//添加按钮点击事件
        sendButton.onClick.AddListener(sendMessage);
    }

	// 更新在线人数
	private void Update()
	{
		if (isServer)
			onlineNum = NetworkManager.singleton.numPlayers;
	}

    // UI显示在线人数
    private void OnGUI()
    {
        if (!isLocalPlayer)
            return;
        GUI.Label(new Rect(new Vector2(10, 10), new Vector2(150, 50)),
            string.Format("在线人数:{0}", onlineNum));
    }

	// Command函数修饰：客户端调用，服务端执行
	[Command]
	void CmdSend(string str)
	{
		RpcShowMessage(str);
	}

	// ClientRpc函数修饰：服务端调用，客户端执行
	[ClientRpc]
	void RpcShowMessage(string str)
	{
		GameObject item = Instantiate(mainObj, content);
		item.GetComponentInChildren<Text>().text = str;
	}
		
    // 按钮事件：发送消息
    void sendMessage()
    {
        if (!isLocalPlayer)
            return;
        if (inputBox.text.Length > 0)
        {
			//消息内容
            //string str = string.Format("{0}:{1}{2}", Network.player.ipAddress, System.Environment.NewLine, inputBox.text);
			string str = string.Format("{0}:{1}{2}", names[RandKey], System.Environment.NewLine, inputBox.text);
            //调用CmdSend函数
			CmdSend(str);
			//清空输入框
            inputBox.text = string.Empty;
        }
    }

    


}

