using UnityEngine;

public class FollowBackground : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
