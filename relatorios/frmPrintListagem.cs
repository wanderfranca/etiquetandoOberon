using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EtiquetandoOberon.relatorios
{
    public partial class frmPrintListagem : Form
    {
        List<Receipt> _list;
        string _codigo, _descricao;

        public frmPrintListagem(List<Receipt> dataSource, string codigo, string descricao)
        {
            InitializeComponent();
            _list = dataSource;
            _codigo = codigo;
            _descricao = descricao;
        }

        private void frmPrintListagem_Load(object sender, EventArgs e)
        {
            ReceiptBindingSource.DataSource = _list;
            this.reportViewerListagem.RefreshReport();
        }
    }
}
