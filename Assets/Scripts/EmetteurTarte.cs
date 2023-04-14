using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmetteurTarte : MonoBehaviour
{
    public Transform prefabTarte;

    void Start()
    {
        StartCoroutine(EmissionTarte());
    }

    void Update()
    {
        
    }

    IEnumerator EmissionTarte()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));

            Transform nouvelleTarte = Instantiate(prefabTarte);
            float random_x = Random.Range(-8.0f, 1.0f);
            nouvelleTarte.position = new Vector3(random_x, transform.position.y);
        }
    }
}
