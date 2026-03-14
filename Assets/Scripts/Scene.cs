using UnityEngine;
using UnityEngine.SceneManagement;

namespace TicTacToe
{
  public static class Scene
  {
    public static void LoadSceneBoard()
    {
      SceneManager.LoadScene("Board");
    }
  }
}