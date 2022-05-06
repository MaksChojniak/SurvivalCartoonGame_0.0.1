using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHealth : MonoBehaviour
{
    [Range(0, 100)]
    public int Health;
    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<EnvironmentHealth>().Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
