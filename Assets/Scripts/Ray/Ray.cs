using System;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(StretcherBetweenPoints))]
[RequireComponent(typeof(SpriteRenderer))]
public class Ray : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private StretcherBetweenPoints _stretcherBetweenPoints;

    public StretcherBetweenPoints StretcherBetweenPoints => _stretcherBetweenPoints;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _stretcherBetweenPoints = GetComponent<StretcherBetweenPoints>();
    }

    public void SetAlpha(float alpha)
    {
        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, alpha / Constants.ColorAlpha);
    }
}