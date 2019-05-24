using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClientSendData : MonoBehaviour {

    public static ClientSendData instance;
    public Network network;

    [Header("Login")]
    public Text _loginUsername;
    public Text _loginPassword;

    [Header("Registration")]
    public Text _username;
    public Text _password;
    public Text _password2;

    [Header("Matchmaking")]
    public GameObject LFG;
    public GameObject inMenu;



	// Use this for initialization
	void Awake ()
    {
        instance = this;
	}
	

    public void SendDataToServer(byte[]data)
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        network.myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);
        buffer = null;
    }

    public void SendAccount()
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteInteger(1);

        if(_username.text == string.Empty)
        {
            Debug.Log("Please insert a username.");
            return;
        }

        if(_password.text == string.Empty)
        {
            Debug.Log("Please insert a password.");
            return;
        }

        if(_password2.text != _password.text)
        {
            Debug.Log("Your password do not match.");
            return;
        }

        buffer.WriteString(_username.text);
        buffer.WriteString(_password.text);

        SendDataToServer(buffer.ToArray());
        buffer = null;
    }

    public void SendLogin()
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteInteger(2);

        if (_loginUsername.text == string.Empty)
        {
            Debug.Log("Please insert a username.");
            return;
        }

        if (_loginPassword.text == string.Empty)
        {
            Debug.Log("Please insert a password.");
            return;
        }

        buffer.WriteString(_loginUsername.text);
        buffer.WriteString(_loginPassword.text);

        SendDataToServer(buffer.ToArray());
        buffer = null;
    }

    public void SendLookingForMatch()
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteInteger(3);
        SendDataToServer(buffer.ToArray());
        LFG.SetActive(true);
        inMenu.SetActive(false);

        buffer = null;
    }

    public void SendCancelMatch()
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteInteger(4);
        SendDataToServer(buffer.ToArray());
        buffer = null;
    }
	
}
