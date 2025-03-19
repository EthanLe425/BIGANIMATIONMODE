using UnityEngine;

public class walking : MonoBehaviour
{
    private Vector3 startPos;
    private int speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //adjust this to change how high it goes
    float height = 0.5f;
    void Start()
    {
        startPos = transform.position;
        speed = Random.Range(0, 10);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + startPos.y;
        //set the object’s Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void FixedUpdate()
    {
        Vector3 currentPos = transform.position;
        float dist = Vector3.Distance(currentPos, startPos);

        // random speed change every 30 feet
        if (dist % 30 == 0)
        {
            speed = Random.Range(0, 10);
        }
    }
}
