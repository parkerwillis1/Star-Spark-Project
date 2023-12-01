using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionScript : MonoBehaviour
{

    public GameObject Explosion;
    public float HP;
    public Transform particleParent;
    public float ExplosionScale = 10f;

    private bool dead;

    public bool Asteroid;
    public bool Metal;

    public bool isPlayer = false;


    void Update()
    {
        if (!dead && HP <= 0f)
        {
            StartCoroutine(Death());
            dead = true;
        }
    }
    IEnumerator Death()
    {
        // Notify before destroying the gameObject
        if (NebulaManager.instance != null)
        {
            NebulaManager.instance.EnemyDestroyed();
        }
        else
        {
            Debug.LogError("NebulaManager instance is null.");
        }

        Debug.Log("Enemy is about to be destroyed"); // Log before destroying the gameObject

        if (SpaceshipController.instance != null)
        {
            if (SpaceshipController.instance.m_spaceship.enemies.Contains(gameObject))
            {
                SpaceshipController.instance.m_spaceship.enemies.Remove(gameObject);
            }
        }
        else
        {
            if (SpaceshipController2D.instance.m_spaceship.enemies.Contains(gameObject))
            {
                SpaceshipController2D.instance.m_spaceship.enemies.Remove(gameObject);
            }
        }

        if (isPlayer)
        {
            PersistentGameOverMenu gameOverMenu = FindObjectOfType<PersistentGameOverMenu>();
            if (gameOverMenu != null)
            {
                gameOverMenu.GetComponent<GameOverMenu>().ShowGameOverMenu();
            }
        }

        if (GetComponent<BasicAI>() != null)
        {
            if (GetComponent<BasicAI>().shoot != null)
            {
                GetComponent<BasicAI>().StopCoroutine(GetComponent<BasicAI>().shoot);
            }
        }
        GetComponent<Renderer>().enabled = false;

        foreach (Transform child in transform)
        {
            if (child.GetComponent<Renderer>() != null)
            {
                child.GetComponent<Renderer>().enabled = false;
            }
        }
        if (particleParent != null)
        {
            foreach (Transform child in particleParent)
            {
                child.gameObject.SetActive(false);
            }
        }
        GetComponent<Collider>().enabled = false;

        if (Explosion != null)
        {
            GameObject firework = Instantiate(Explosion, transform.position, transform.rotation);
            firework.transform.localScale = firework.transform.localScale * ExplosionScale;
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject); // GameObject is destroyed here, so any code after this won't be executed.
            yield return new WaitForSeconds(2f);
            Destroy(firework);
        }
        else
        {
            Destroy(gameObject); // GameObject is destroyed here, so any code after this won't be executed.
        }
    }
}
