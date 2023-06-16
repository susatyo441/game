using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ScrollContent : MonoBehaviour
{
    #region Public Properties

    /// <summary>
    /// How far apart each item is in the scroll view.
    /// </summary>
    public float ItemSpacing { get { return itemSpacing; } }

    /// <summary>
    /// How much the items are indented from left and right of the scroll view.
    /// </summary>
    public float HorizontalMargin { get { return horizontalMargin; } }

    /// <summary>
    /// How much the items are indented from top and bottom of the scroll view.
    /// </summary>
    public float VerticalMargin { get { return verticalMargin; } }

    /// <summary>
    /// Is the scroll view oriented horizontally?
    /// </summary>
    public bool Horizontal { get { return horizontal; } }

    /// <summary>
    /// Is the scroll view oriented vertically?
    /// </summary>
    public bool Vertical { get { return vertical; } }

    /// <summary>
    /// The width of the scroll content.
    /// </summary>
    public float Width { get { return width; } }

    /// <summary>
    /// The height of the scroll content.
    /// </summary>
    public float Height { get { return height; } }

    /// <summary>
    /// The width for each child of the scroll view.
    /// </summary>
    public float ChildWidth { get { return childWidth; } }

    /// <summary>
    /// The height for each child of the scroll view.
    /// </summary>
    public float ChildHeight { get { return childHeight; } }

    #endregion

    #region Private Members

    /// <summary>
    /// The RectTransform component of the scroll content.
    /// </summary>
    private RectTransform rectTransform, scrollPanel, selectedRect;

    /// <summary>
    /// The RectTransform components of all the children of this GameObject.
    /// </summary>
    private RectTransform[] rtChildren;

    /// <summary>
    /// The width and height of the parent.
    /// </summary>
    private float width, height;

    /// <summary>
    /// The width and height of the children GameObjects.
    /// </summary>
    private float childWidth, childHeight;

    /// <summary>
    /// How far apart each item is in the scroll view.
    /// </summary>
    [SerializeField]
    private float itemSpacing;

    /// <summary>
    /// How much the items are indented from the top/bottom and left/right of the scroll view.
    /// </summary>
    [SerializeField]
    private float horizontalMargin, verticalMargin;

    /// <summary>
    /// Is the scroll view oriented horizontall or vertically?
    /// </summary>
    [SerializeField]
    private bool horizontal, vertical;
    private GameObject lastSelected;
    #endregion

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //scrollPanel = GetComponent<ScrollRect>().content;

        rtChildren = new RectTransform[rectTransform.childCount];

        for (int i = 0; i < rectTransform.childCount; i++)
        {
            rtChildren[i] = rectTransform.GetChild(i) as RectTransform;
        }

        // Subtract the margin from both sides.
        width = rectTransform.rect.width - (2 * horizontalMargin);

        // Subtract the margin from the top and bottom.
        height = rectTransform.rect.height - (2 * verticalMargin);

        childWidth = rtChildren[0].rect.width;
        childHeight = rtChildren[0].rect.height;

        horizontal = !vertical;
        if (vertical)
            InitializeContentVertical();
        else
            InitializeContentHorizontal();
    }

    private void Update()
    {
        //GameObject selected = EventSystem.current.currentSelectedGameObject;
        //Debug.Log("Selected : " + selected.name);
        //if(selected == null)
        //{
        //    return;
        //}
        //if(selected.transform.parent != scrollPanel.transform)
        //{
        //    return;
        //}
        //if(selected == lastSelected)
        //{
        //    return;
        //}

        //selectedRect = selected.GetComponent<RectTransform>();
        //float selectedPosy = Mathf.Abs(selectedRect.anchoredPosition.y) + selectedRect.rect.height;
        //float viwMinY = scrollPanel.anchoredPosition.y;
        //float viewMaxY = scrollPanel.anchoredPosition.y + rectTransform.rect.height;

        //if(selectedPosy > viwMinY)
        //{
        //    float newy = selectedPosy - rectTransform.rect.height;
        //    scrollPanel.anchoredPosition = new Vector2(scrollPanel.anchoredPosition.x, newy);
        //}
        //else if(Mathf.Abs(selectedRect.anchoredPosition.y) < viwMinY)
        //{
        //    scrollPanel.anchoredPosition = new Vector2(scrollPanel.anchoredPosition.x, Mathf.Abs(selectedRect.anchoredPosition.y));

        //}
        //lastSelected = selected;
      
    }

    /// <summary>
    /// Initializes the scroll content if the scroll view is oriented horizontally.
    /// </summary>
    private void InitializeContentHorizontal()
    {
        float originX = 0 - (width * 0.5f);
        float posOffset = childWidth * 0.5f;
        for (int i = 0; i < rtChildren.Length; i++)
        {
            Vector2 childPos = rtChildren[i].localPosition;
            childPos.x = originX + posOffset + i * (childWidth + itemSpacing);
            rtChildren[i].localPosition = childPos;
        }
    }

    
    /// Initializes the scroll content if the scroll view is oriented vertically.
  
    private void InitializeContentVertical()
    {
        float originY = 0 - (height * 0.5f);
        float posOffset = childHeight * 0.5f;
        int i = 0;
        
        for (i = 0; i < rtChildren.Length; i++)
        {
            Vector2 childPos = rtChildren[i].localPosition;
            childPos.y = originY + posOffset + i * (childHeight + itemSpacing);
            rtChildren[i].localPosition = childPos;
        }
    }
}
