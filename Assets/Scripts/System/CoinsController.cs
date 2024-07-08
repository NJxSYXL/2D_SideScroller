using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private uint MaxCoins;
    private uint coinsCollected;

    private static CoinsController _instance;
    public static CoinsController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Coins Controller is Null");
            }

            return _instance;
        }
    }

    public void Awake()
    {
        _instance = this;
    }

    public void AddCoins()
    {
        AudioManager.instance.PlaySFX("Collect");
        coinsCollected++;
        CheckCoins();
    }

    public uint GetCoins()
    {
        return coinsCollected;
    }

    public uint GetMaxCoins()
    {
        return MaxCoins;
    }

    private void CheckCoins()
    {
        if (coinsCollected >= MaxCoins)
        {
            var portal = GameObject.Find("Portal").GetComponent<Portal>();
            portal.ActivatePortal();
        }
    }
}
