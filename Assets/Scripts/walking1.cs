using UnityEngine;

public class walking1 : MonoBehaviour
{
    private Vector3 startPos;
    private int speed;
    float moveAtTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //adjust this to change how high it goes
    float height = 0.5f;
    void Start()
    {
        startPos = transform.position;
        speed = Random.Range(0, 10);
        moveAtTime = Time.time + 50f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > moveAtTime)
        {
            //calculate what the new Y position will be
            float newY = Mathf.Sin(Time.time * speed) * height + startPos.y;
            //set the object’s Y to the new calculated Y
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

}
