
using UnityEngine;
[CreateAssetMenu(fileName = "data", menuName = "Data/level")]
public class stageData : ScriptableObject
{
    [SerializeField]
    private Vector2 limitMin;
    [SerializeField] 
    private Vector2 limitMax;   

    public Vector2 LimitMin => limitMin;
    public Vector2 LimitMax => limitMax;
    // Start is called before the first frame update
   
   
}
