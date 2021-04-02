﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        // Movement
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        // Run
        if(Input.GetMouseButtonDown(1))
            player.OnRunInputDown();
        if(Input.GetMouseButtonUp(1))
            player.OnRunInputUp();

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
            player.OnJumpInputDown();
        if (Input.GetKeyUp(KeyCode.Space))
            player.OnJumpInputUp();
        
        // Attack
        if (Input.GetMouseButtonDown(0))
            player.OnAttackInputDown();
        if (Input.GetMouseButtonUp(0))
            player.OnAttackInputUp();
    }
}
