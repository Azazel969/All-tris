using UnityEngine;

public class TetrinoElement : MonoBehaviour
{
    private VisualTetrino visual;

    private void Awake()
    {
        visual = GetComponentInChildren<VisualTetrino>();
        visual.gameObject.SetActive(false);
    }

    public bool get_isActive_tetrino()
    {
        return visual.gameObject.activeSelf;
    }

    public void set_tetrinoActive(bool _active)
    {
        visual.gameObject.SetActive(_active);
    }

    public void set_color(Color _color)
    {
       visual.GetComponent<MeshRenderer>().material.color = _color;
    }



}
