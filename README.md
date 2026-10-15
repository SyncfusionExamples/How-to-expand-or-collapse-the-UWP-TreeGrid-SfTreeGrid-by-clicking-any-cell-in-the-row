# How to expand or collapse the UWP Tree Grid by clicking any cell in the row

This sample demonstrates how to expand or collapse nodes in the [UWP TreeGrid](https://www.syncfusion.com/uwp-ui-controls/treegrid) by clicking any cell in the row instead of using only the expander icon.

By default, tree nodes in the UWP Tree Grid expand or collapse only when the expander icon is clicked. With the customization below, the node state is toggled whenever the user taps any cell in the row (except header rows).

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

## Output

![msedge_0zhJ6Zr8IV.gif](https://support.syncfusion.com/kb/agent/attachment/article/14201/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9...)

## Sample description

This sample shows how to customize the `SfTreeGrid` so the parent node expands or collapses when any cell in the row is tapped, rather than requiring a click on the expander icon. This is useful for improving usability in dense tree views where users expect row-level interaction to trigger node state changes.

## Project structure

A typical UWP sample project for this scenario may include the following structure:

- `README.md` – setup and usage notes
- `Sample.sln` or other Visual Studio solution file
- one or more UWP project folders containing the app code
- `Assets/` – sample images or icons
- `MainPage.xaml` / `MainPage.xaml.cs` – UI and logic for the sample

Note: The exact folder names may vary depending on the repository layout.

## Prerequisites

Before running this sample, ensure the following are available:

- Windows 10 or later
- Visual Studio 2019 or 2022 with the "Universal Windows Platform development" workload installed
- Windows 10 SDK matching your project target version
- Syncfusion UWP TreeGrid package references in the project
- A valid Syncfusion license or trial for the required package version

## Supported / tested versions

- Visual Studio: 2019 / 2022
- Windows SDK: based on project target platform version
- Syncfusion UWP TreeGrid: use the package version referenced in the project file

If the project does not build, confirm that the package version and target platform match your installed SDK and Visual Studio setup.

## How to run the sample

1. Download or clone this repository.
2. Open the solution file in Visual Studio.
3. Restore NuGet packages.
4. Set the UWP project as the startup project.
5. Build the solution.
6. Run the application on a local machine or emulator.

## Code explanation

- `treeGrid.SelectionController = new TreeGridSelectionControllerExt(treeGrid);`
  - Replaces the default selection controller with a custom one.

- `TreeGridSelectionControllerExt : TreeGridRowSelectionController`
  - Extends the default row selection logic to handle row taps.

- `ProcessOnTapped(TappedRoutedEventArgs e, RowColumnIndex currentRowColumnIndex)`
  - Ignores header rows using `GetHeaderIndex()`.
  - Gets the tree node for the tapped row using `GetNodeAtRowIndex()`.
  - Calls `ExpandNode(node)` or `CollapseNode(node)` based on the node state.
  - Calls `base.ProcessOnTapped(...)` to preserve the default behavior.

## Notes

- This customization triggers expand/collapse only for data rows, not the header.
- If you have other interactive controls inside a cell, you may need additional checks to prevent the row-tap action from firing when those controls are used.
- Verify the project target platform and package version if build errors appear.

## Conclusion

This sample shows how to customize the UWP Tree Grid so that users can expand or collapse a node by clicking any cell in the row. This provides a more intuitive and user-friendly interaction model.

If you have any queries or require clarifications, please let us know in the comments section below. You can also contact us through our [support forums](https://www.syncfusion.com/forums).
