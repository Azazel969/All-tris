using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{//                         11 | 13   18 | 21
    private const int wid = 13, hei = 21; // игровое поле
    private float step = 1; // шаг смещения фигуры

    private float currTime;

    /// <summary>
    /// ссылка на объект фигуры
    /// </summary>
    private GameObject prefabTetrino;

    /// <summary>
    /// ссылка на саму фигуру
    /// </summary>
    private Object prefabTetrinoObject;

    private TetrinoFigure figure;

    private TetrinoElement[,] arrayElement;

    /// <summary>
    /// скорость перемещения фигуры
    /// </summary>
    [SerializeField] private float speed = 0.5f;

    private void Start()
    {
        currTime = 0;
        arrayElement = new TetrinoElement[wid, hei];

        prefabTetrino = Resources.Load("Prefab/Tetrino_figure") as GameObject; // загрузка префаба фигуры в объект
        prefabTetrinoObject = Resources.Load("Prefab/prefab_Tetrino_O") as GameObject;

        for (int y = 0; y < hei; y++)
        {
            for (int x = 0; x < wid; x++)
            {
                GameObject gameOb = Instantiate(prefabTetrinoObject, new Vector3(x * step, y * step, 0), Quaternion.identity) as GameObject;

                arrayElement[x,y] = gameOb.GetComponent<TetrinoElement>();
            }
        }              

        CreateFigure(EnTetrinoFigure.O);
    }


    private void AddToArray()
    {
        GameObject[] gameOb = figure.GetComponentInChildren<TetrinoData>().GetTetrinoArray;
        for (int index = 0; index < gameOb.Length; index++)
        {
            int x = (int)gameOb[index].transform.position.x;
            int y = (int)gameOb[index].transform.position.y;

            arrayElement[x, y].set_tetrinoActive(true);

        }
    }

    private void RemoveFullLine()
    {
        int[] removeLine = CheckFullLine();

        for (int index = 0; index < removeLine.Length; index++)
        {
            for (int x = 0; x < wid; x++)
            {
                arrayElement[x, removeLine[index]].set_tetrinoActive(false);

            }
        }

        if (removeLine.Length != 0) 
        {
            int[] empty_Line = CheckEmptyLine();
            bool[,] arr_new_tetrino = new bool[wid,hei];

            int start_y = 0;

            for (int y = 0; y < hei; y++)
            {
                if (SkipLine(empty_Line, y))
                {
                    continue;
                }

                for (int x = 0; x < wid; x++)
                {
                    arr_new_tetrino[x, start_y] = arrayElement[x, y].get_isActive_tetrino();
                }

                start_y++;

            }

            SetNewTetrinoArr(arr_new_tetrino);
        }
    }

    private void SetNewTetrinoArr(bool [,] arr_new_tetrino)
    {
        for (int y = 0; y < hei; y++)
        {
            for (int x = 0; x < wid; x++)
            {
                arrayElement[x, y].set_tetrinoActive(arr_new_tetrino[x,y]);
            }
        }
    }

    private bool SkipLine(int[] _emptyLine, int _y)
    {
        for (int y = 0; y < _emptyLine.Length; y++)
        {
            if (_emptyLine[y] == _y)
            {
                return true;
            }
        }

        return false;
    }

    private int[] CheckEmptyLine()
    {
        List<int> arr = new();

        for (int index = 0; index < hei; index++)
        {
            int count_line_x = 0;

            for (int x = 0; x < wid; x++)
            {
                if (arrayElement[x, index].get_isActive_tetrino())
                {
                    break;
                }
                else
                {
                    count_line_x++;
                }
            }

            if (count_line_x == wid)
            {
                arr.Add(index);
            }
        }

        return arr.ToArray();
    }

    private int[] CheckFullLine()
    {
        List<int> arr = new();

        for (int index = 0; index < hei; index++)
        {
            int count_line_x = 0;

            for (int x = 0; x < wid; x++)
            {
                if (arrayElement[x, index].get_isActive_tetrino())
                {
                    count_line_x++;
                }
                else 
                { 
                    break; 
                }
            }

            if (count_line_x == wid)
            {
                arr.Add(index);
            }
        }

        return arr.ToArray();
    }
     
 

    private void Update()
    {
        if (figure)
        {
            if (Input.GetButtonDown("RotationTetrino"))
            {
                figure.GetComponentInChildren<TetrinoData>().Rotation(true);
                if (CheckIntersect(figure))
                {
                    figure.GetComponentInChildren<TetrinoData>().Rotation(false);
                }
            }

            if (Input.GetButtonDown("LeftTetrino"))
            {
                currTime = 0;
                figure.SetDirection(DirectionTetrino.LEFT);
                if (CheckIntersect(figure))
                {
                    figure.SetDirection(DirectionTetrino.RIGHT);
                }
            }
            else if (Input.GetButtonDown("RightTetrino"))
            {
                currTime = 0;
                figure.SetDirection(DirectionTetrino.RIGHT);
                if (CheckIntersect(figure))
                {
                    figure.SetDirection(DirectionTetrino.LEFT);
                }
            }

            if (Input.GetButton("DownTetrino"))
            {
                InputPres(DirectionTetrino.DOWN, 0.04f);
            }
            else if (Input.GetButton("RightTetrino"))
            {
                InputPres(DirectionTetrino.RIGHT, 0.05f);
            }
            if (Input.GetButton("LeftTetrino"))
            {
                InputPres(DirectionTetrino.LEFT, 0.05f);
            }
        }
    }

    private void InputPres(DirectionTetrino _directionTetrino, float _time)
    {
        currTime += Time.deltaTime;
        if (currTime > _time)
        {
            currTime = 0;
            if (_directionTetrino == DirectionTetrino.LEFT)
            {
                figure.SetDirection(DirectionTetrino.LEFT);
                if (CheckIntersect(figure))
                {
                    figure.SetDirection(DirectionTetrino.RIGHT);
                }
            }
            else if (_directionTetrino == DirectionTetrino.RIGHT)
            {
                figure.SetDirection(DirectionTetrino.RIGHT);
                if (CheckIntersect(figure))
                {
                    figure.SetDirection(DirectionTetrino.LEFT);
                }
            }
            else if (_directionTetrino == DirectionTetrino.DOWN)
            {
                figure.DropTetrino(true);
                if (CheckIntersect(figure))
                {
                    figure.DropTetrino(false);
                }
            }
        }
    }

    private bool CheckIntersect(TetrinoFigure _figure)
    {
        for (int index = 0; index < _figure.GetSegments().Length; index++)
        {
            int x = (int)_figure.GetSegments()[index].transform.position.x;
            int y = (int)_figure.GetSegments()[index].transform.position.y;

            bool isIntersect = IsIntersect(x, y);

            if (isIntersect)
            {
                return isIntersect;
            }
        }
        return false;
    }

    /// <summary>
    /// создание фигуры из префаба по переданному типу
    /// </summary>
    private void CreateFigure(EnTetrinoFigure _figure) 
    {
        figure = Instantiate(prefabTetrino, new Vector3(step * 5, step * (hei -2)), Quaternion.identity).GetComponent<TetrinoFigure>();// создание фигуры из префаба по координатам vector3

        figure.GetComponentInChildren<TetrinoData>().Initialize(_figure); // приведение формы фигуры к нужному типу

        StartCoroutine(update(speed));

    }

    private IEnumerator update(float _time)
    {
        while (true)
        {
            yield return new WaitForSeconds(_time);  
            figure.DropTetrino(true);

            if (CheckPreIntersect(figure))
            {
                break;
            }
        }

        AddToArray();
        Destroy(figure.gameObject);
        RemoveFullLine();
        CreateFigure(EnTetrinoFigure.Z);

    }


    private bool CheckPreIntersect(TetrinoFigure _figure)
    {
        for (int index = 0; index < _figure.GetSegments().Length; index++)
        {
            int x = (int)_figure.GetSegments()[index].transform.position.x;
            int y = (int)_figure.GetSegments()[index].transform.position.y;

            bool isIntersect = IsIntersect(x, y);

            if (isIntersect)
            {
                _figure.DropTetrino(false);
                return isIntersect;
            }
        }
        return false;
    }


    private bool IsIntersect(int _x, int _y)
    {
        try
        {
            if (arrayElement[_x, _y].get_isActive_tetrino())
            {
                return true;
            }
        }
        catch (System.Exception ex) 
        {
            return true; 
        }

        return false;
    }



}
