using UnityEngine;
using System.Collections;

public class WaypointFollower : MonoBehaviour
{
    public Transform[] waypoints;
    public float time = 1f;
    public float rotS = 2f;

    private int curr = 0;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            StartCoroutine(FollowPath());
        }
    }
    IEnumerator FollowPath()
    {
        while (curr < waypoints.Length - 1)
        {
            Vector3 pos1 = transform.position;
            Vector3 pos2 = waypoints[curr + 1].position;
            float currTime = 0f;
            Quaternion rot1 = transform.rotation;
            Quaternion rot2 = Quaternion.LookRotation(pos2 - pos1);

            while (currTime < time)
            {
                transform.position = Vector3.Lerp(pos1, pos2, currTime / time);
                transform.rotation = Quaternion.Slerp(rot1, rot2, currTime / (time / rotS));

                currTime += Time.deltaTime;
                yield return null;
            }

            transform.position = pos2;
            transform.rotation = rot2;
            curr++;
        }
    }
}
