using JetBrains.Annotations;
using Unity.VisualScripting;

#if UNITY_EDITORs
using UnityEditorInternal;
#endif
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EnergyPool : MonoBehaviour
{
    //Calling PlayerMovement & ShootMech into this script (for the IsDashing & IsShooting variables, hence the names)
    public PlayerMovement ForIsDashing;
    public ShootMech ForIsShooting;
    public PlayerHealth ForIsBeingShot;


    //Defining range of Energy Pool
    public float CurrentEnergy;
    public float MaxEnergy = 100;

    bool wasDashing = false;
    public bool IsDraining = false;
    public Collider2D player;
    //Establishing variables for energy drain based on distance travelled
    public Rigidbody2D RigBod;
    //public float DistanceLimit = 12f;
    //public float MovementDrain = 0;

    public int CurrentAmmo;
    private int _maxAmmo = 10;
    public int BulletDrain = 1;
    
    Vector2 lastPoint;
    public GameOverUI gameOverUI;

    public ConditionalAudios ForReloadCheck;
    public AudioSource TurretReload;

    void Start()
    {
        ForIsDashing = GetComponent<PlayerMovement>();
        ForIsShooting = GetComponent<ShootMech>();
        
        
        CurrentEnergy = MaxEnergy;
       
        lastPoint = RigBod.position;
    }

    /*private void FixedUpdate()
    {
        //Energy subtraction for distance travelled
        /*float distanceMoved = Vector2.Distance(lastPoint, RigBod.position);
        if (distanceMoved >= DistanceLimit)
        {
            CurrentEnergy -= MovementDrain;
            CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0, MaxEnergy);
            lastPoint = RigBod.position;
            //Debug.Log(CurrentEnergy);
        }*/
    //}

    void Update()
    {
        //Energy subtraction check for dash
        if (ForIsDashing.IsDashing && !wasDashing)
        {
            CurrentEnergy -= 3;
            CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0, MaxEnergy);
            //Debug.Log(CurrentEnergy);
        }
        wasDashing = ForIsDashing.IsDashing;

        //Energy subtraction check for a shot fired

       
        if (ForIsShooting.IsShooting == true && Mouse.current.leftButton.wasPressedThisFrame)
        {
            CurrentAmmo -= 1;
            IsDraining = true;
            CurrentAmmo = Mathf.Clamp(CurrentAmmo, 0, _maxAmmo);
            Debug.Log(CurrentAmmo);
        }
        else {IsDraining = false;}
        if (ForIsBeingShot)
            CurrentEnergy -= 1;
        CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0, MaxEnergy);

        if (CurrentEnergy == 0)
        {
            //Debug.Log("You Have Died");
            SceneManager.LoadScene("GameOverREAL");
        }

        if (Input.GetKeyDown(KeyCode.R) && CurrentEnergy > 10 && CurrentAmmo != 10)
        {
            switch(CurrentAmmo)
            {
                case 0:
                    CurrentEnergy -= 5;
                    CurrentAmmo += 10;
                    TurretReload.PlayOneShot(TurretReload.clip);
                    break;
                case 1:
                    CurrentEnergy -= 5;
                    CurrentAmmo += 9;
                    TurretReload.PlayOneShot(TurretReload.clip);
                    break;
                case 2:
                    CurrentEnergy -= 4;
                    CurrentAmmo += 8;
                    TurretReload.PlayOneShot(TurretReload.clip);
                    break;
                case 3:
                    CurrentEnergy -= 4;
                    CurrentAmmo += 7;
                    TurretReload.PlayOneShot(TurretReload.clip);
                    break;
                case 4:
                    CurrentEnergy -= 3;
                    CurrentAmmo += 6;
                    TurretReload.PlayOneShot(TurretReload.clip);
                    break;
                case 5:
                    CurrentEnergy -= 3;
                    CurrentAmmo += 5;
                    TurretReload.PlayOneShot(TurretReload.clip);
                    break;
                case 6:
                    CurrentEnergy -= 3;
                    CurrentAmmo += 4;
                    TurretReload.PlayOneShot(TurretReload.clip);
                    break;
                case 7:
                    CurrentEnergy -= 2;
                    CurrentAmmo += 3;
                    TurretReload.PlayOneShot(TurretReload.clip);
                    break;
                case 8:
                    CurrentEnergy -= 2;
                    CurrentAmmo += 2;
                    TurretReload.PlayOneShot(TurretReload.clip);
                    break;
                case 9:
                    CurrentEnergy -= 1;
                    CurrentAmmo += 1;
                    TurretReload.PlayOneShot(TurretReload.clip);
                    break;
            }
            Debug.Log(CurrentAmmo);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullets"))
        {
            CurrentEnergy = CurrentEnergy - 1;
            Debug.Log("Hit");

        }

    }

}
