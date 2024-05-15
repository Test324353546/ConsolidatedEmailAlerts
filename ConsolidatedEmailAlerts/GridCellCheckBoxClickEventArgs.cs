using Syncfusion.WinForms.DataGrid;

namespace ConsolidatedEmailAlerts
{
    internal class GridCellCheckBoxClickEventArgs
    {
        public GridCheckBoxColumn Column { get; internal set; }
        public object Record { get; internal set; }
    }
}