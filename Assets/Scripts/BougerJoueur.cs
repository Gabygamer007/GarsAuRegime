using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BougerJoueur : MonoBehaviour
{
    private Rigidbody2D rig;
    private Vector2 mouvementFleche;

    [SerializeField]
    private float vitesse;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        mouvementFleche = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        mouvementFleche.x = Input.GetAxisRaw("Horizontal");
        mouvementFleche.y = Input.GetAxisRaw("Vertical")*0.7f;
    }

    void FixedUpdate()
    {
        rig.AddForce(mouvementFleche * vitesse);
        //rig.velocity = mouvementFleche * vitesse;
        //rig.velocity = rig.velocity.normalized * vitesse;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Aliments")
        {
            Destroy(collision.gameObject);
            rig.AddForce(Vector2.right * 10.0f, ForceMode2D.Impulse);
        }

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Poubelle")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
            
        }
    }
}
