using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Action OnGameOver;

    private void Awake()
    {
        Instance = this;
    }
}
