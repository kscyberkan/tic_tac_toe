using TMPro;
using UnityEngine;

namespace TicTacToe
{
  public class UIDialog : MonoBehaviour
  {
    [SerializeField] private TMP_Text _messageText;

    internal static void Show(string message)
    {
      GameObject obj = Resources.Load<GameObject>("Utils/UIDialog");
      UIDialog dialog = Instantiate(obj).GetComponent<UIDialog>();

      dialog.SetMessage(message);
    }

    internal void SetMessage(string message)
    {
      _messageText.text = message;
    }

    public void OnClickClose()
    {
      Destroy(gameObject);
    }
  }
}
