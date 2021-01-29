using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    public Transform targetPlayer;

    private Vector3 lastPositionX;
    private Vector3 posX;
    private Vector3 lastPositionY;
    private Vector3 posY;

    public float largeur;
    public float hauteur;

    public float travelDuration;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = targetPlayer.position;
        UpdatePosition();
        lastPositionX = posX;
        lastPositionY = posY;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();

        if (lastPositionX != posX)
        {
            transform.DOMoveX(largeur * posX.x, travelDuration).SetEase(Ease.OutCubic);
            lastPositionX = posX;
        }

        if (lastPositionY != posY)
        {
            transform.DOMoveY(hauteur * posY.y, travelDuration).SetEase(Ease.OutCubic);
            lastPositionY = posY;
        }
    }

    void UpdatePosition()
    {
        posX = targetPlayer.position;
        posX.x = Mathf.FloorToInt((posX.x + (largeur/2)) / largeur);

        posY = targetPlayer.position;
        posY.y = Mathf.FloorToInt((posY.y + (hauteur/2)) / hauteur);
    }
}
