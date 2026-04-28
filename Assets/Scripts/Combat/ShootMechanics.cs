#if UNITY_EDITOR
using UnityEditor.Search;

#endif
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Tilemaps;


public class ShootMech : MonoBehaviour
{
    //this creates a firepoint container, the the wepaon object is stored in.
    public Transform Firepoint;
    //This creates a container for the bullet object.
    public GameObject Bullets;
    public Transform WeaponCenter;
    public bool IsShooting = false;
    public GameObject MuzzleFlash;
 
   


    Rigidbody2D rb;

    void Update()
    {  
       
        //this causes a single fire shoot response ecach time the left mouse button is clicked.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = mousePos - WeaponCenter.position;
        WeaponCenter.right = direction;
       

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
           
            Shoot();
            IsShooting = true;
            MuzzleFlash.SetActive(true);
            

        }

        else
        {
            IsShooting = false;
            MuzzleFlash.SetActive(false);
        }

        void Shoot()
        
        {
            Instantiate(Bullets, Firepoint.position, Firepoint.rotation);


        }


    }




}
