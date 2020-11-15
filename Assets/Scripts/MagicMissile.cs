using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    public float speed = 1.0f;
    public float curve = 2.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = Vector3.zero;
        if (Target != null)
            dir = (this.transform.position - Target.transform.position).normalized;
        else
            dir = transform.forward;
        this.transform.Translate(dir * Time.fixedDeltaTime * speed);
    }
}
