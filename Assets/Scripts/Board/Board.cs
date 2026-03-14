using System;
using Unity.Multiplayer.PlayMode;
using UnityEngine;

namespace TicTacToe.Board
{
  public class Board : MonoBehaviour
  {
    [SerializeField] private Slot[] _slots;
    private Slot[,] _slotsXY;

    public bool IsGameOver { get; private set; }

    public static Board Instance { get; private set; }

    public SlotState CurrentPlayer { get; private set; } = SlotState.X;

    protected void Awake()
    {
      if (Instance != null && Instance != this)
      {
        Destroy(gameObject);
      }
      else
      {
        Instance = this;
        InitailizeBoard();
      }
    }

    internal void OnPlace()
    {
      // Check row
      for (int y = 0; y < 3; y++)
      {
        if (_slotsXY[0, y].State == CurrentPlayer &&
            _slotsXY[1, y].State == CurrentPlayer &&
            _slotsXY[2, y].State == CurrentPlayer)
        {
          EndGame(CurrentPlayer);
          return;
        }
      }

      // Check column
      for (int x = 0; x < 3; x++)
      {
        if (_slotsXY[x, 0].State == CurrentPlayer &&
            _slotsXY[x, 1].State == CurrentPlayer &&
            _slotsXY[x, 2].State == CurrentPlayer)
        {
          EndGame(CurrentPlayer);
          return;
        }
      }

      // Check diagonals
      if (_slotsXY[0, 0].State == CurrentPlayer &&
          _slotsXY[1, 1].State == CurrentPlayer &&
          _slotsXY[2, 2].State == CurrentPlayer)
      {
        EndGame(CurrentPlayer);
        return;
      }

      if (_slotsXY[0, 2].State == CurrentPlayer &&
          _slotsXY[1, 1].State == CurrentPlayer &&
          _slotsXY[2, 0].State == CurrentPlayer)
      {
        EndGame(CurrentPlayer);
        return;
      }

      // Check for draw
      if (Instance.IsBoardFull())
      {
        EndGame(null);
        return;
      }

      ChangeTurn();
    }

    private void EndGame(SlotState? winPlayer)
    {
      UIDialog.Show(winPlayer.HasValue ? $"{winPlayer} wins!" : "It's a draw!");
      IsGameOver = true;
    }

    private void ChangeTurn()
    {
      if (CurrentPlayer == SlotState.X)
      {
        CurrentPlayer = SlotState.O;
      }
      else
      {
        CurrentPlayer = SlotState.X;
      }
    }

    private bool IsBoardFull()
    {
      for (int x = 0; x < 3; x++)
      {
        for (int y = 0; y < 3; y++)
        {
          if (_slotsXY[x, y].State == SlotState.Empty)
          {
            return false;
          }
        }
      }
      return true;
    }

    public void InitailizeBoard()
    {
      _slotsXY = new Slot[3, 3];
      for (int i = 0; i < _slots.Length; i++)
      {
        int x = i % 3;
        int y = i / 3;
        _slotsXY[x, y] = _slots[i];
        _slots[i].ClearState();
        _slots[i].Initialize(x, y);
      }

      CurrentPlayer = SlotState.X;
      IsGameOver = false;
    }
  }
}