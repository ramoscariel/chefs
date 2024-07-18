using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    private PlayerInputManager playerInputManager;
    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }
    private void Start()
    {
        SpawnPlayers();
        
    }

    private void SpawnPlayers()
    {
        if (!playerInputManager || spawnPoints == null) { return; }
        foreach (Transform point in spawnPoints)
        {
            PlayerInput playerInput = playerInputManager.JoinPlayer();
            playerInput.transform.position = point.position;
        }
    }
}