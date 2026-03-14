using System;
using TMPro;
using UnityEngine;

namespace TicTacToe.Board
{
  public class Position
  {
    public int X { get; }
    public int Y { get; }
    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }
  }

  public class Slot : MonoBehaviour
  {
    [SerializeField] private TMP_Text _text;
    public SlotState State { get; private set; } = SlotState.Empty;
    public Position Position { get; private set; }

    public void Initialize(int x, int y)
    {
      Position = new Position(x, y);
    }

    public void SetState()
    {
      if (State != SlotState.Empty || Board.Instance.IsGameOver)
      {
        return;
      }

      State = Board.Instance.CurrentPlayer;
      ShowState();

      Board.Instance.OnPlace();
    }

    internal void ClearState()
    {
      State = SlotState.Empty;
      ShowState();
    }

    private void ShowState()
    {
      _text.text = State == SlotState.Empty ? "" : State.ToString();
    }
  }
}
