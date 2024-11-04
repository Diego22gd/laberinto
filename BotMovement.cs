using UnityEngine;

public class BotPatrolPingPong : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] waypoints; // Lista de puntos de patrullaje
    private int currentWaypointIndex = 0; // Índice del punto actual
    private bool movingForward = true; // Determina si se mueve hacia adelante o hacia atrás

    void Update()
    {
        if (waypoints.Length == 0) return; // Asegura que haya puntos

        // Obtén el punto de patrullaje actual
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Mueve el bot hacia el punto actual
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        // Comprueba si el bot ha llegado al punto actual
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Cambia al siguiente punto de patrullaje
            if (movingForward)
            {
                // Si está moviéndose hacia adelante, avanza al siguiente punto
                currentWaypointIndex++;
                // Si llega al final, cambia la dirección
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 1;
                    movingForward = false;
                }
            }
            else
            {
                // Si está en reversa, retrocede al punto anterior
                currentWaypointIndex--;
                // Si llega al inicio, cambia la dirección
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 0;
                    movingForward = true;
                }
            }
        }
    }
}


