using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private List<GameObject> scrollbars;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        SetUpGame();
    }

    private void SetUpGame()
    {
        foreach (GameObject item in scrollbars)
        {
            item.active = false;
        }
        characterController.enabled = true;
       // _playerMovement = new PlayerMovement(player.PlayerSpeed, player.PlayerRb, player.PlayerJumpForce);
       // inputListener.Construct(player, _playerMovement, characterController, cameraTransform);

    }
}
