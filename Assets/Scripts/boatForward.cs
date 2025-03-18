using UnityEngine;

public class boatForward : MonoBehaviour
{
    float moveAtTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAtTime = Time.time + 50f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > moveAtTime)
        {
            transform.Translate(4 * Vector3.forward * Time.deltaTime);
        }
    }
}