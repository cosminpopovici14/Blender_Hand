using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScoreGenerator : MonoBehaviour
{
    private XRGrabInteractable grab;
    private bool released;
    private Vector3 releasePos;

    public static int totalScore = 0;

    void Awake() => grab = GetComponent<XRGrabInteractable>();

    void OnEnable() => grab.selectExited.AddListener(OnRelease);

    void OnDisable() => grab.selectExited.RemoveListener(OnRelease);

    void OnRelease(SelectExitEventArgs args)
    {
        released = true;
        releasePos = transform.position;
        Debug.Log($"Ball throw from {releasePos}");
    }

    void OnTriggerEnter(Collider other)
    {
        if (!released) return;

        var rend = other.GetComponent<Renderer>();
        if (rend == null) rend = other.GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            
            Color original = rend.material.color;
            rend.material.color = Color.green;
            StartCoroutine(ResetColorAfter(rend, original, 0.5f));
        }

        float dist = Vector3.Distance(releasePos, transform.position);

        int points = CalculatePoints(dist);

        totalScore += points;

        Debug.Log($"Distance: {dist}");

        released = false;
    }
    IEnumerator ResetColorAfter(Renderer rend, Color original, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (rend != null)
            rend.material.color = original;
    }

    int CalculatePoints(float dist)
    {
        if (dist < 2f) return 1;
        return 2;       
        
    }

    
}
