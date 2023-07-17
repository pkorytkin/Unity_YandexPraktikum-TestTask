using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject PrestartMenu;
    public GameObject PlayerObject;
    static MenuController instance;
    public static MenuController Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    public bool IsGameInProgress = false;
    private void Awake()
    {
        Instance = this;
        StopGame();
    }
    public void StopGame()
    {
        PrestartMenu.SetActive(true);
        PlayerObject.SetActive(false);
        IsGameInProgress = false;
    }
    public void StartGame()
    {
        PrestartMenu.SetActive(false);
        PlayerObject.SetActive(true);
        IsGameInProgress = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartGame();
        }
    }
}
