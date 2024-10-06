using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform cameraTransform;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        SetUpGame();
    }

    private void SetUpGame()
    {
        _playerMovement = new PlayerMovement(player.PlayerSpeed, player.PlayerRb, player.PlayerJumpForce);
        inputListener.Construct(player, _playerMovement, characterController, cameraTransform);

    }
}
