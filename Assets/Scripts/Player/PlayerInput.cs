using UnityEngine;
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
    if (Input.GetKeyDown(KeyCode.Period))
      player.OnRunInputDown();
    if (Input.GetKeyUp(KeyCode.Period))
      player.OnRunInputUp();

    // Jump
    if (Input.GetKeyDown(KeyCode.Slash))
      player.OnJumpInputDown();
    if (Input.GetKeyUp(KeyCode.Slash))
      player.OnJumpInputUp();

    // Attack
    if (Input.GetKeyDown(KeyCode.Quote))
      player.OnAttackInputDown();
    if (Input.GetKeyUp(KeyCode.Quote))
      player.OnAttackInputUp();
  }
}
