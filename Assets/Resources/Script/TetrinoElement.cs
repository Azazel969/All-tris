using UnityEngine;

public class TetrinoElement : MonoBehaviour
{
    private VisualTetrino visual;

    private void Awake()
    {
        visual = GetComponentInChildren<VisualTetrino>();
        visual.gameObject.SetActive(false); // отключение отображения сегмента
    }

    /// <summary>
    /// мониторинг виден сегмент или нет
    /// </summary>
    /// <returns></returns>
    public bool get_isActive_tetrino()
    {
        return visual.gameObject.activeSelf;
    }

    /// <summary>
    /// включение или отключение отображения сегмента
    /// </summary>
    /// <param name="_active"></param>
    public void set_tetrinoActive(bool _active)
    {
        visual.gameObject.SetActive(_active);
    }

    /// <summary>
    /// задание цвета
    /// </summary>
    /// <param name="_color"></param>
    public void set_color(Color _color)
    {
       visual.GetComponent<MeshRenderer>().material.color = _color;
    }



}
