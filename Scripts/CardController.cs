﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    CardView view; // 見かけ(view)に関することを操作
    public CardModel model; // データ(model)に関することを操作
    public CardMovement movement; //カードの移動(movement)に関することを操作
    private void Awake()
    {
        view = GetComponent<CardView>();
        movement = GetComponent<CardMovement>();
    }

    public void Init(int cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
    }

    public void CheckAlive(){
        if(model.isAlive){
            view.Refresh(model);
        }else{
            Destroy(this.gameObject);
        }
    }
}
