using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public Dialog DialogPanel;

    public TextMeshProUGUI pointsText;

    private int points;

    ///-///////////////////////////////////////////////////////////
    ///
    public void AddPoints()
    {
        points++;

        DisplayPoints();

    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void DisplayPoints()
    {
        pointsText.text = points.ToString();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void DisplayDialog(string [] lines, float textSpeed)
    {
        DialogPanel.gameObject.SetActive(true);
        DialogPanel.StartDialog(lines);
    }
}
