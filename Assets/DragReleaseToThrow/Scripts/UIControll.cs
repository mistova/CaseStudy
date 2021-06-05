using UnityEngine;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{
    public static UIControll instance;

    [SerializeField]
    Text winText;

    [SerializeField]
    Slider forceSlider;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SetActiveWinText(bool state)
    {
        winText.gameObject.SetActive(state);
    }

    public void SetActiveForceSlider(bool state)
    {
        forceSlider.gameObject.SetActive(state);
    }

    public void SetValueForceSlider(float value)
    {
        forceSlider.value = value;
    }
}
