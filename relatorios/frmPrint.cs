using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtiquetandoOberon
{
    public partial class frmPrint : Form

    {
        List<Receipt> _list;
        string _codigo, _descricao;

        public frmPrint(List<Receipt> dataSource, string codigo, string descricao)
        {
            InitializeComponent();
            _list = dataSource;
            _codigo = codigo;
            _descricao = descricao;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            ReceiptBindingSource.DataSource = _list;

            this.reportViewer.RefreshReport();
        }
    }
}
