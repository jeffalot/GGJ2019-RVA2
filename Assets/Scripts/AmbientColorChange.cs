using UnityEngine;

public class AmbientColorChange : MonoBehaviour
{
    void  Start()
    {
        // Make the ambient lighting red
        RenderSettings.ambientLight = Color.red;
    }
}