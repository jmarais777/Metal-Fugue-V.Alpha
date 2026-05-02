#if UNITY_EDITOR
using UnityEditor.Tilemaps;
#endif
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class EnemySHootMech : MonoBehaviour
{
    //this creates a firepoint container, the the wepaon object is stored in.
   
    //This creates a container for the bullet object.
    public GameObject EnemyBullets;
    public Transform FirePoint;
    public Transform WeaponCenter;
    public Transform Player;
    public float Timer = 3.0f;
    public float AttackDuration = 5.0f;
    public bool IsShooting = false;
    public bool IsEnemyNPCSetActive = true;
    private float LoopS = 3.0f;
    public float FireRate = 1.0f;
    public float BulletSpawnRate = 0.5f;

 

    private void Start()
    {
        Timer = LoopS;
      
    }

    void Update()
    {

        Vector2 direction = (Player.position - WeaponCenter.position).normalized;
        WeaponCenter.right = direction;

        if (IsShooting == false)
        {
            Timer -= Time.deltaTime;


            if (Timer <= 0)
            {
                IsShooting = true;
            }
        }
        else
        {
            Shoot();
            AttackDuration -= Time.deltaTime;
        }

        if (AttackDuration <= 0)
        {
            IsShooting = false;
            Timer = LoopS;
            AttackDuration = 5;
        }
    }
    public void Shoot()
    {
         
        if (Time.time >= BulletSpawnRate)
        {
           
            Instantiate(EnemyBullets, FirePoint.position, FirePoint.rotation);
            BulletSpawnRate = Time.time + FireRate;

        }

    }


}






