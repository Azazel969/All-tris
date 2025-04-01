using UnityEngine;


public enum EnTetrinoFigure { L, Z, I, O, T } // виды фигур


public class TetrinoData : MonoBehaviour
{
    /// <summary>
    /// префаб куба дл€ формировани€ фигуры
    /// </summary>
    private GameObject prefabCube;

    /// <summary>
    /// массив кубов из которых формируетс€ фигура
    /// </summary>
    private GameObject[] tetrinoArray;

    /// <summary>
    /// поворот фигуры на данный момент
    /// </summary>
    private int rotation;
    
    /// <summary>
    /// текущий тип фигуры
    /// </summary>
    private EnTetrinoFigure type;
    
    /// <summary>
    /// инициализаци€ фигуры
    /// </summary>
    public void Initialize(EnTetrinoFigure _type)
    {
        for (int index = 0; index < transform.childCount; index++) // удаление старых значений при смене типа фигуры
        {
            Destroy(transform.GetChild(index).gameObject);
        }

        switch (_type) // указание позиции куба в фигуре
        {
            case EnTetrinoFigure.L:
                
                type = _type;
                GameObject obL_1 = Instantiate(prefabCube, SetCubePos_5(), Quaternion.identity);
                obL_1.AddComponent<TetrinoSegment>();
                obL_1.transform.SetParent(transform, false);

                GameObject obL_2 = Instantiate(prefabCube, SetCubePos_8(), Quaternion.identity);
                obL_2.AddComponent<TetrinoSegment>();
                obL_2.transform.SetParent(transform, false);

                GameObject obL_3 = Instantiate(prefabCube,SetCubePos_2(), Quaternion.identity);
                obL_3.AddComponent<TetrinoSegment>();
                obL_3.transform.SetParent(transform, false);

                GameObject obL_4 = Instantiate(prefabCube, SetCubePos_3(), Quaternion.identity);
                obL_4.AddComponent<TetrinoSegment>();
                obL_4.transform.SetParent(transform, false);

                for (int index = 0; index < tetrinoArray.Length; index++)
                {
                    tetrinoArray[index] = transform.GetChild(index).gameObject;
                }
                
                break;
            case EnTetrinoFigure.Z:

                type = _type;
                GameObject obZ_1 = Instantiate(prefabCube, SetCubePos_5(), Quaternion.identity);
                obZ_1.AddComponent<TetrinoSegment>();
                obZ_1.transform.SetParent(transform, false);

                GameObject obZ_2 = Instantiate(prefabCube, SetCubePos_8(), Quaternion.identity);
                obZ_2.AddComponent<TetrinoSegment>();
                obZ_2.transform.SetParent(transform, false);

                GameObject obZ_3 = Instantiate(prefabCube, SetCubePos_7(), Quaternion.identity);
                obZ_3.AddComponent<TetrinoSegment>();
                obZ_3.transform.SetParent(transform, false);

                GameObject obZ_4 = Instantiate(prefabCube, SetCubePos_6(), Quaternion.identity);
                obZ_4.AddComponent<TetrinoSegment>();
                obZ_4.transform.SetParent(transform, false);

                for (int index = 0; index < tetrinoArray.Length; index++)
                {
                    tetrinoArray[index] = transform.GetChild(index).gameObject;
                }

                break;
            case EnTetrinoFigure.I:

                type = _type; // определение типа фигуры
                GameObject obI_1 = Instantiate(prefabCube, SetCubePos_5(), Quaternion.identity); // создание объекта из перефаба по координатам SetCube
                obI_1.AddComponent<TetrinoSegment>(); // добавление компонента дл€ контрол€ заполнени€ пол€
                obI_1.transform.SetParent(transform, false); // установка родител€ (объект фигуры)

                GameObject obI_2 = Instantiate(prefabCube, SetCubePos_2(), Quaternion.identity);
                obI_2.AddComponent<TetrinoSegment>();
                obI_2.transform.SetParent(transform, false);

                GameObject obI_3 = Instantiate(prefabCube, SetCubePos_8(), Quaternion.identity);
                obI_3.AddComponent<TetrinoSegment>();
                obI_3.transform.SetParent(transform, false);

                GameObject obI_4 = Instantiate(prefabCube, SetCubeExtensivePos_8(), Quaternion.identity);
                obI_4.AddComponent<TetrinoSegment>();
                obI_4.transform.SetParent(transform, false);

                for (int index = 0; index < tetrinoArray.Length; index++) // заполнение массива фигуры 
                {
                    tetrinoArray[index] = transform.GetChild(index).gameObject;
                }

                break;
            case EnTetrinoFigure.O:

                type = _type;
                GameObject obO_1 = Instantiate(prefabCube, SetCubePos_5(), Quaternion.identity);
                obO_1.AddComponent<TetrinoSegment>();
                obO_1.transform.SetParent(transform, false);

                GameObject obO_2 = Instantiate(prefabCube, SetCubePos_4(), Quaternion.identity);
                obO_2.AddComponent<TetrinoSegment>();
                obO_2.transform.SetParent(transform, false);

                GameObject obO_3 = Instantiate(prefabCube, SetCubePos_1(), Quaternion.identity);
                obO_3.AddComponent<TetrinoSegment>();
                obO_3.transform.SetParent(transform, false);

                GameObject obO_4 = Instantiate(prefabCube, SetCubePos_2(), Quaternion.identity);
                obO_4.AddComponent<TetrinoSegment>();
                obO_4.transform.SetParent(transform, false);

                for (int index = 0; index < tetrinoArray.Length; index++)
                {
                    tetrinoArray[index] = transform.GetChild(index).gameObject;
                }

                break;
            case EnTetrinoFigure.T:

                type = _type;
                GameObject obT_1 = Instantiate(prefabCube, SetCubePos_5(), Quaternion.identity);
                obT_1.AddComponent<TetrinoSegment>();
                obT_1.transform.SetParent(transform, false);

                GameObject obT_2 = Instantiate(prefabCube, SetCubePos_6(), Quaternion.identity);
                obT_2.AddComponent<TetrinoSegment>();
                obT_2.transform.SetParent(transform, false);

                GameObject obT_3 = Instantiate(prefabCube, SetCubePos_4(), Quaternion.identity);
                obT_3.AddComponent<TetrinoSegment>();
                obT_3.transform.SetParent(transform, false);

                GameObject obT_4 = Instantiate(prefabCube, SetCubePos_8(), Quaternion.identity);
                obT_4.AddComponent<TetrinoSegment>();
                obT_4.transform.SetParent(transform, false);

                for (int index = 0; index < tetrinoArray.Length; index++)
                {
                    tetrinoArray[index] = transform.GetChild(index).gameObject;
                }
                break;

                default:
                break;
        }   
    }

