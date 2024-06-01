using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Kameran�n takip edece�i hedef (oyuncu)
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Kameran�n hedefe g�re konumunu ayarlayan ofset

    public float smoothSpeed = 0.125f; // Kamera hareketinin yumu�akl��� i�in h�z

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Hedefin pozisyonuna ofset ekleyerek hedef konumunu belirle
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Yumu�ak ge�i� yaparak kameran�n hedefe do�ru hareketini sa�la
        transform.position = smoothedPosition; // Kameran�n konumunu g�ncelle
    }
}