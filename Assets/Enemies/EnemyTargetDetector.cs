using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetDetector : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    public FloatReference Range;
    [SerializeField]
    public LayerMaskReference ObstacleLayer;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    public TransformReference Target;
#endregion

    private List<Transform> possibleTargers;

    void Start()
    {
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = Range.Value;

        possibleTargers = new List<Transform>();
        StartCoroutine(FindTarget());
    }

    IEnumerator FindTarget() {

        while(true)
        {

            if(!Target.Value)
            {

                foreach(Transform possible in possibleTargers)
                {

                    RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, possible.position, ObstacleLayer.Value);
                    if(hits.Length == 0)
                    {
                        Target.Value = possible;
                        break;
                    }

                }
                
            }

            yield return new WaitForSeconds(.1f);

        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destructible target = collider.GetComponent<Destructible>();
        if(target)
        {
            possibleTargers.Add(target.transform);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(possibleTargers.Contains(collider.transform)) {
            possibleTargers.Remove(collider.transform);
        }
    }
}
