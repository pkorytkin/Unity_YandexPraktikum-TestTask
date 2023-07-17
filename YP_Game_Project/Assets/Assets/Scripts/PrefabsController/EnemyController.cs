using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum Movement { ToDefault,ToTarget};
    public Movement MovementState;
    public Transform MyTransform;
    public Vector3 LeftMovement;
    public float MaxYPosition;
    public float MinYPosition;

    float DefaultYPosition;
    float TargetMaxYPosition;

    public float YMovementSpeed=3;

    public float MinDistance = 0.01f;

    public float LeftBorderForDestroy = -30;

    private void Awake()
    {
        DefaultYPosition = MyTransform.position.y;
        TargetMaxYPosition = Random.Range(MinYPosition, MaxYPosition);
        if (Mathf.Abs(TargetMaxYPosition - DefaultYPosition) < 2f) 
        {
            YMovementSpeed = 0;
        }
    }
    void Update()
    {

        if (MenuController.Instance.IsGameInProgress)
        {
            MyTransform.Translate((LeftMovement) * Time.deltaTime);
            Vector3 TargetPoint = new Vector3(MyTransform.position.x, MovementState == Movement.ToDefault ? TargetMaxYPosition: DefaultYPosition,0);
            if (Vector3.Distance(MyTransform.position, TargetPoint)<=MinDistance) 
            {
                MovementState = MovementState==Movement.ToDefault?Movement.ToTarget:Movement.ToDefault;
            }
            MyTransform.Translate((TargetPoint - MyTransform.position).normalized * YMovementSpeed * Time.deltaTime);
            if (TargetPoint.x < LeftBorderForDestroy)
            {
                SpawnController.Instance.Despawn(gameObject);
            }
        }
    }
}
