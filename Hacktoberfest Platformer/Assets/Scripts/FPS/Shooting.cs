using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Shooting : MonoBehaviour
{
    public GameObject bulletImpact;
    public Animator gunAnimator;
    public float shooting;
    public Camera cam;

    public float currentAmmo;
    public float fireRate;
    public bool able2Fire;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                    hit.transform.GetComponent<EnemyHealth>().ModifyHP(-damage);
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

        Debug.Log("firing");
        //attackAnimator.SetBool("isAttacking", true);
        shooting = inputValue.ReadValue<float>();

    }
    #endregion
}
