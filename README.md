# How-to-expand-or-collapse-the-UWP-TreeGrid-SfTreeGrid-by-clicking-any-cell-in-the-row
How to expand or collapse the UWP TreeGrid (SfTreeGrid) by clicking any cell in the row

In [UWP TreeGrid](https://www.syncfusion.com/uwp-ui-controls/treegrid){target="_blank"}, the tree nodes are expanded or collapsed only by clicking the expander icon. With the customization below, nodes can be expanded or collapsed by clicking any cell in the row. This is achieved by overriding the [ProcessOnTapped](https://help.syncfusion.com/cr/uwp/Syncfusion.UI.Xaml.TreeGrid.TreeGridRowSelectionController.html#Syncfusion_UI_Xaml_TreeGrid_TreeGridRowSelectionController_ProcessOnTapped_Windows_UI_Xaml_Input_TappedRoutedEventArgs_Syncfusion_UI_Xaml_ScrollAxis_RowColumnIndex_){target="_blank"} method in the [TreeGridRowSelectionController](https://help.syncfusion.com/cr/uwp/Syncfusion.UI.Xaml.TreeGrid.TreeGridRowSelectionController.html){target="_blank"} class as shown below,

**C#**
 ```C#
treeGrid.SelectionController = new TreeGridSelectionControllerExt(treeGrid);

public class TreeGridSelectionControllerExt : TreeGridRowSelectionController

{

    public TreeGridSelectionControllerExt(SfTreeGrid treeGrid) : base(treeGrid)

    {

    }

 

    protected override void ProcessOnTapped(TappedRoutedEventArgs e, RowColumnIndex currentRowColumnIndex)

    {

        if (currentRowColumnIndex.RowIndex &lt;= this.TreeGrid.GetHeaderIndex())

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

​I hope you enjoyed learning on How to expand or collapse the UWP TreeGrid (SfTreeGrid) by clicking any cell in the row. You can refer to our [UWP TreeGrid](https://www.syncfusion.com/uwp-ui-controls/treegrid){target="_blank"} Control feature tour page to know about its other groundbreaking feature representations and [documentation](https://help.syncfusion.com/uwp/treegrid/getting-started){target="_blank"}, and how to quickly get started for configuration specifications. For current customers, you can check out our components from the [License and Downloads](https://www.syncfusion.com/sales/teamlicense){target="_blank"} page. If you are new to Syncfusion, you can try our [30-day free](https://www.syncfusion.com/account/manage-trials/downloads){target="_blank"} trial to check out our other controls.

If you have any queries or require clarifications, please let us know in the comments section below. You can also contact us through our [support forums](https://www.syncfusion.com/forums){target="_blank"}, [Direct-Trac](https://support.syncfusion.com/create){target="_blank"}, or [feedback portal](https://www.syncfusion.com/feedback/uwp?control=sftreegrid){target="_blank"}. We are always happy to assist you!
