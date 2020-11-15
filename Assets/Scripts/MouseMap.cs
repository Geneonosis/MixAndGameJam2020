using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMap : MonoBehaviour
{

    public GameObject placeholder = null;

    private GameObject[] markers;
    public GameObject lastMarker = null;

    public Material [] ringTypes;
    public Material[] arrowTypes;

    public int ringIndex;


    private void Start()
    {
        this.markers = new GameObject[4];
    }

    /// <summary>
    /// creates a placeholder at the position on the terrain the mouse is
    /// </summary>
    private void RenderPlaceholder()
    {
        this.ringIndex = GameObject.FindGameObjectWithTag("CommandingScroll").GetComponent<CommandingUIScroller>().commandingIndex;
        if (this.markers[this.ringIndex] && this.ringIndex != 3)
        {
            Destroy(this.markers[this.ringIndex]);
            this.markers[this.ringIndex] = null;
        }else if(this.ringIndex == 3)
        {
            foreach(GameObject marker in this.markers)
            {
                Destroy(marker);
            }
        }

        GameObject ph = Instantiate(this.placeholder);
        ph.GetComponent<Projector>().material = this.ringTypes[this.ringIndex];
        ph.gameObject.GetComponentInChildren<MeshRenderer>().material = this.arrowTypes[this.ringIndex];
        ph.transform.position = TerrainToMousePosition();
        if (this.enemyObjectTransform)
        {
            ph.transform.parent = this.enemyObjectTransform;
            ph.transform.localPosition = Vector3.zero;
            ph.gameObject.GetComponentInChildren<Transform>().localPosition = Vector3.up;
        }
        this.markers[this.ringIndex] = ph;
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
        UpdatePointerType();

    }

    private void UpdatePointerType()
    {
        //this.ringIndex = GameObject.FindGameObjectWithTag("CommandingScroll").GetComponent<CommandingUIScroller>().commandingIndex;
        //this.gameObject.GetComponent<Projector>().material = this.ringTypes[this.ringIndex];

    }

    public Transform enemyObjectTransform;

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
            this.enemyObjectTransform = null;
            if(hit.transform.tag == "Enemy")
            {
                this.enemyObjectTransform = hit.transform;
            }
            return hit.point;
        }

        return hit.point;
    }
}
