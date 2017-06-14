﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EventManagement;

/// <summary>
/// Listen for and respond to events for the player turn manager
/// generate events from the player turn manager
/// </summary>
[RequireComponent(typeof(PlayerTurnManager))]
public class PlayerTurnManagerEventManger : MonoBehaviour {
    
    PlayerTurnManager turnManager;

    private void Start() {
        if(turnManager == null)
            turnManager = GetComponent<PlayerTurnManager>();
        subscribeToEvents();
    }

    void subscribeToEvents() {
        EventManager.Instance.registerCallbackForEvent("endPlayerTurn", onPlayerEndTurn);
    }

    public void onPlayerEndTurn(EventArgs e) {

        EndTurnArgs args = (EndTurnArgs) e;
        int idNextPlayer = turnManager.startNextPlayerTurn();

        EventManager.Instance.triggerEvent("startPlayerTurn/" + idNextPlayer, new EventArgs());
    }
}
