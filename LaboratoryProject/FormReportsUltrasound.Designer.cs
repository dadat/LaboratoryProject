namespace LaboratoryProject
{
    partial class FormReportsUltrasound
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
            this.crViewerUltrasound = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crViewerUltrasound
            // 
            this.crViewerUltrasound.ActiveViewIndex = -1;
            this.crViewerUltrasound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewerUltrasound.CachedPageNumberPerDoc = 10;
            this.crViewerUltrasound.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewerUltrasound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewerUltrasound.Location = new System.Drawing.Point(0, 0);
            this.crViewerUltrasound.Name = "crViewerUltrasound";
            this.crViewerUltrasound.Size = new System.Drawing.Size(884, 816);
            this.crViewerUltrasound.TabIndex = 0;
            this.crViewerUltrasound.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormReportsUltrasound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 816);
            this.Controls.Add(this.crViewerUltrasound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormReportsUltrasound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultrasound Report";
            this.Load += new System.EventHandler(this.FormReportsUltrasound_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewerUltrasound;
    }
}