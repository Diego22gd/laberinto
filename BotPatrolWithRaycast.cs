using UnityEngine;

public class BotPatrolRandom : MonoBehaviour
{
    public float speed = 3f;
    public float detectionDistance = 0.3f; // Ajusta esta distancia según sea necesario
    private Vector2 direction;

    void Start()
    {
        // Escoge una dirección inicial aleatoria
        ChooseRandomDirection();
    }

    void Update()
    {
        // Comprueba si hay una pared en la dirección actual
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionDistance);

        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            // Si detecta una pared, elige una nueva dirección
            ChooseRandomDirection();
        }
        else
        {
            // Mueve el bot en la dirección actual si no hay pared
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void ChooseRandomDirection()
    {
        // Sigue intentando elegir una dirección aleatoria hasta que no haya pared
        int attempts = 0;
        bool directionFound = false;

        while (!directionFound && attempts < 10)
        {
            attempts++;
            // Selecciona una dirección aleatoria
            int randomDirection = Random.Range(0, 4);
            switch (randomDirection)
            {
                case 0: direction = Vector2.right; break;   // Derecha
                case 1: direction = Vector2.left; break;    // Izquierda
                case 2: direction = Vector2.up; break;      // Arriba
                case 3: direction = Vector2.down; break;    // Abajo
            }

            // Comprueba si la dirección seleccionada no tiene una pared
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionDistance);
            if (hit.collider == null || !hit.collider.CompareTag("Wall"))
            {
                directionFound = true;
            }
        }
    }
}


