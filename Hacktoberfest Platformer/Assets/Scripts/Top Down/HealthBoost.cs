using Photon.Pun;
using UnityEngine;

public class HealthBoost : Interactable
{
    [Range(1, 100)]
    public int boostAmount = 15;

    [SerializeField]
    [TagSelector]
    private string tagToCollideWith = "";

    public TextPromptTrigger textPrompt;
    ///-///////////////////////////////////////////////////////////
    ///
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        

        if (health != null && collision.tag == tagToCollideWith)
        {
            // If the player needs a health boost

            //Debug.LogFormat("total {0} max {1}", health.totalHealth, health.maxHealth);

            if (health.totalHealth < health.maxHealth)
            {
                health.ModifyHealth(boostAmount);
                //destroy bottle
                Destroy(gameObject);
            }
            else
            {
                //int pv = collision.gameObject.GetComponent<PhotonView>().ViewID;

                //if (hasInteracted == false)
                //{
                //    base.AttemptDialog(pv);
                //    textPrompt.TriggeredDialog(pv);
                //    hasInteracted = true;
                //}

                // Debug.LogFormat("triggering dialog");

            }



        }
    }


}
