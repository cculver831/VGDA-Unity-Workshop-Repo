using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField] private Image crosshairImage;

    private float maxDetectionDistance = 100f;

    private Color defaultColor;

    private void Start()
    {
        defaultColor = crosshairImage.color;
    }

    private void FixedUpdate()
    {
        CrosshairDetectEnemy();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    private void CrosshairDetectEnemy()
    {
        // create a ray at the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDetectionDistance, LayerMask.GetMask("Default")))
        {
            //Debug.Log(hit.collider.gameObject);

            // if this raycast is hitting an enemy, turn the crosshair red
            if (hit.collider.gameObject.CompareTag("Enemy"))
                ChangeCrosshairColor(Color.red);
            // if not, then turn the crosshair white (default color)
            else
                ChangeCrosshairColor(defaultColor);


        }
        // if the raycast is not hitting anything at all, turn the crosshair white (default color)
        else
        {
            ChangeCrosshairColor(defaultColor);
        }
    }

    ///-///////////////////////////////////////////////////////////
    ///
    private void ChangeCrosshairColor(Color color)
    {
        crosshairImage.color = color;
    }
}
