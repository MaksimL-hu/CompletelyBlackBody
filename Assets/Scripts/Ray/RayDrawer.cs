using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDrawer : MonoBehaviour
{
    [SerializeField] private float _drawingTime;
    [SerializeField] private PathBuilder _pathBuilder;
    [SerializeField] private Ray _prefab;
    [SerializeField] private float _startAlpha = 255f;
    [SerializeField] private float _extinctionInPercent = 10f;

    private List<Ray> _rays = new List<Ray>();
    private float _currentAlpha;

    private Coroutine _drawing;

    public float ExtinctionInPercent => _extinctionInPercent;
    public PathBuilder PathBuilder => _pathBuilder;

    private IEnumerator DrawRays()
    {
        for (int i = 0; i < _pathBuilder.PathPointCount; i++)
        {
            Vector3 start = _pathBuilder.GetPoint(i);
            Vector3 end = _pathBuilder.GetPoint(i + 1);
            float time = 0;

            Ray ray = Instantiate(_prefab, transform);
            ray.SetAlpha(_currentAlpha);
            _currentAlpha = _currentAlpha * ((Constants.OneHundredPercent - _extinctionInPercent) / Constants.OneHundredPercent);
            _rays.Add(ray);

            while (time < _drawingTime)
            {
                time += Time.deltaTime;
                ray.StretcherBetweenPoints.Stretch(start, Vector3.Lerp(start, end, time / _drawingTime));
                yield return null;
            }

            ray.StretcherBetweenPoints.Stretch(start, end);
        }
    }

    [ContextMenu("Draw Ray")]
    public void Draw()
    {
        for (int i = 0; i < _rays.Count; i++)
            Destroy(_rays[i].gameObject);

        _rays.Clear();

        if (_drawing != null)
            StopCoroutine(_drawing);

        _currentAlpha = _startAlpha;
        _drawing = StartCoroutine(DrawRays());
    }

    public void SetExtinctionInPercent(int value)
    {
        _extinctionInPercent = value;
    }

    public void SetDrawingTime(float value)
    {
        _drawingTime = value;
    }

    public float GetFinalExtinction()
    {
        float alpha = _startAlpha;

        for (int i = 0; i < _pathBuilder.PathPointCount - 1; i++)
        {
            alpha = alpha * ((Constants.OneHundredPercent - _extinctionInPercent) / Constants.OneHundredPercent);
        }

        return alpha;
    }
}