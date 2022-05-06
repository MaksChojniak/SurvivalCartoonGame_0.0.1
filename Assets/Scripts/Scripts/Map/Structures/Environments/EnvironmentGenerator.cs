using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnvironmentGenerator : MonoBehaviour
{

    [SerializeField] GameObject prefab;

    [Header("Raycast Settings")]
    [SerializeField] int density;


    [Space]

    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [SerializeField] Vector2 xRange;
    [SerializeField] Vector2 zRange;

    [Header("Prefab Variation Settings")]
    [SerializeField, Range(0, 1)] float rotateTowardsNormal;
    [SerializeField] Vector2 rotationRange;
    [SerializeField] Vector3 minScale;
    [SerializeField] Vector3 maxScale;



    public void Generate()
    {
        Clear();

        for (int i = 0; i < density; i++)
        {
            float sampleX = Random.Range(xRange.x, xRange.y);
            float sampleY = Random.Range(zRange.x, zRange.y);
            Vector3 rayStart = new Vector3(sampleX, maxHeight, sampleY);

            if (!Physics.Raycast(rayStart, Vector3.down, out RaycastHit hit, Mathf.Infinity))
                continue;
            if (hit.point.y < minHeight)
                continue;

            GameObject instatiatedPrefab = Instantiate(this.prefab, transform);

            instatiatedPrefab.AddComponent<EnvironmentHealth>();
            instatiatedPrefab.layer = 7;
            instatiatedPrefab.transform.position = hit.point;
            instatiatedPrefab.transform.Rotate(Vector3.up, Random.Range(rotationRange.x, rotationRange.y), Space.Self);
            instatiatedPrefab.transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.FromToRotation(instatiatedPrefab.transform.up, hit.normal), rotateTowardsNormal);
            instatiatedPrefab.transform.localScale = new Vector3(
                Random.Range(minScale.x, maxScale.x),
                Random.Range(minScale.y, maxScale.y),
                Random.Range(minScale.z, maxScale.z)
                );
        }
    }
    public void Clear()
    {
        while (transform.childCount != 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

}