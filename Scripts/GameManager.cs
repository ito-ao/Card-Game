using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 手札にカード生成
    [SerializeField] Transform playerHandTransform;
    [SerializeField] CardController cardPrefad;

    bool isPlayerTurn;

    void Start()
    {
        StratGame();
        CreateCard(playerHandTransform);
    }

    void StartGame(){
        SettingInitHand();
        isPlayerTurn = true;
        TurnCalc();
    }

    void CreateCard(Transform hand)
    {
        CardController card = Instantiate(cardPrefad,playerHandTransform,false);
        card.Init(1);
    }

}
