using System.Collections;
using UnityEngine;

public class SquareControll : MonoBehaviour
{
    public static SquareControll instance;

    [SerializeField]
    ClickControll click;

    [SerializeField]
    UIControll2 ui;

    int maxCounter = 3, counter = 0;
    bool[] controls;
    int[] squares;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        squares = new int[16];
        controls = new bool[4];
    }

    internal void LoadSquare(int value, int inner, int outter)
    {
        squares[4 * outter + inner] = value;
        int control = 0;
        for (int i = 0; i < 4; i++)
            if (squares[4 * outter + i] == value)
                control++;
        if(control == 4)
        {
            if (!controls[outter])
            {
                counter++;
                if (counter >= maxCounter)
                    LevelPassed();
                else
                    Congratulation();
            }
        }
    }

    internal void UnLoadSquare(int inner, int outter)
    {
        if (controls[outter])
        {
            counter--;
            controls[outter] = false;
        }
        squares[4 * outter + inner] = 0;
    }

    private void Congratulation()
    {
        StartCoroutine(CongratulationAsync());
    }

    IEnumerator CongratulationAsync()
    {
        ui.SetActiveWinText(true);
        ui.SetValueWinText("Awesome");
        yield return new WaitForSeconds(0.5f);
        ui.SetActiveWinText(false);
    }

    private void LevelPassed()
    {
        click.enabled = false;
        ui.SetActiveWinText(true);
        ui.SetValueWinText("Level Passed");
    }
}
