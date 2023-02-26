using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject bulletImpact;
    public Animator gunAnimator;
    public float shooting;
    public Camera cam;
    public TextMeshProUGUI AmmoGUI;
    public float currentAmmo;
    private float totalAmmo;
    public float fireRate;
    public bool able2Fire;

    public int damage;

    ///-///////////////////////////////////////////////////////////
    ///
    void Start()
    {
        totalAmmo = currentAmmo;
    }

    ///-///////////////////////////////////////////////////////////
    ///
    void Update()
    {
        if (shooting > 0 && currentAmmo > 0 && able2Fire)
        {
            able2Fire = false;

            //Create raycast at middle of our camera
            Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;

            //If we hit anything with our raycast
            if(Physics.Raycast(ray,out hit))
            {
                Instantiate(bulletImpact, hit.point,transform.rotation);

                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<EnemyHealth>().ModifyHealth(-damage);
                }
            }
            else
            {
                Debug.Log("Looking at: nothing");
            }

            currentAmmo--;
            gunAnimator.SetTrigger("Shoot");
            StartCoroutine("delayFire");
        }
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void GiveAmmo(int amount)
    {
        // give some ammo, then update the ammo UI
        currentAmmo += amount;

        AmmoGUI.text = totalAmmo.ToString() + " / " + currentAmmo.ToString();
    }


    ///-///////////////////////////////////////////////////////////
    ///
    IEnumerator delayFire()
    {
        yield return new WaitForSeconds(fireRate);
        able2Fire = true;
    }

    #region ControllerCallbacks
    ///-///////////////////////////////////////////////////////////
    ///
    public void OnFire(CallbackContext inputValue)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("firing");

        //attackAnimator.SetBool("isAttacking", true);
        shooting = inputValue.ReadValue<float>();
        
        AmmoGUI.text = totalAmmo.ToString() + " / " + currentAmmo.ToString(); ;

    }
    #endregion
}
