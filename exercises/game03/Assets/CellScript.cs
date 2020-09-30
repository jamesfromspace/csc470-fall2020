using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
	Renderer rend;
	public Color aliveColor;
	public Color deadColor;

	public int x = -1;
	public int y = -1;

	public bool nextAlive;
	private bool _alive = false;
    public bool Alive
    {
        get
        {
            return this._alive;
        }
        set
        {
            this._alive = value;
            
            if (this._alive) {
				rend.material.color = aliveColor;
				transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.5f,
					transform.localScale.z);
			} else {
				rend.material.color = deadColor;
				transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - transform.localScale.y,
					transform.localScale.z);
			}
		}
    }

    // Start is called before the first frame update
    void Start()
    {
		rend = gameObject.GetComponent<Renderer>();
		this.Alive = Random.value < 0.25f;
    }

    // Update is called once per frame
    void Update()
    {

	}
}
