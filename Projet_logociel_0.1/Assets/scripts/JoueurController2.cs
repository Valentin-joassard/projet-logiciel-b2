﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class JoueurController2 : MonoBehaviour
{
    public int joueurId = 1;
    public Animator animator;
    public GameObject Cible;
    public GameObject projectilePrefab;
    public Rigidbody2D rb;
    void Update()
    {


        Vector3 mouvement = new Vector3(Input.GetAxis("MoveHorizontalRouge"), Input.GetAxis("MoveVerticalRouge"), 0.0f);
        shoot(mouvement.x, mouvement.y);

        //MoveCrossHairandShoot();
        animator.SetFloat("Horizontal", mouvement.x);
        animator.SetFloat("Vertical", mouvement.y);
        animator.SetFloat("Magnitude", mouvement.magnitude);

        rb.velocity = new Vector2(mouvement.x, mouvement.y);
    }

    private void MoveCrossHairandShoot()
    {
        Vector3 aim = new Vector3(Input.GetAxis("AimHorizontalRouge"), Input.GetAxis("AimVerticalRouge"), 0.0f);
        Vector2 shootingDirection = new Vector2(Input.GetAxis("AimHorizontalRouge"), Input.GetAxis("AimVerticalRouge"));
        if (aim.magnitude > 0.0f)
        {

            aim *= 0.8f;
            Cible.transform.localPosition = aim;
            Cible.SetActive(true);

            if (Input.GetButtonDown("FireRouge"))
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

    private void shoot(float movementX, float movementY)
    {
        Vector2 shootingDirection = new Vector2(movementX, movementY);
        Vector3 aim = new Vector3(movementX, movementY, 0.0f);
        //Vector3 aim = new Vector3(1.0f,0.0f, 0.0f) ;
        float bulletSpeed = GameObject.Find("gris").GetComponent<BonusMalusBulletSpeed>().speed;

        if (aim.magnitude > 0.0f)
        {

            aim *= 0.4f;
            Cible.transform.localPosition = aim;
            Cible.SetActive(true);
            if (Input.GetButtonDown("FireRouge"))
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                projectile projectileScript = projectile.GetComponent<projectile>();
                projectileScript.velocity = shootingDirection * bulletSpeed;
                projectileScript.petitbonhomme = gameObject;

                projectile.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
                //projectile.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(1.0f, 0.0f) * Mathf.Rad2Deg);
                Destroy(projectile, 3.0f);
            }
        }
        else
        {
            Cible.SetActive(false);
        }
    }

}