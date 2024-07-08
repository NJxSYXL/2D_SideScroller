using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    [SerializeField] private Transform firstPoint, secondPoint;
    [SerializeField, Range(0f, 100f)] private float speed;
    [SerializeField, Range(0f, 1f)] private float startingPoint;
    [SerializeField] private bool startInReverse;

    private bool isTurningBackwards = false;
    private float sawProgress = 0f;
    private Vector3 sawPosition;

    // Start is called before the first frame update
    void Start()
    {
        sawProgress = startingPoint;
        isTurningBackwards = startInReverse;
    }

    // Update is called once per frame
    void Update()
    {
        float sawFacing = isTurningBackwards ? -1f : 1f;

        sawProgress += (speed * 0.01f) * sawFacing * Time.deltaTime;

        if (sawProgress >= 1f) isTurningBackwards = true;
        else if (sawProgress <= 0f) isTurningBackwards = false;

        SetSawPosition(sawProgress);
    }

    private void SetSawPosition(float progress)
    {
        sawPosition.x = Mathf.Lerp(firstPoint.position.x, secondPoint.position.x, sawProgress);
        sawPosition.y = Mathf.Lerp(firstPoint.position.y, secondPoint.position.y, sawProgress);
        sawPosition.z = Mathf.Lerp(firstPoint.position.z, secondPoint.position.z, sawProgress);

        transform.position = sawPosition;
    }
}
