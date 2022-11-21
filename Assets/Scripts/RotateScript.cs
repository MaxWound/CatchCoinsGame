using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private void Update()
    {
        transform.RotateAroundLocal(new Vector3(1, 0, 0), 1 * Time.deltaTime);
    }
}
