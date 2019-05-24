﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance;

    [Header("Menu GameObjects")]
    public GameObject loadingMenu;
    public GameObject homeMenu;
    public GameObject registerMenu;
    public GameObject ingameMenu;
    public GameObject inMatch;

    public Menu _menu;
    public enum Menu
    {
        Loading = 1,
        Home,
        Register,
        Ingame,
        InMatch
    }

    // Use this for initialization
    private void Awake()
    {
        instance = this;
        _menu = Menu.Loading;
    }

    // Update is called once per frame
    void Update ()
    {
		switch(_menu)
        {
            case Menu.Loading:
                loadingMenu.SetActive(true);
                homeMenu.SetActive(false);
                registerMenu.SetActive(false);
                ingameMenu.SetActive(false);
                inMatch.SetActive(false);
                break;
            case Menu.Home:
                loadingMenu.SetActive(false);
                homeMenu.SetActive(true);
                registerMenu.SetActive(false);
                ingameMenu.SetActive(false);
                inMatch.SetActive(false);
                break;
            case Menu.Register:
                loadingMenu.SetActive(false);
                homeMenu.SetActive(false);
                registerMenu.SetActive(true);
                ingameMenu.SetActive(false);
                inMatch.SetActive(false);
                break;
            case Menu.Ingame:
                loadingMenu.SetActive(false);
                homeMenu.SetActive(false);
                registerMenu.SetActive(false);
                ingameMenu.SetActive(true);
                inMatch.SetActive(false);
                break;
            case Menu.InMatch:
                loadingMenu.SetActive(false);
                homeMenu.SetActive(false);
                registerMenu.SetActive(false);
                ingameMenu.SetActive(false);
                inMatch.SetActive(true);
                break;
        }
	}

    public void ChangeMenu(int menu)
    {
        _menu = (Menu)menu;
    }
}
