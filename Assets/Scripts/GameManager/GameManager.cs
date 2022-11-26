using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private StateMachine<GameManager> _gameStateMachine;
    public TapToPlayState _tapToPlayState { get; private set; }
    public PlayState _playState { get; set; }
    public Action OnGameOver;
    public Action OnGameStart;

    private void Awake()
    {
        Instance = this;
        _gameStateMachine = new StateMachine<GameManager>();
        _tapToPlayState = new TapToPlayState(_gameStateMachine);
        _playState = new PlayState(_gameStateMachine);
        _gameStateMachine.InitializeStateMachine(_tapToPlayState, this);
    }

    private void Update()
    {
        _gameStateMachine.CurrentState.OnUpdate();
    }
}
