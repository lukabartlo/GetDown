using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScHeart : MonoBehaviour
{
    [SerializeField] private float _grabRange;

    private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, ScPlayerInputs.Instance.rigidbodyPlayer.transform.position) <= _grabRange)
        {
            ScTakeDamage.Instance.currentHealth++;
            Destroy(gameObject);
        }
    }
}
