using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls a magic laser beam that grows towards the mouse position.
/// Stops growing on collision with indestructible objects, then fades out.
/// </summary>
public class MagicLaser : MonoBehaviour
{
    [SerializeField] 
    private float laserGrowTime = 2f; // Time in seconds for laser to reach full length

    private bool isGrowing = true; // Flag to control laser growth
    private float laserRange; // Target length of the laser
    private SpriteRenderer spriteRenderer; // Reference to the laser's sprite renderer
    private CapsuleCollider2D capsuleCollider2D; // Reference to the laser's collider

    /// <summary>
    /// Initializes component references on awake.
    /// </summary>
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    /// <summary>
    /// Orients the laser towards the mouse position at start.
    /// </summary>
    private void Start()
    {
        LaserFaceMouse();
    }

    /// <summary>
    /// Detects collision with non-trigger indestructible objects and stops growth.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Indestructible>() && !other.isTrigger)
        {
            isGrowing = false;
        }
    }

    /// <summary>
    /// Sets the target laser range and begins the growth coroutine.
    /// </summary>
    public void UpdateLaserRange(float laserRange)
    {
        this.laserRange = laserRange;
        StartCoroutine(IncreaseLaserLengthRoutine());
    }

    /// <summary>
    /// Coroutine to gradually increase laser length over time.
    /// Updates sprite size and collider accordingly.
    /// Starts fade routine once fully grown.
    /// </summary>
    private IEnumerator IncreaseLaserLengthRoutine()
    {
        float timePassed = 0f;

        while (spriteRenderer.size.x < laserRange && isGrowing)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / laserGrowTime;

            // Scale sprite width from 1 to target range
            spriteRenderer.size = new Vector2(Mathf.Lerp(1f, laserRange, linearT), 1f);

            // Update collider size and offset to match sprite
            float newLength = Mathf.Lerp(1f, laserRange, linearT);
            capsuleCollider2D.size = new Vector2(newLength, capsuleCollider2D.size.y);
            capsuleCollider2D.offset = new Vector2(newLength / 2, capsuleCollider2D.offset.y);

            yield return null;
        }

        // Trigger fade effect once growth complete
        StartCoroutine(GetComponent<SpriteFade>().SlowFadeRoutine());
    }

    /// <summary>
    /// Rotates the laser to face the current mouse position.
    /// Called once at start; consider calling in Update for continuous tracking.
    /// </summary>
    private void LaserFaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = (Vector2)transform.position - (Vector2)mousePosition; // Direction from mouse to laser
        transform.right = direction.normalized; // Rotate to point towards mouse
    }
}