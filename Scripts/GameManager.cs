using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 手札にカード生成
    [SerializeField] Transform playerHandTransform,
    enemyHandTransform;
    [SerializeField] CardController cardPrefad;

    bool isPlayerTurn;

    void Start()
    {
    StartGame();
    }

    void StartGame(){
        SettingInitHand();
        isPlayerTurn = true;
        TurnCalc();
    }

    void SettingInitHand(){
        for (int i = 0; i<3; i++)
        {
            CreateCard(playerHandTransform);
            CreateCard(enemyHandTransform);

        }
    }

    void TurnCalc()
    {
        if(isPlayerTurn)
        {
         PlayerTurn();
        }else
        {
            EnemyTurn();
        }
    }

    public void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;
        if(isPlayerTurn)
        {
            CreateCard(playerHandTransform);
        }else
        {
            CreateCard(enemyHandTransform);
        }
        TurnCalc();
    }

    void PlayerTurn()
    {
        Debug.Log("playerのターン");
    }

    void EnemyTurn()
    {
        Debug.Log("enemyのターン");
        ChangeTurn();
    }


    void CreateCard(Transform hand)
    {
        CardController card = Instantiate(cardPrefad,hand,false);
        card.Init(2);
    }

}
