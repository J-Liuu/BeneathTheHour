using UnityEngine;
using UnityEngine.EventSystems;

public class AmbitionText : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
