using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Food":
                Player.ConsumeFood();
                collision.SendMessage("Consumed");
                break;
            case "Border":
                Player.StopGame();
                break;
        }
    }
}
