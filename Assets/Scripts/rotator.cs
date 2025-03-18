using UnityEngine;

public class rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 0, 60) * Time.deltaTime);
    }
}
