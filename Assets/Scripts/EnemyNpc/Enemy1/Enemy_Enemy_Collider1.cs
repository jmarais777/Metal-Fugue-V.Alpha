using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy_Enemy_Collider1 : MonoBehaviour
{
    public EnemyMovementFinal Enemy_Move_Fin;
    private LayerMask layer_mask;
    public Rigidbody2D RigBod;
    public Transform player;
    public Vector2[] RayDirections =
     {
        Vector2.left,
        Vector2.right,
        Vector2.up,
        Vector2.down,
    };


    private void Start()
    {
        RigBod = GetComponent<Rigidbody2D>();
        layer_mask = LayerMask.GetMask("Heaps");
    }

    void Update()
    {
        Vector2 RayCast_Origin = transform.position;
        float ReposDistance = 5.0f;
        float RayCastSpeed = 10.0f;

        foreach (Vector2 dir in RayDirections)
        {
            RaycastHit2D currentHit = Physics2D.Raycast(RayCast_Origin, dir, ReposDistance, layer_mask);
            if (currentHit.collider != null)
            {
                RigBod.linearVelocity = dir * -1 * RayCastSpeed;
                Debug.DrawRay(RayCast_Origin, dir * ReposDistance, Color.gold);
            }

        }
    }
}


