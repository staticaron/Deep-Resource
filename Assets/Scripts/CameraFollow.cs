using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    [Tooltip("More value will make the follow more instant and snappier")]
    private float snappyness;

    [SerializeField]
    private float maxLerpDisplacement;

    private void LateUpdate() {
        Vector2 thisPosition = this.transform.position;

        if(Mathf.Sqrt(Vector2.SqrMagnitude(thisPosition - (Vector2)target.position)) < maxLerpDisplacement)
        {
            transform.position = new Vector3(Vector2.Lerp(thisPosition, target.transform.position, Time.deltaTime * snappyness).x, Vector2.Lerp(thisPosition, target.transform.position, Time.deltaTime * snappyness).y, -10);
        }
        else{
            transform.position = new Vector3(Vector2.Lerp(thisPosition, target.transform.position, Time.deltaTime * snappyness * 10).x, Vector2.Lerp(thisPosition, target.transform.position, Time.deltaTime * snappyness * 10).y, -10);
        }
    }
}
