using UnityEngine;


public class NewMonoBehaviourScript : MonoBehaviour
{
   public Scav_Move_Final move;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("SCAV COLLIDED WITH: " + collider.gameObject.name);

        if (collider.gameObject.name == "ScavPath1Fin")
        {
            Debug.Log("SCAV!!!1");
            move.ScavState = Scav_Move_Final.Scav_State.Scav_Path2;
        }
        if (collider.gameObject.name == "ScavPath2Fin")
        {
            Debug.Log("SCAV!!!2");
            move.ScavState = Scav_Move_Final.Scav_State.Scav_Rest;
        }
    }
}
