using EtiquetandoOberon.relatorios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace EtiquetandoOberon
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            


        }

        private void Home_Load(object sender, EventArgs e)
        {
            receiptBindingSource.DataSource = new List<Receipt>();
            
            txtCod.Focus();

            //Tira som do Windows ao dar Enter
            this.AcceptButton = this.btnAdd;

        }

        //Botão ADD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCod.Text) && !string.IsNullOrEmpty(txtDesc.Text))
            {
                Receipt obj = new Receipt()
                {
                    Descricao = txtDesc.Text,
                    Codigo = txtCod.Text
                };
                receiptBindingSource.Add(obj);
                receiptBindingSource.MoveLast();
                txtCod.Text = string.Empty;
                txtDesc.Text = string.Empty;
                txtCod.Focus();
            }

        }

        //Botão Deletar linha
        private void btnDel_Click(object sender, EventArgs e)
        {
            Receipt obj = receiptBindingSource.Current as Receipt;
            if (obj != null)
            {
                receiptBindingSource.RemoveCurrent();
            }
        }

        //Botão Imprimir
        public void btnPrint10x15_Click(object sender, EventArgs e)
        {
            if (rb10x15.Checked && dataGridView1.RowCount >=1)
                using (frmPrint frm = new frmPrint(receiptBindingSource.DataSource as List<Receipt>, string.Format(txtCod.Text), string.Format(txtDesc.Text)))
                {
                    frm.ShowDialog();
                }

            else if (rb3x6.Checked && dataGridView1.RowCount >= 1)
            {
                using (frmPrint3x6 frm = new frmPrint3x6(receiptBindingSource.DataSource as List<Receipt>, string.Format(txtCod.Text), string.Format(txtDesc.Text)))
                {
                    frm.ShowDialog();
                }
            }

            else if (rbA4.Checked && dataGridView1.RowCount >= 1)
            {
                using (frmPrintListagem frm = new frmPrintListagem(receiptBindingSource.DataSource as List<Receipt>, string.Format(txtCod.Text), string.Format(txtDesc.Text)))
                {
                    frm.ShowDialog();
                }
            }

            else
            {
                MessageBox.Show("Você não digitou nada");
                txtCod.Focus();
            }
        }

        //Botão Limpar
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true;

        }


        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {

                    xcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText; 
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)

                { 
                        
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            
                            }
                        }

                        xcelApp.Columns.AutoFit();
                        xcelApp.Visible = true;
                    
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog salvar = new SaveFileDialog(); // novo

            Excel.Application App; // Aplicação Excel
            Excel.Workbook WorkBook; // Pasta
            Excel.Worksheet WorkSheet; // Planilha
            object misValue = System.Reflection.Missing.Value;

            App = new Excel.Application();
            WorkBook = App.Workbooks.Add(misValue);
            WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;

            // passa as celulas do DataGridView para a Pasta do Excel
            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView1[j, i];
                    WorkSheet.Cells[i + 1, j + 1] = cell.Value;
                }
            }

            // define algumas propriedades da caixa salvar
            salvar.Title = "Exportar para Excel";
            salvar.Filter = "Arquivo do Excel *.xls | *.xls";
            salvar.ShowDialog(); // mostra

            // salva o arquivo
            WorkBook.SaveAs(salvar.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,

            Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            WorkBook.Close(true, misValue, misValue);
            App.Quit(); // encerra o excel

            MessageBox.Show("Exportado com sucesso!");
        }

        
    }
}

