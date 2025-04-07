using UnityEngine;

/// <summary>
/// ����������� ��������
/// </summary>
public enum DirectionTetrino { LEFT = -1, RIGHT = 1, DOWN}


public class TetrinoFigure : MonoBehaviour
{

    /// <summary>
    /// ������� �������� ������ ����� / ����
    /// </summary>
    /// <param name="_isPositive"></param>
    public void DropTetrino(bool _isPositive)
    {
        if (_isPositive)
        {
            transform.Translate(0, -1, 0);
        }
        else { transform.Translate(0, 1, 0);}// ����� �����������
    }

    /// <summary>
    /// ����� ������ � �������
    /// </summary>
    /// <param name="_directionTetrino"></param>
    public void SetDirection(DirectionTetrino _directionTetrino)
    {
        transform.Translate((int) _directionTetrino, 0, 0);
    }

    /// <summary>
    /// ���������� ������� ��������� ������
    /// </summary>
    /// <returns></returns>
    public TetrinoSegment[] GetSegments()
    {
        return GetComponentsInChildren<TetrinoSegment>();
            
    }



}
