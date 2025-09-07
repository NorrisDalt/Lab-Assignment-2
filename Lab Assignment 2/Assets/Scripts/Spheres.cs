using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    [SerializeField] private  float size;
    // Start is called before the first frame update
    private void OnValidate()
    {
        // Clamp size within expected range (optional)
        size = Mathf.Clamp(size, 0.01f, 100f);

        // Apply the size to the GameObject's scale
        transform.localScale = Vector3.one * size;
    }
}
