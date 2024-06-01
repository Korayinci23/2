using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Kameranýn takip edeceði hedef (oyuncu)
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Kameranýn hedefe göre konumunu ayarlayan ofset

    public float smoothSpeed = 0.125f; // Kamera hareketinin yumuþaklýðý için hýz

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Hedefin pozisyonuna ofset ekleyerek hedef konumunu belirle
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Yumuþak geçiþ yaparak kameranýn hedefe doðru hareketini saðla
        transform.position = smoothedPosition; // Kameranýn konumunu güncelle
    }
}