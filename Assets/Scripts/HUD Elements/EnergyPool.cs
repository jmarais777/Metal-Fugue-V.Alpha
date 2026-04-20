using JetBrains.Annotations;
using UnityEngine;

public class EnergyPool : MonoBehaviour
{
    //Calling PlayerMovement & ShootMech into this script (for the IsDashing & IsShooting variables, hence the names)
    public PlayerMovement ForIsDashing;
    public ShootMech ForIsShooting;
    public PlayerHealth ForIsBeingShot;


    //Defining range of Energy Pool
    public float CurrentEnergy;
    public float MaxEnergy = 100f;

    bool wasDashing = false;
    public Collider2D player;
    //Establishing variables for energy drain based on distance travelled
    public Rigidbody2D RigBod;
    public float DistanceLimit = 12f;
    public float MovementDrain = 1f;
    public float BulletDrain = 1f;
    Vector2 lastPoint;

    void Start()
    {
        ForIsDashing = GetComponent<PlayerMovement>();
        ForIsShooting = GetComponent<ShootMech>();
        
        
        CurrentEnergy = MaxEnergy;
       
        lastPoint = RigBod.position;
    }

    private void FixedUpdate()
    {
        //Energy subtraction for distance travelled
        float distanceMoved = Vector2.Distance(lastPoint, RigBod.position);
        if (distanceMoved >= DistanceLimit)
        {
            CurrentEnergy -= MovementDrain;
            CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0, MaxEnergy);
            lastPoint = RigBod.position;
            //Debug.Log(CurrentEnergy);
        }
    }

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
    if (ForIsShooting.IsShooting == true)
        {
            CurrentEnergy -= 1;
            CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0, MaxEnergy);
            //Debug.Log(CurrentEnergy);
        }
        if (ForIsBeingShot)
            CurrentEnergy -= 1;
        CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0, MaxEnergy);

    if (CurrentEnergy == 0)
        {
            //Debug.Log("You Have Died");
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
