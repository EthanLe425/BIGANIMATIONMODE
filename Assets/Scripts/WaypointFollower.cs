using UnityEngine;
using System.Collections;

public class WaypointFollower : MonoBehaviour
{
    public Transform[] waypoints;
    public float time = 1f;
    public float rotS = 2f;
    public int cubert = 50;
    private int curr = 0;
    public float cubeS = 1f;
    public GameObject cube;
    private bool slide = false;
    public GameObject airplane;
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
                if (slide)
                {
                    cube.transform.localPosition = Vector3.MoveTowards(cube.transform.localPosition, new Vector3(0, -0.687f, -0.101f), cubeS * Time.deltaTime);
                }
                currTime += Time.deltaTime;
                yield return null;
            }

            transform.position = pos2;
            transform.rotation = rot2;
            Debug.Log(curr);
            curr++;
            if(curr==cubert)
            {
                slide = true;
            }
        }
        float back = 0.5f;
        float durr = 0f;
        Vector3 eA = transform.eulerAngles; 
        eA.x += 90;
        eA.y -= 90;
        while(durr<back)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(eA), durr/back);
            durr += Time.deltaTime;
            yield return null;
        }
        transform.rotation = Quaternion.Euler(eA);
        airplane.SetActive(true);
        airplane.transform.SetParent(null, true);
        durr = 0f;
        while (durr < 1f)
        {
            airplane.transform.position += airplane.transform.up * 5 * Time.deltaTime;
            durr += Time.deltaTime;
            yield return null;
        }
        durr = 0f;
        eA = new Vector3(airplane.transform.rotation.eulerAngles.x + 90, airplane.transform.rotation.eulerAngles.y, airplane.transform.rotation.eulerAngles.z);
        while (durr < 1f)
        {
            airplane.transform.rotation = Quaternion.Slerp(airplane.transform.rotation, Quaternion.Euler(eA), durr / 1f);
            durr += Time.deltaTime;
            yield return null;
        }
        airplane.transform.rotation = Quaternion.Euler(eA);
        durr = 0f;
        back = 5f;
        while (durr < back)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position-(transform.forward*0.1f), durr / back);
            durr += Time.deltaTime;
            yield return null;
        }
        transform.position = transform.position - (transform.forward * 0.1f);
    }
}
