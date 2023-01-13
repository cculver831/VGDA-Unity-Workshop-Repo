using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public Dialog DialogPanel;

    //Awake() happens sooner than Start()
    private void Awake()
    {
        instance = this;
    }


    public TextMeshProUGUI pointsText;

    private int points;



    public void AddPoints()
    {
        points++;

        DisplayPoints();

    }


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
