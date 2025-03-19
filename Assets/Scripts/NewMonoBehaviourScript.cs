using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour
{
    public Transform[] waypoints;
    public float time = 1f;
    public float rotS = 11.3f;

    void Start()
    {
        StartCoroutine(FollowPath());
    }
    IEnumerator FollowPath()
    {
        yield return new WaitForSeconds(9.6f);
        float durr = 0f;
        while(durr<6f)
        {
            transform.position+=transform.up*rotS*Time.deltaTime;
            durr += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
