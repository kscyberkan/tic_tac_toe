using UnityEngine;

namespace TicTacToe
{
  public class GController : MonoBehaviour
  {
    public static GController Instance { get; private set; }

    protected void Awake()
    {
      if (Instance != null && Instance != this)
      {
        Destroy(gameObject);
      }
      else
      {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Scene.LoadSceneBoard();
      }
    }
  }
}
