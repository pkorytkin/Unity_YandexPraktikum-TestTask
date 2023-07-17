using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreUI : MonoBehaviour
{
    public Text Score;
    public PlayerController playerController;
    // Update is called once per frame
    void Update()
    {
        if (MenuController.Instance.IsGameInProgress)
        {
            Score.text = playerController.CurrentFoodCount.ToString();
        }
     }
}
