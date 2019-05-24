using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    //General
    public string Username;
    public string Password;
    public int Level;
    public byte Access;
    public byte FirstTime;
}
