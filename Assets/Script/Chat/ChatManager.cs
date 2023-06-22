using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour, IChatClientListener
{
    [SerializeField] private string _userId;
    [SerializeField] private Text _chatText;
    [SerializeField] private InputField _textMessage;
    [SerializeField] private InputField _username;

    private ChatClient _chatClient;

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log($"{level}, {message}");
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log(state);
    }

    public void OnConnected()
    {
        _chatText.text += "\n Вы подключились к чату";
        _chatClient.Subscribe("globalChat");
    }

    public void OnDisconnected()
    {
        _chatClient.Unsubscribe(new string[] { "globalChat" });
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++)
        {
            _chatText.text += $"\n[{channelName}] {senders[i]}: {messages[i]}";
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        for (int i = 0; i < channels.Length; i++)
        {
            _chatText.text += $"Вы подключились к {channels[i]}";
        }
    }

    public void OnUnsubscribed(string[] channels)
    {
        for (int i = 0; i < channels.Length; i++)
        {
            _chatText.text += $"Вы отключились от {channels[i]}";
        }
    }

    public void OnUserSubscribed(string channel, string user)
    {
        _chatText.text += $"Пользователь {user} подключился к {channel}";
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        _chatText.text += $"Пользователь {user} отключился от {channel}";
    }

    private void Start()
    {
        _chatClient = new ChatClient(this);
        _chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(_userId));
    }

    private void Update()
    {
        _chatClient.Service();
    }

    public void SendButton()
    {
        if(_username.text == "")
        {
            _chatClient.PublishMessage("globalChat", _textMessage.text);
        }
    }
}
