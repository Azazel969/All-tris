using UnityEngine;

public enum DirectionTetrino { LEFT = -1, RIGHT = 1, DOWN}


public class TetrinoFigure : MonoBehaviour
{


    public void DropTetrino(bool _isPositive) // ������� �������� ������ ����� / ����
    {
        if (_isPositive)
        {
            transform.Translate(0, -1, 0);
        }
        else { transform.Translate(0, 1, 0);}// ����� �����������
    }

    public void SetDirection(DirectionTetrino _directionTetrino)
    {
        transform.Translate((int) _directionTetrino, 0, 0);
    }

    public TetrinoSegment[] GetSegments()
    {
        return GetComponentsInChildren<TetrinoSegment>();
            
    }



}
