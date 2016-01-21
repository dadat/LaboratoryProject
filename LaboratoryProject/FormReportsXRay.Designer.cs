namespace LaboratoryProject
{
    partial class FormReportsXRay
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
            this.crViewerXRay = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crXRay1 = new LaboratoryProject.crXRay();
            this.SuspendLayout();
            // 
            // crViewerXRay
            // 
            this.crViewerXRay.ActiveViewIndex = 0;
            this.crViewerXRay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewerXRay.CachedPageNumberPerDoc = 10;
            this.crViewerXRay.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewerXRay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewerXRay.Location = new System.Drawing.Point(0, 0);
            this.crViewerXRay.Name = "crViewerXRay";
            this.crViewerXRay.ReportSource = this.crXRay1;
            this.crViewerXRay.Size = new System.Drawing.Size(884, 816);
            this.crViewerXRay.TabIndex = 0;
            this.crViewerXRay.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormReportsXRay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 816);
            this.Controls.Add(this.crViewerXRay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormReportsXRay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XRay Report";
            this.Load += new System.EventHandler(this.FormReportsXRay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewerXRay;
        private crXRay crXRay1;
    }
}