using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovDetection : MonoBehaviour
{
    //Transform of target
    public Transform Target;
    public float maxAngle;

    public float maxRadius;

    private bool isInField;

    //draw the outline of FOV
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
        Vector2 fovLineR = Quaternion.AngleAxis(maxAngle, Vector3.forward) * transform.up * maxRadius;
        Vector2 fovLineL = Quaternion.AngleAxis(-maxAngle, Vector3.forward) * transform.up * maxRadius;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, fovLineR);
        Gizmos.DrawRay(transform.position, fovLineL);

        //green if not seen red if seen
        if (!isInField)
        {
            Gizmos.color = Color.cyan;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(transform.position, (Target.position - transform.position).normalized * maxRadius);

        //Gizmos.color = Color.black;
        //Gizmos.DrawRay(transform.position, transform.up * maxRadius);
    }

    //True if target is seen within FOV flase otherwise
    //MainEnemy: Object with FOV
    //Target: Object enemy is searching for
    public bool inFieldView(Transform MainEnemy, Transform target, float MaxAngle, float MaxRadius)
    {
        int layerMask = (1<<11)|(1<<12);
        //Grab all objects that overlap with the FOV Radius
        //if there is more then 100 items this could cause overflow
        Collider2D[] withinRadius = new Collider2D[100];
        int count = Physics2D.OverlapCircleNonAlloc(MainEnemy.position,MaxRadius, withinRadius);

        for(int i = 0; i < count + 1; i++)
        {

            if (withinRadius[i] != null)
            {
                //if the current object is the target
                if(withinRadius[i].transform == target)
                {

                    //get vector from target to MainEnemy
                    Vector2 directionToTarget = (target.position - MainEnemy.position).normalized;

                    float Angle = Vector2.Angle(MainEnemy.up, directionToTarget);

                    if(Angle <= MaxAngle)
                    {
                        //shoot a raycast toward the target if with the FOV angle
                        RaycastHit2D hit = Physics2D.Raycast(MainEnemy.position, target.position - MainEnemy.position, MaxRadius,layerMask);

                        //Check if ray has hit the target if true MainEnemy sees the target,
                        //if false an object is in the way
                        if(hit.transform == target.transform)
                        {
                            return true;
       
                        }
                    }
                }
            }
        }

        return false;
    }


    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindWithTag("Player").transform;
        isInField = inFieldView(transform, Target, maxAngle, maxRadius);
    }

    // Update is called once per frame
    void Update()
    {
        isInField = inFieldView(transform, Target, maxAngle, maxRadius);
    }

    public bool IsInView()
    {
        return inFieldView(transform, Target, maxAngle, maxRadius);
    }
}
