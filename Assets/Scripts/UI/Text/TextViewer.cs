using TMPro;
using UnityEngine;

public abstract class TextViewer : MonoBehaviour
{
    [SerializeField] protected TMP_Text Text;

    protected abstract void ChangeTextValue();
}