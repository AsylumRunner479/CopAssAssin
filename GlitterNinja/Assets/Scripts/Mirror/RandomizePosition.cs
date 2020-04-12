using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePosition : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        cube.transform.position += new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f));
    }

    // Update is called once per frame
    void Update()
    {
        cube.transform.position += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}
