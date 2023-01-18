using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> enemies;
    public int roomNumber;
    public List<Item> itemsToDrop;
    public Door Door;
    [SerializeField]
    private int totalEnemies = 0;
    [SerializeField]
    private int totalCount = -1;


    ///-///////////////////////////////////////////////////////////
    ///
    private void Start()
    {
        SetItem();
        SetDoor();
        SetEnemies();
        CheckCount();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    private void SetItem()
    {
        if (itemsToDrop.Count > 0)
        {
            foreach(Item i in itemsToDrop)
            {
                i.gameObject.SetActive(false);

                i.ID = roomNumber;
            }
        }
    }


    ///-///////////////////////////////////////////////////////////
    ///
    private void SetDoor()
    {
        Transform door = transform.Find("Doors");
        if (door)
        {
            Door = door.GetComponent<Door>();
            Door.ID = roomNumber;
        }
    }

    ///-///////////////////////////////////////////////////////////
    ///
    private void SetEnemies()
    {
       Transform Enemies = transform.Find("Enemies");

        if (Enemies.gameObject.activeSelf)
        {
            foreach(Transform child in Enemies)
            {
                Enemy e = child.GetComponent<Enemy>();
                e.Health.room = this;
                enemies.Add(e);
            }
        }

        totalEnemies = enemies.Count;
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void CheckCount()
    {
        totalCount++;

        if (totalCount >= totalEnemies)
        {
            foreach (Item i in itemsToDrop)
            {
                i.gameObject.SetActive(true);

            }

        }
    }
}
