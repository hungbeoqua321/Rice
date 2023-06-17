using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class Staff_Delivery : Form
    {
        public Staff_Delivery()
        {
            InitializeComponent();
        }

        private void doncg_Click(object sender, EventArgs e)
        {
            table.Visible = true;
            string[] row1 = new string[] { "01", "Cơm đậu sốt Tứ Xuyên", "Nguyễn Văn A, 175 Tây Sơn Đống Đa Hà Nội, 0984124786", "40000" };
            table.Rows.Add(row1);
            string[] row2 = new string[] { "02", "Cơm rang trứng", "Trần Thị B, 65 Khương Thượng Đống Đa Hà Nội, 0904174706", "40000" };
            table.Rows.Add(row2);
            string[] row3 = new string[] { "03", "Cơm cà ri, Cơm đùi gà chiên", "Lê Văn C, 75  Tôn Thất Tùng Đống Đa Hà Nội, 0984124786", "80000" };
            table.Rows.Add(row3);
        }
    }
}
