using System.Collections;
using UnityEngine;

public class RisingLava : MonoBehaviour
{
    [SerializeField] private float risingSpeed = 3f;
    [SerializeField] private float risingTime = 3f;
    [SerializeField] private float waitTime = 7f;
    private bool alwaysTrue = true;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LavaRising());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LavaRising()
    {
        while (alwaysTrue)
        {
            while (timer < risingTime)
            {
                transform.position += Vector3.up * risingSpeed * Time.deltaTime;
                timer += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);
            timer = 0f;
        }
    }
}
