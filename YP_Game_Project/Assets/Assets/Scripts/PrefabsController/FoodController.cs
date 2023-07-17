using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public Transform MyTransform;
    public float MagnetSpeed = 5;
    public Vector3 LeftMovement;
    public Vector3 LeftMovementMagneted;
    public float MagnetDinstance = 5;
    public void Consumed()
    {
        SpawnController.Instance.Despawn(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(MyTransform.position,MagnetDinstance);
    }
    void Update()
    {

        if (MenuController.Instance.IsGameInProgress)
        {
            Vector3 TargetVector = (PlayerController.Instance.LastFramePosition - MyTransform.position).normalized;
            float CurrentDinstance = Vector3.Distance(PlayerController.Instance.LastFramePosition, MyTransform.position);
            if (CurrentDinstance < MagnetDinstance)
            {
                MyTransform.Translate((TargetVector* MagnetSpeed+ LeftMovementMagneted) *Time.deltaTime);
            }
            else
            {
                MyTransform.Translate((LeftMovement) * Time.deltaTime);
            }

            /*Vector3 Target = (PlayerController.Instance.LastFramePosition - MyTransform.position).normalized *
            (1 / Vector3.Distance(PlayerController.Instance.LastFramePosition, MyTransform.position));
            MyRigidbody.AddForce(FromVector2ToVector3(Target * SpeedMultipy + LeftMovement));
            */
        }
    }
    Vector2 FromVector2ToVector3(Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }
}
