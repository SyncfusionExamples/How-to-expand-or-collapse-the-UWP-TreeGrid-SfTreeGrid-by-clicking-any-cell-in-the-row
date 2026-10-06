# How to expand or collapse the UWP Tree Grid by clicking any cell in the row

This sample demonstrates how to expand or collapse nodes in the [UWP TreeGrid](https://www.syncfusion.com/uwp-ui-controls/treegrid) by clicking any cell in the row instead of using only the expander icon.

By default, tree nodes in the UWP Tree Grid expand or collapse only when the expander icon is clicked. With the customization below, the node state is toggled whenever the user taps any cell in the row.

## C#

```csharp
treeGrid.SelectionController = new TreeGridSelectionControllerExt(treeGrid);

public class TreeGridSelectionControllerExt : TreeGridRowSelectionController
{
    public TreeGridSelectionControllerExt(SfTreeGrid treeGrid) : base(treeGrid)
    {
    }

    protected override void ProcessOnTapped(TappedRoutedEventArgs e, RowColumnIndex currentRowColumnIndex)
    {
        if (currentRowColumnIndex.RowIndex <= this.TreeGrid.GetHeaderIndex())
            return;

        var node = TreeGrid.GetNodeAtRowIndex(currentRowColumnIndex.RowIndex);

        if (node != null)
        {
            if (node.IsExpanded)
                TreeGrid.CollapseNode(node);
            else if (!node.IsExpanded)
                TreeGrid.ExpandNode(node);
        }

        base.ProcessOnTapped(e, currentRowColumnIndex);
    }
}
```

**Output**
  
 ![msedge_0zhJ6Zr8IV.gif](https://support.syncfusion.com/kb/agent/attachment/article/14201/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI1Mjc0Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.48fvyOp5F191x2uNjMlklJM6Tj0K2u7AtPiSS_p1AJE)

**Conclusion**

This sample shows how to customize the UWP Tree Grid so that users can expand or collapse a node by clicking any cell in the row. This provides a more intuitive and user-friendly interaction model.

If you have any queries or require clarifications, please let us know in the comments section below. You can also contact us through our [support forums](https://www.syncfusion.com/forums).
