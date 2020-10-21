using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float bombTimer = 2f;
    [SerializeField] private LayerMask explosionMask;
    [SerializeField] private float explosionRadius = 1.5f;

    private void Start()
    {
        StartCoroutine(TimeExplode(bombTimer));
    }

    private void Exploid()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, explosionMask);
        foreach (var collider in colliders)
        {
            Destroy(collider.gameObject);
            if (collider.gameObject.CompareTag("Player"))
            {
                var index = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(index);
            }
            
            Destroy(gameObject);
            gameObject.SetActive(false);
            
            
        }
    }

    private IEnumerator TimeExplode(float delay)
    {
        yield return new WaitForSeconds(delay);
        Exploid();
    }
}
