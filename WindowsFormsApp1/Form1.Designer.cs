namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIngresarRepuesto = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDesahbilitarRepuesto = new System.Windows.Forms.Button();
            this.btnModificarRepuesto = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIngresarRepuesto
            // 
            this.btnIngresarRepuesto.BackColor = System.Drawing.Color.White;
            this.btnIngresarRepuesto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnIngresarRepuesto.FlatAppearance.BorderSize = 10;
            this.btnIngresarRepuesto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarRepuesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarRepuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarRepuesto.Location = new System.Drawing.Point(504, 44);
            this.btnIngresarRepuesto.Name = "btnIngresarRepuesto";
            this.btnIngresarRepuesto.Size = new System.Drawing.Size(170, 60);
            this.btnIngresarRepuesto.TabIndex = 0;
            this.btnIngresarRepuesto.Text = "Ingresar Repuesto";
            this.btnIngresarRepuesto.UseVisualStyleBackColor = false;
            this.btnIngresarRepuesto.Click += new System.EventHandler(this.btnIngresarRepuesto_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(353, 233);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnDesahbilitarRepuesto
            // 
            this.btnDesahbilitarRepuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesahbilitarRepuesto.Location = new System.Drawing.Point(504, 119);
            this.btnDesahbilitarRepuesto.Name = "btnDesahbilitarRepuesto";
            this.btnDesahbilitarRepuesto.Size = new System.Drawing.Size(170, 60);
            this.btnDesahbilitarRepuesto.TabIndex = 2;
            this.btnDesahbilitarRepuesto.Text = "Deshabilitar Repuesto";
            this.btnDesahbilitarRepuesto.UseVisualStyleBackColor = true;
            this.btnDesahbilitarRepuesto.Click += new System.EventHandler(this.btnDesahbilitarRepuesto_Click);
            // 
            // btnModificarRepuesto
            // 
            this.btnModificarRepuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarRepuesto.Location = new System.Drawing.Point(504, 195);
            this.btnModificarRepuesto.Name = "btnModificarRepuesto";
            this.btnModificarRepuesto.Size = new System.Drawing.Size(170, 60);
            this.btnModificarRepuesto.TabIndex = 3;
            this.btnModificarRepuesto.Text = "Modificar Repuesto";
            this.btnModificarRepuesto.UseVisualStyleBackColor = true;
            this.btnModificarRepuesto.Click += new System.EventHandler(this.btnModificarRepuesto_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(504, 270);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 60);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnModificarRepuesto);
            this.Controls.Add(this.btnDesahbilitarRepuesto);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnIngresarRepuesto);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIngresarRepuesto;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDesahbilitarRepuesto;
        private System.Windows.Forms.Button btnModificarRepuesto;
        private System.Windows.Forms.Button button3;
    }
}

