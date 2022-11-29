using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private StateMachine<GameManager> _gameStateMachine;
    public TapToPlayState _tapToPlayState { get; private set; }
    public PlayState _playState { get; private set; }
    public WinState _winState { get; private set; }
    public LoseState _loseState { get; private set; }
    public Action OnWin;
    public Action OnGameOver;
    public Action OnGameStart;

    private void Awake()
    {
        Instance = this;
        _gameStateMachine = new StateMachine<GameManager>();
        _tapToPlayState = new TapToPlayState(_gameStateMachine);
        _playState = new PlayState(_gameStateMachine);
        _winState = new WinState(_gameStateMachine);
        _loseState = new LoseState(_gameStateMachine);
        _gameStateMachine.InitializeStateMachine(_tapToPlayState, this);
        OnGameOver += Lose;
    }

    private void Update()
    {
        _gameStateMachine.CurrentState.OnUpdate();
    }

    public void Win()
    {
        _playState.SetIsWin(true);
    }
    public void Lose()
    {
        _gameStateMachine.ChangeState(_loseState);
    }
}
