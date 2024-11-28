using UnityEngine;

public class TournamentManager : MonoBehaviour
{
    private int _currentGame = 0;
    private int[] nextRound = new int[Mathf.CeilToInt(GameManager.instance.players.Length * 0.5f)];
    private int champion;
    
    public void OnGameEnd(int winnerIndex)
    {
        // The winner of the game will be put for the next round.
        nextRound[_currentGame] = winnerIndex;
        // Shifts the game to the next game.
        _currentGame++;
        // If there are no more games remaining, end the round.
        if (_currentGame == nextRound.Length)
        {
            OnRoundEnd();
        }
    }

    public void OnRoundEnd()
    {
        // If there is only one player, the champion is declared.
        if (nextRound.Length == 1)
        {
            champion = nextRound[0];
            return;
        }
        // Resets the variables to begin the current round.
        _currentGame = 0;
        nextRound = new int[Mathf.CeilToInt(nextRound.Length * 0.5f)];
    }
}