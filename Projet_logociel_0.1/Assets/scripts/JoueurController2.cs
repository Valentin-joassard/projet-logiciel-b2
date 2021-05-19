using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class JoueurController2 : MonoBehaviour
{
    public int joueurId = 1;
    public Animator animator;
    public GameObject Cible;
    public GameObject projectilePrefab;
    public Rigidbody2D rb;
    public int streak = 0;
    public int score = 0;
    void Update()
    {

        Vector3 mouvement = new Vector3(Input.GetAxis("MoveHorizontalGris"), Input.GetAxis("MoveVerticalGris"), 0.0f);


        MoveCrossHairandShoot();
        animator.SetFloat("Horizontal", mouvement.x);
        animator.SetFloat("Vertical", mouvement.y);
        animator.SetFloat("Magnitude", mouvement.magnitude);

        rb.velocity = new Vector2(mouvement.x, mouvement.y);
    }

    private void MoveCrossHairandShoot()
    {
        Vector3 aim = new Vector3(Input.GetAxis("AimHorizontalGris"), Input.GetAxis("AimVerticalGris"), 0.0f);
        Vector2 shootingDirection = new Vector2(Input.GetAxis("AimHorizontalGris"), Input.GetAxis("AimVerticalGris"));
        if (aim.magnitude > 0.0f)
        {

            aim *= 0.8f;
            Cible.transform.localPosition = aim;
            Cible.SetActive(true);

            if (Input.GetButtonDown("FireGris"))
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                projectile projectileScript = projectile.GetComponent<projectile>();
                projectileScript.velocity = shootingDirection;
                projectileScript.petitbonhomme = gameObject;

                projectile.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
                Destroy(projectile, 3.0f);
            }
        }
        else
        {
            Cible.SetActive(false);
        }

    }
    
}

