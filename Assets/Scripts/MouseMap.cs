using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMap : MonoBehaviour
{

    public GameObject placeholder = null;
    public GameObject lastMarker = null;

    private void Start()
    {
        
    }

    /// <summary>
    /// creates a placeholder at the position on the terrain the mouse is
    /// </summary>
    private void RenderPlaceholder()
    {
        if (lastMarker)
        {
            Destroy(lastMarker);
        }

        GameObject ph = Instantiate(this.placeholder);
        ph.transform.position = TerrainToMousePosition();
        this.lastMarker = ph;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RenderPlaceholder();
        }
    }

    private void FixedUpdate()
    {
        transform.position = TerrainToMousePosition();

    }

    /// <summary>
    /// function for finding the mouse position in 3d space
    /// </summary>
    /// <returns> mouse position on the terrain </returns>
    private Vector3 TerrainToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            return hit.point;
        }

        return hit.point;
    }
}
