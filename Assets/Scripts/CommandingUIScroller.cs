using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandingUIScroller : MonoBehaviour
{

    int counter = 0;

    public DUCKTYPES commandingDuck = DUCKTYPES.ALL;

    public Sprite [] DuckSprites;
    public int commandingIndex = 0;

    private bool duckMoveLock = true;
    public RectTransform rt = null;

    Vector2 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        rt = this.gameObject.GetComponent<RectTransform>();
        originalPosition = rt.position;
    }

    private void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.Tab))
        {
                if (!(counter >= 3))
                {
                    counter++;
                    SetCommandingDuck(counter);
                }
                else
                {
                    counter = -1;
                    counter++;
                    SetCommandingDuck(counter);
                }
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (!(counter <= 0))
            {
                counter--;
                SetCommandingDuck(counter);
            }
            else
            {
                counter = 4;
                counter--;
                SetCommandingDuck(counter);
            }
        }
    }

    private IEnumerator ScrollDucks()
    {
        yield return new WaitForSeconds(1f);
        duckMoveLock = true;
    }

    private void SetCommandingDuck(int counter)
    {
        switch (counter)
        {
            case 0:
                this.commandingDuck = DUCKTYPES.ARCHER;
                break;
            case 1:
                this.commandingDuck = DUCKTYPES.ARTILLERY;
                break;
            case 2:
                this.commandingDuck = DUCKTYPES.MAGE;
                break;
            case 3:
                this.commandingDuck = DUCKTYPES.ALL;
                break;
            default:
                this.commandingDuck = DUCKTYPES.ALL;
                this.counter = 0;
                break;
        }
        //Debug.Log(this.commandingDuck);

        this.commandingIndex = (int)this.commandingDuck;
        this.gameObject.GetComponentInChildren<Image>().sprite = this.DuckSprites[this.commandingIndex];
                
    }
}