    private void Awake()
    {
        rotation = 0;

        tetrinoArray = new GameObject[4];

        prefabCube = Resources.Load("Prefab/prefab_Cube") as GameObject; // загрузка префаба куба в объект
    }

    public GameObject[] GetTetrinoArray { get { return tetrinoArray; } }

    public void Rotation(bool _isPositive) 
    {
        if (_isPositive)
        {
            rotation++;
            rotation = rotation % 4;
        }
        else 
        { 
            rotation--;
            if (rotation < 0)
            {
                rotation = 3;
            }
        }

        RotationType(type, rotation);
    }

    //private Vector3 SetCube(int _position)
    //{
    //    Vector3 pos;

    //    switch (_position)
    //    {
    //        case 1:  
    //            pos = new Vector3(-1, -1, 0);
    //            return pos;
    //            break;
    //        case 2:
    //            pos = new Vector3(0, -1, 0);
    //            return pos;
    //            break;
    //        case 3:
    //            pos = new Vector3(1, -1, 0);
    //            return pos;
    //            break;
    //        default:
    //            break;
    //    }



    //}

    private Vector3 SetCubePos_1()
    {
        Vector3 pos = new Vector3(-1, -1, 0);
        return pos;
    }
    private Vector3 SetCubePos_2()
    {
        Vector3 pos = new Vector3(0, -1, 0);
        return pos;
    }
    private Vector3 SetCubeExtensivePos_2()
    {
        Vector3 pos = new Vector3(0, -2, 0);
        return pos;
    }
    private Vector3 SetCubePos_3()
    {
        Vector3 pos = new Vector3(1, -1, 0);
        return pos;
    }
    private Vector3 SetCubePos_4()
    {
        Vector3 pos = new Vector3(-1, 0, 0);
        return pos;
    }
    private Vector3 SetCubeExtensivePos_4()
    {
        Vector3 pos = new Vector3(-2, 0, 0);
        return pos;
    }
    private Vector3 SetCubePos_5()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        return pos;
    }
    private Vector3 SetCubePos_6()
    {
        Vector3 pos = new Vector3(1, 0, 0);
        return pos;
    }
    private Vector3 SetCubeExtensivePos_6()
    {
        Vector3 pos = new Vector3(2, 0, 0);
        return pos;
    }
    private Vector3 SetCubePos_7()
    {
        Vector3 pos = new Vector3(-1, 1, 0);
        return pos;
    }
    private Vector3 SetCubePos_8()
    {
        Vector3 pos = new Vector3(0, 1, 0);
        return pos;
    }
    private Vector3 SetCubeExtensivePos_8()
    {
        Vector3 pos = new Vector3(0, 2, 0);
        return pos;
    }
    private Vector3 SetCubePos_9()
    {
        Vector3 pos = new Vector3(1, 1, 0);
        return pos;
    }

    private void RotationType(EnTetrinoFigure _figure , int _rot)
    {
        switch (_figure)
        {
            case EnTetrinoFigure.L:

                switch (_rot)
                {
                    case 0:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_8();
                        tetrinoArray[2].transform.localPosition = SetCubePos_2();
                        tetrinoArray[3].transform.localPosition = SetCubePos_3();                   
                        break;
                    case 1:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_4();
                        tetrinoArray[2].transform.localPosition = SetCubePos_6();
                        tetrinoArray[3].transform.localPosition = SetCubePos_9();
                        break;
                    case 2:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_2();
                        tetrinoArray[2].transform.localPosition = SetCubePos_8();
                        tetrinoArray[3].transform.localPosition = SetCubePos_7();
                        break;
                    case 3:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_6();
                        tetrinoArray[2].transform.localPosition = SetCubePos_4();
                        tetrinoArray[3].transform.localPosition = SetCubePos_1();
                        break;
                    default:
                        break;
                }

                break;
            case EnTetrinoFigure.Z:
                switch (_rot)
                {
                    case 0:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_6();
                        tetrinoArray[2].transform.localPosition = SetCubePos_8();
                        tetrinoArray[3].transform.localPosition = SetCubePos_7();
                        break;
                    case 1:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_8();
                        tetrinoArray[2].transform.localPosition = SetCubePos_4();
                        tetrinoArray[3].transform.localPosition = SetCubePos_1();
                        break;
                    case 2:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_4();
                        tetrinoArray[2].transform.localPosition = SetCubePos_2();
                        tetrinoArray[3].transform.localPosition = SetCubePos_3();
                        break;
                    case 3:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_2();
                        tetrinoArray[2].transform.localPosition = SetCubePos_6();
                        tetrinoArray[3].transform.localPosition = SetCubePos_9();
                        break;
                    default:
                        break;
                }

                break;
            case EnTetrinoFigure.I:
                switch (_rot)
                {
                    case 0:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_2();
                        tetrinoArray[2].transform.localPosition = SetCubePos_8();
                        tetrinoArray[3].transform.localPosition = SetCubeExtensivePos_8();
                        break;
                    case 1:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_6();
                        tetrinoArray[2].transform.localPosition = SetCubePos_4();
                        tetrinoArray[3].transform.localPosition = SetCubeExtensivePos_4();
                        break;
                    case 2:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_8();
                        tetrinoArray[2].transform.localPosition = SetCubePos_2();
                        tetrinoArray[3].transform.localPosition = SetCubeExtensivePos_2();
                        break;
                    case 3:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_4();
                        tetrinoArray[2].transform.localPosition = SetCubePos_6();
                        tetrinoArray[3].transform.localPosition = SetCubeExtensivePos_6();
                        break;
                    default:
                        break;
                }

                break;
            case EnTetrinoFigure.O:
                switch (_rot)
                {
                    //case 0:
                    //    TetrinoArray[0].transform.localPosition = SetCubePos_5();
                    //    TetrinoArray[1].transform.localPosition = new Vector3(0, 1, 0);
                    //    TetrinoArray[2].transform.localPosition = new Vector3(0, -1, 0);
                    //    TetrinoArray[3].transform.localPosition = new Vector3(1, -1, 0);
                    //    break;
                    //case 1:
                    //    TetrinoArray[0].transform.localPosition = SetCubePos_5();
                    //    TetrinoArray[1].transform.localPosition = new Vector3(1, 1, 0);
                    //    TetrinoArray[2].transform.localPosition = new Vector3(-1, 0, 0);
                    //    TetrinoArray[3].transform.localPosition = new Vector3(1, 1, 0);
                    //    break;
                    //case 2:
                    //    TetrinoArray[0].transform.localPosition = SetCubePos_5();
                    //    TetrinoArray[1].transform.localPosition = new Vector3(0, 1, 0);
                    //    TetrinoArray[2].transform.localPosition = new Vector3(-1, 1, 0);
                    //    TetrinoArray[3].transform.localPosition = new Vector3(0, -1, 0);
                    //    break;
                    //case 3:
                    //    TetrinoArray[0].transform.localPosition = SetCubePos_5();
                    //    TetrinoArray[1].transform.localPosition = new Vector3(1, 0, 0);
                    //    TetrinoArray[2].transform.localPosition = new Vector3(-1, 0, 0);
                    //    TetrinoArray[3].transform.localPosition = new Vector3(-1, -1, 0);
                    //    break;
                    default:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_2();
                        tetrinoArray[2].transform.localPosition = SetCubePos_1();
                        tetrinoArray[3].transform.localPosition = SetCubePos_4();
                        break;
                }

                break;
            case EnTetrinoFigure.T:
                switch (_rot)
                {
                    case 0:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_4();
                        tetrinoArray[2].transform.localPosition = SetCubePos_8();
                        tetrinoArray[3].transform.localPosition = SetCubePos_6();
                        break;
                    case 1:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_2();
                        tetrinoArray[2].transform.localPosition = SetCubePos_4();
                        tetrinoArray[3].transform.localPosition = SetCubePos_8();
                        break;
                    case 2:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_4();
                        tetrinoArray[2].transform.localPosition = SetCubePos_2();
                        tetrinoArray[3].transform.localPosition = SetCubePos_6();
                        break;
                    case 3:
                        tetrinoArray[0].transform.localPosition = SetCubePos_5();
                        tetrinoArray[1].transform.localPosition = SetCubePos_2();
                        tetrinoArray[2].transform.localPosition = SetCubePos_6();
                        tetrinoArray[3].transform.localPosition = SetCubePos_8();
                        break;
                    default:
                        break;
                }

                break;
            default:
                break;
        }




       
    }


}