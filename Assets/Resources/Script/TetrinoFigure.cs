using UnityEngine;

/// <summary>
/// направление движения
/// </summary>
public enum DirectionTetrino { LEFT = -1, RIGHT = 1, DOWN}


public class TetrinoFigure : MonoBehaviour
{

    /// <summary>
    /// функция смещения фигуры вверх / вниз
    /// </summary>
    /// <param name="_isPositive"></param>
    public void DropTetrino(bool _isPositive)
    {
        if (_isPositive)
        {
            transform.Translate(0, -1, 0);
        }
        else { transform.Translate(0, 1, 0);}// откат перемещения
    }

    /// <summary>
    /// сдвиг фигуры в сторону
    /// </summary>
    /// <param name="_directionTetrino"></param>
    public void SetDirection(DirectionTetrino _directionTetrino)
    {
        transform.Translate((int) _directionTetrino, 0, 0);
    }

    /// <summary>
    /// возращение массива сегментов фигуры
    /// </summary>
    /// <returns></returns>
    public TetrinoSegment[] GetSegments()
    {
        return GetComponentsInChildren<TetrinoSegment>();
            
    }



}
