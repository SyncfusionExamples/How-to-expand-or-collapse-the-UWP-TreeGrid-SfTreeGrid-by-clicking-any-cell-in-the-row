using Syncfusion.UI.Xaml.ScrollAxis;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ExpandCollapse
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            treeGrid.SelectionController = new TreeGridSelectionControllerExt(treeGrid);
        }
    }
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
}
