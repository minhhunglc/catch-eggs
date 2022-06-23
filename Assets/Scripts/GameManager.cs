using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Component

    PlayerMove playerMove;

    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    #endregion
    void Start()
    {
        playerMove = PlayerMove.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        if (playerMove.Health > numOfHearts)
        {
            playerMove.Health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerMove.Health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
