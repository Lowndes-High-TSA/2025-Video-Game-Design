using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField]
    public Player[] players;
    private List<Player> _activePlayers = new List<Player>();
    private List<int> _infectedPlayers = new List<int>();
    
    // Describes the current game state.
    private readonly GameMode _currentGameMode = GameMode.Classic;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        int initialTaggedPlayer = Random.Range(0, players.Length);
        players[initialTaggedPlayer].Infect();
        _infectedPlayers.Add(initialTaggedPlayer);
        
        switch (_currentGameMode)
        {
            case GameMode.Classic:
                _activePlayers = players.ToList();
                break;
            case GameMode.Tournament:
                _activePlayers.Add(players[0]);
                _activePlayers.Add(players[^1]);
                break;
            case GameMode.Infection:
                _activePlayers = players.ToList();
                break;
        }
    }

    public void OnInfection()
    {
        // Temporary -- Remove(0)=Previous player infected, Add(1)=New player infected
        _infectedPlayers.Add(1);
        if (_currentGameMode == GameMode.Infection)
        {
            if (_infectedPlayers.Count != _activePlayers.Count - 1)
            {
                return;
            }
            OnEnd();
        }
        else
        {
            _infectedPlayers.Remove(0);
        }
    }

    public void OnEnd()
    {
        foreach (int playerIndex in _infectedPlayers)
        {
            _activePlayers.RemoveAt(playerIndex);
        }
        
        switch (_currentGameMode)
        {
            case GameMode.Classic:
                break;
            case GameMode.Tournament:
                break;
            case GameMode.Infection:
                break;
        }
    }
    
    // Update is called once per frame
    private void Update()
    {
        
    }

    private enum GameMode
    {
        Classic,
        Tournament,
        Infection
    }
}
