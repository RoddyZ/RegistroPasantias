namespace PasantiasProyecto
{
    partial class FrmCRUDInformeMitad
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
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnCrearInforme = new System.Windows.Forms.Button();
            this.btnEditarInforme = new System.Windows.Forms.Button();
            this.btnEliminarInforme = new System.Windows.Forms.Button();
            this.lstSolicitud = new System.Windows.Forms.ListBox();
            this.lstInformeMitad = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDetalles
            // 
            this.btnDetalles.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalles.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDetalles.Location = new System.Drawing.Point(328, 450);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(101, 48);
            this.btnDetalles.TabIndex = 2;
            this.btnDetalles.Text = "Detalles Informe";
            this.btnDetalles.UseVisualStyleBackColor = false;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
            // 
            // btnCrearInforme
            // 
            this.btnCrearInforme.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCrearInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearInforme.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCrearInforme.Location = new System.Drawing.Point(446, 450);
            this.btnCrearInforme.Name = "btnCrearInforme";
            this.btnCrearInforme.Size = new System.Drawing.Size(88, 48);
            this.btnCrearInforme.TabIndex = 3;
            this.btnCrearInforme.Text = "Crear Informe";
            this.btnCrearInforme.UseVisualStyleBackColor = false;
            this.btnCrearInforme.Click += new System.EventHandler(this.btnCrearInforme_Click);
            // 
            // btnEditarInforme
            // 
            this.btnEditarInforme.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEditarInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarInforme.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditarInforme.Location = new System.Drawing.Point(560, 450);
            this.btnEditarInforme.Name = "btnEditarInforme";
            this.btnEditarInforme.Size = new System.Drawing.Size(86, 48);
            this.btnEditarInforme.TabIndex = 4;
            this.btnEditarInforme.Text = "Editar Informe";
            this.btnEditarInforme.UseVisualStyleBackColor = false;
            this.btnEditarInforme.Click += new System.EventHandler(this.btnEditarInforme_Click);
            // 
            // btnEliminarInforme
            // 
            this.btnEliminarInforme.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarInforme.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminarInforme.Location = new System.Drawing.Point(672, 450);
            this.btnEliminarInforme.Name = "btnEliminarInforme";
            this.btnEliminarInforme.Size = new System.Drawing.Size(95, 48);
            this.btnEliminarInforme.TabIndex = 5;
            this.btnEliminarInforme.Text = "Eliminar Informe";
            this.btnEliminarInforme.UseVisualStyleBackColor = false;
            this.btnEliminarInforme.Click += new System.EventHandler(this.btnEliminarInforme_Click);
            // 
            // lstSolicitud
            // 
            this.lstSolicitud.FormattingEnabled = true;
            this.lstSolicitud.ItemHeight = 16;
            this.lstSolicitud.Location = new System.Drawing.Point(116, 66);
            this.lstSolicitud.Name = "lstSolicitud";
            this.lstSolicitud.Size = new System.Drawing.Size(608, 132);
            this.lstSolicitud.TabIndex = 6;
            // 
            // lstInformeMitad
            // 
            this.lstInformeMitad.FormattingEnabled = true;
            this.lstInformeMitad.ItemHeight = 16;
            this.lstInformeMitad.Location = new System.Drawing.Point(116, 261);
            this.lstInformeMitad.Name = "lstInformeMitad";
            this.lstInformeMitad.Size = new System.Drawing.Size(608, 132);
            this.lstInformeMitad.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Practicantes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Informes Mitad Semestre";
            // 
            // FrmCRUDInformeMitad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 531);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstInformeMitad);
            this.Controls.Add(this.lstSolicitud);
            this.Controls.Add(this.btnEliminarInforme);
            this.Controls.Add(this.btnEditarInforme);
            this.Controls.Add(this.btnCrearInforme);
            this.Controls.Add(this.btnDetalles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCRUDInformeMitad";
            this.Text = "FrmCRUDInformeMitad";
            this.Load += new System.EventHandler(this.FrmCRUDInformeMitad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.Button btnCrearInforme;
        private System.Windows.Forms.Button btnEditarInforme;
        private System.Windows.Forms.Button btnEliminarInforme;
        private System.Windows.Forms.ListBox lstSolicitud;
        private System.Windows.Forms.ListBox lstInformeMitad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}