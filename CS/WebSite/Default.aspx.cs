using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;
using DevExpress.Web.Data;
using System.Drawing;
using DevExpress.Xpo;

public partial class _Default : System.Web.UI.Page {
    Session session = XpoHelper.GetNewSession();

    protected void Page_Init(object sender, EventArgs e) {
        xds.Session = session;
    }

    protected void grid_RowUpdating(object sender, ASPxDataUpdatingEventArgs e) {
        e.NewValues["DxColor"] = GetColor(); 
    }
    protected void grid_RowInserting(object sender, ASPxDataInsertingEventArgs e) {
        e.NewValues["DxColor"] = GetColor(); 
    }

    private object GetColor() {
        GridViewDataTextColumn col = grid.Columns["DxColor"] as GridViewDataTextColumn;
        ASPxColorEdit colorEdit = grid.FindEditRowCellTemplateControl(col, "colorEdit") as ASPxColorEdit;
        Color color = colorEdit.Color;
        return color.ToArgb().ToString();
    }
    protected void grid_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e) {
        if (e.DataColumn.FieldName != "DxColor") return;
        e.Cell.Text = string.Empty;
        try {
            if (e.CellValue is DBNull)
                e.Cell.BackColor = Color.Black;
            else
                e.Cell.BackColor = Color.FromArgb(Convert.ToInt32(e.CellValue));
        } catch (Exception) {
            e.Cell.BackColor = Color.Red;
        }
    }
    protected Color GetColor(object container) {
        try {
            Color color = Color.FromArgb(Convert.ToInt32(container));
            return color;
        } catch (Exception) {
            return Color.Red;
        }
    }
    
}
