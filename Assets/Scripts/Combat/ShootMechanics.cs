#if UNITY_EDITOR
using UnityEditor.Search;

#endif
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Tilemaps;
using System;


public class ShootMech : MonoBehaviour
{
    //this creates a firepoint container, the the wepaon object is stored in.
    public Transform Firepoint;
    //This creates a container for the bullet object.
    public GameObject Bullets;
    public Transform WeaponCenter;
    public bool IsShooting = false;
    // public GameObject MuzzleFlash;
    public EnergyPool Energy_Pool;
    public ConditionalAudios ForShotHappened;

    private void Start()
    {
        Energy_Pool.CurrentAmmo = 10;
    }
    void Update()
    {  
       if (Time.timeScale == 0.0f)
        {
            return;
        }
        //this causes a single fire shoot response ecach time the left mouse button is clicked.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = mousePos - WeaponCenter.position;
        WeaponCenter.right = direction;

        if (Energy_Pool.CurrentAmmo < 1)
        {
            return;
        }
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
            IsShooting = true;
            ForShotHappened.ShotHappened = true;

                Shoot();
            Debug.Log(Energy_Pool.CurrentAmmo);
            }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            IsShooting = false;
            ForShotHappened.ShotHappened = false;
        }
        
      

        void Shoot()
        
        {
            Instantiate(Bullets, Firepoint.position, Firepoint.rotation);
        }

      


    }




}
