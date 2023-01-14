using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public List<Enemy> enemies;
    public int roomNumber;
    public Item exitKey;
    public Door Door;
    [SerializeField]
    private int totalEnemies = 0;
    [SerializeField]
    private int deathCount = -1;

    private void Awake()
    {
        foreach (Enemy e in enemies)
        {

            //Debug.LogFormat("setting room");
            e.Health.room = this;
        }
    }
    private void Start()
    {
        //assign door and key to room number value
        exitKey.ID = roomNumber;
        if(Door)
            Door.ID = roomNumber;
        exitKey.gameObject.SetActive(false);
        totalEnemies = enemies.Count;
        CheckCount();


    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void CheckCount()
    {
        deathCount++;
        //Debug.LogFormat("checking count  {1} {2}", deathCount, totalEnemies);

        if (deathCount >= totalEnemies)
        {

            Debug.LogFormat("displaying key");
            exitKey.gameObject.SetActive(true);
            
        }
    }
}
