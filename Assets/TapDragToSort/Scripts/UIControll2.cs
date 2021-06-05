using UnityEngine;
using UnityEngine.UI;

public class UIControll2 : MonoBehaviour
{
    [SerializeField]
    Text winText;

    public void SetActiveWinText(bool state)
    {
        winText.gameObject.SetActive(state);
    }

    public void SetValueWinText(string value)
    {
        winText.text = value;
    }
}
