using System;
using UnityEngine;
using UnityEngine.UI;

class ClientHandleData : MonoBehaviour
{
    public static ClientHandleData instance;

    [Header("Player Menu")]
    public Text _playerWelcome;

    [Header("Match")]
    public Text _opponent;
    public Text _rage;
    public Image _ragebar;
    private void Awake()
    {
        instance = this;
    }

    void HandleMessages(int packetNum, byte[] data)
    {
        switch (packetNum)
        {
            case 1:
                HandleIngame(packetNum, data);
                break;
            case 2:
                break;
            case 3:
                HandleMatchMaking(packetNum, data);
                break;
            case 4:
                HandleRageBar(packetNum, data);
                break;

        }
    }

    public void HandleData(byte[] data)
    {
        int packetnum;
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        packetnum = buffer.ReadInteger();
        buffer = null;
        if (packetnum == 0)
            return;

        HandleMessages(packetnum, data);
    }

    void HandleIngame(int packetNum, byte[] data)
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);

        int packetnum = buffer.ReadInteger();
        Player.instance.Username = buffer.ReadString();
        Player.instance.Password = buffer.ReadString();
        Player.instance.Level = buffer.ReadInteger();
        Player.instance.Access = buffer.ReadByte();
        Player.instance.FirstTime = buffer.ReadByte();
        buffer = null;

        _playerWelcome.text = "Welcome back, " + Player.instance.Username;
        MenuManager.instance._menu = MenuManager.Menu.Ingame;
    }

    void HandleMatchMaking(int packetNum, byte[]data)
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        int packet = buffer.ReadInteger();
        string player1 = buffer.ReadString();
        string player2 = buffer.ReadString();

        if(player1 == Player.instance.Username)
        {
            _opponent.text = player2;
        }
        else
        {
            _opponent.text = player1;
        }

        MenuManager.instance._menu = MenuManager.Menu.InMatch;
    }

    void HandleRageBar(int packetNum, byte[]data)
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        int packet = buffer.ReadInteger();
        int ragebar = buffer.ReadInteger();

        _rage.text = ragebar.ToString();
        _ragebar.fillAmount = (float)(decimal)ragebar / 10;
    }
}
