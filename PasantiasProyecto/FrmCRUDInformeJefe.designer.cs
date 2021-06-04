namespace PasantiasProyecto
{
    partial class FrmCRUDInformeJefe
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstInformesJefe = new System.Windows.Forms.ListBox();
            this.lstSolicitud = new System.Windows.Forms.ListBox();
            this.btnEliminarInforme = new System.Windows.Forms.Button();
            this.btnEditarInforme = new System.Windows.Forms.Button();
            this.btnCrearInforme = new System.Windows.Forms.Button();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Informes Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Practicantes";
            // 
            // lstInformesJefe
            // 
            this.lstInformesJefe.FormattingEnabled = true;
            this.lstInformesJefe.ItemHeight = 16;
            this.lstInformesJefe.Location = new System.Drawing.Point(151, 269);
            this.lstInformesJefe.Name = "lstInformesJefe";
            this.lstInformesJefe.Size = new System.Drawing.Size(608, 132);
            this.lstInformesJefe.TabIndex = 15;
            // 
            // lstSolicitud
            // 
            this.lstSolicitud.FormattingEnabled = true;
            this.lstSolicitud.ItemHeight = 16;
            this.lstSolicitud.Location = new System.Drawing.Point(151, 74);
            this.lstSolicitud.Name = "lstSolicitud";
            this.lstSolicitud.Size = new System.Drawing.Size(608, 132);
            this.lstSolicitud.TabIndex = 14;
            // 
            // btnEliminarInforme
            // 
            this.btnEliminarInforme.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarInforme.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminarInforme.Location = new System.Drawing.Point(707, 458);
            this.btnEliminarInforme.Name = "btnEliminarInforme";
            this.btnEliminarInforme.Size = new System.Drawing.Size(95, 48);
            this.btnEliminarInforme.TabIndex = 13;
            this.btnEliminarInforme.Text = "Eliminar Informe";
            this.btnEliminarInforme.UseVisualStyleBackColor = false;
            this.btnEliminarInforme.Click += new System.EventHandler(this.btnEliminarInforme_Click);
            // 
            // btnEditarInforme
            // 
            this.btnEditarInforme.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEditarInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarInforme.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditarInforme.Location = new System.Drawing.Point(595, 458);
            this.btnEditarInforme.Name = "btnEditarInforme";
            this.btnEditarInforme.Size = new System.Drawing.Size(86, 48);
            this.btnEditarInforme.TabIndex = 12;
            this.btnEditarInforme.Text = "Editar Informe";
            this.btnEditarInforme.UseVisualStyleBackColor = false;
            this.btnEditarInforme.Click += new System.EventHandler(this.btnEditarInforme_Click);
            // 
            // btnCrearInforme
            // 
            this.btnCrearInforme.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCrearInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearInforme.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCrearInforme.Location = new System.Drawing.Point(481, 458);
            this.btnCrearInforme.Name = "btnCrearInforme";
            this.btnCrearInforme.Size = new System.Drawing.Size(88, 48);
            this.btnCrearInforme.TabIndex = 11;
            this.btnCrearInforme.Text = "Crear Informe";
            this.btnCrearInforme.UseVisualStyleBackColor = false;
            this.btnCrearInforme.Click += new System.EventHandler(this.btnCrearInforme_Click);
            // 
            // btnDetalles
            // 
            this.btnDetalles.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalles.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDetalles.Location = new System.Drawing.Point(363, 458);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(101, 48);
            this.btnDetalles.TabIndex = 10;
            this.btnDetalles.Text = "Detalles Informe";
            this.btnDetalles.UseVisualStyleBackColor = false;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
            // 
            // FrmCRUDInformeJefe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 579);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstInformesJefe);
            this.Controls.Add(this.lstSolicitud);
            this.Controls.Add(this.btnEliminarInforme);
            this.Controls.Add(this.btnEditarInforme);
            this.Controls.Add(this.btnCrearInforme);
            this.Controls.Add(this.btnDetalles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCRUDInformeJefe";
            this.Text = "FrmCRUDInformeJefe";
            this.Load += new System.EventHandler(this.FrmCRUDInformeJefe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstInformesJefe;
        private System.Windows.Forms.ListBox lstSolicitud;
        private System.Windows.Forms.Button btnEliminarInforme;
        private System.Windows.Forms.Button btnEditarInforme;
        private System.Windows.Forms.Button btnCrearInforme;
        private System.Windows.Forms.Button btnDetalles;
    }
}