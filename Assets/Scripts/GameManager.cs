using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject currentPlayer;
    private Transform spawnPoint;
    private CinemachineVirtualCamera virtualCamera;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is Null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        //if (_instance != null && _instance != this)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        _instance = this;

        //DontDestroyOnLoad(gameObject);

        Physics2D.gravity = new Vector2(0, -60f);

        virtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();

        spawnPoint = GameObject.Find("SpawnPoint").transform;
        currentPlayer = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        virtualCamera.Follow = currentPlayer.transform;
    }

    public void RespawnPlayer()
    {
        Destroy(currentPlayer);

        var newPlayer = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        virtualCamera.Follow = newPlayer.transform;
        currentPlayer = newPlayer;
    }
}
