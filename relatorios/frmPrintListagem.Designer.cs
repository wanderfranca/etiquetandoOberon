namespace EtiquetandoOberon.relatorios
{
    partial class frmPrintListagem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReceiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewerListagem = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReceiptBindingSource
            // 
            this.ReceiptBindingSource.DataSource = typeof(EtiquetandoOberon.Receipt);
            // 
            // reportViewerListagem
            // 
            this.reportViewerListagem.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ds";
            reportDataSource1.Value = this.ReceiptBindingSource;
            this.reportViewerListagem.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerListagem.LocalReport.ReportEmbeddedResource = "EtiquetandoOberon.report.rptReceiptListagem .rdlc";
            this.reportViewerListagem.Location = new System.Drawing.Point(0, 0);
            this.reportViewerListagem.Name = "reportViewerListagem";
            this.reportViewerListagem.ServerReport.BearerToken = null;
            this.reportViewerListagem.Size = new System.Drawing.Size(1008, 729);
            this.reportViewerListagem.TabIndex = 0;
            // 
            // frmPrintListagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.reportViewerListagem);
            this.Name = "frmPrintListagem";
            this.Text = "frmPrintListagem";
            this.Load += new System.EventHandler(this.frmPrintListagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerListagem;
        private System.Windows.Forms.BindingSource ReceiptBindingSource;
    }
}