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
    [SerializeField] private HealthView healthView;
    [SerializeField] private PlayerController playerController;

    private Health _health;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        SetUpGame();
    }

    private void SetUpGame()
    {
        _health = new Health();
        _health.SetUpScore();
        healthView.Construct(_health);
        Time.timeScale = 1.0f;
        foreach (GameObject item in scrollbars)
        {
            item.active = false;
        }
        characterController.enabled = true;
        playerController.Construct(_health);

       // _playerMovement = new PlayerMovement(player.PlayerSpeed, player.PlayerRb, player.PlayerJumpForce);
       // inputListener.Construct(player, _playerMovement, characterController, cameraTransform);

    }
}
