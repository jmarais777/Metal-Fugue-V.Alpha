using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Recall : MonoBehaviour
{
    public EnemyMovement recallDynamics;

    public Transform recall;
    public Transform recallStart;
    public Transform recallP1;
    public Transform recallP2;
    public float recallReposTimer = 10.0f;

    Rigidbody2D RigBod;

    private void Start()
    {
        GetComponent<EnemyMovement>();
        recall.position = recallStart.position;
        RigBod = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        Vector3 recallPos = recall.position - recallP1.position;

        

        if (recallDynamics.IsFollowing == false)
        {
            recallReposTimer -= Time.deltaTime;
        }

        if (recallReposTimer <= 8.0f)
        {
           
            recallDynamics.EnemyNPC.transform.position = recallStart.position;
        }
        if (recallReposTimer <= 6.0f)
        {
            recallDynamics.EnemyNPC.transform.position = recallP1.position;
        }

        if (recallReposTimer <= 4.0f)
        {
            recallDynamics.EnemyNPC.transform.position = recallP2.position;
        }

        if (recallReposTimer <= 2.0f)
        {
            recallReposTimer = 5.0f;
            recallDynamics.EnemyNPC.transform.position = recallStart.position;
        }

























        //Each time the timer is '<=' to a specific value, the enemy recall ghost object teleports to the position of one of its parent ghost objects. In teh enemy movemnet script, the enemy NPC is set to move to the position oft he nemey recall. I think this is causing a logic conflict with a condition i have set when the enemynpc needs to be at the position of the enemyrecallp2.
        /*  if (recallDynamics.IsFollowing == false)
          {
              recallReposTimer -= Time.deltaTime;
          }

          if (recallReposTimer <= 8.0f)
          {
              recall.position = recallStart.position;
          }
          if (recallReposTimer <= 6.0f)
          { 
             recall.position = recallP1.position;
          }

         if (recallReposTimer <= 4.0f)
           {
             recall.position = recallP2.position;
           } 

           if (recallReposTimer <= 2.0f)
               {
                recallReposTimer = 5.0f;
                recall.position = recallStart.position;
                } */





    }



}


