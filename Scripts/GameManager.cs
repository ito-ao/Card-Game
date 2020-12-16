using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 手札にカード生成
    [SerializeField] Transform playerHandTransform,
                               playerFieldTransform,
                               enemyHandTransform,
                               enemyFieldTransform;
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
        //場にカードを出す
        //手札のカードリストを取得
        CardController[] handCardList = enemyHandTransform.GetComponentsInChildren<CardController>();
        //場に出すカードの選択
        CardController enemyCard = handCardList[0];
        //カードの移動
        enemyCard.movement.SetCardTransform(enemyFieldTransform);
        //攻撃
        //フィールドのカードリストを取得
        CardController[] fieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();
        //アタッカーを選択
        CardController attacker = fieldCardList[0];
        //ブロッカーを選択
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();
        CardController defender = playerFieldCardList[0];
        //戦闘
        CardsBattle(attacker,defender);

        //ダメージ計算

        ChangeTurn();
    }

    void CardsBattle(CardController attacker, CardController defender)
    {
        Debug.Log("CardsBattle");
        Debug.Log("Attacker hp"+attacker.model.hp);
        Debug.Log("defender hp"+defender.model.hp);
        attacker.model.Attack(defender);
        defender.model.Attack(attacker);
        Debug.Log("Attacker hp"+attacker.model.hp);
        Debug.Log("defender hp"+defender.model.hp);
        attacker.CheckAlive();
        defender.CheckAlive();
    }


    void CreateCard(Transform hand)
    {
        CardController card = Instantiate(cardPrefad,hand,false);
        card.Init(2);
    }

}
