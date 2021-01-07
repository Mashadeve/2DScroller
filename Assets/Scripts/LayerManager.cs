using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [SerializeField]
    public Transform worldStart, worldEnd;
    [SerializeField]
    private MoveableLayer[] layers;
    public static LayerManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
            
    }

    public void MoveLayers(Vector3 movement)
    {
        foreach (MoveableLayer obj in layers)
        {
            float x = movement.x * obj.xSpeed - obj.autoScrollXSpeed * Time.deltaTime;
            float y = movement.x * obj.ySpeed - obj.autoScrollYSpeed * Time.deltaTime;
            obj.layer.position += new Vector3(x, y, 0f);
        }
    }
}



[System.Serializable]
public class MoveableLayer
{
    public Transform layer;
    public float xSpeed;
    public float ySpeed;
    public float autoScrollXSpeed;
    public float autoScrollYSpeed;
    [HideInInspector]
    public Transform[] children;
}