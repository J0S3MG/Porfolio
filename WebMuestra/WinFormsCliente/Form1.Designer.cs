namespace WinFormsCliente
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgViews = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            LU = new DataGridViewTextBoxColumn();
            Nota = new DataGridViewTextBoxColumn();
            btnListar = new Button();
            btnBuscar = new Button();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnBorrar = new Button();
            tbxNota = new TextBox();
            tbxID = new TextBox();
            tbxNombre = new TextBox();
            tbxLU = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgViews).BeginInit();
            SuspendLayout();
            // 
            // dgViews
            // 
            dgViews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgViews.Columns.AddRange(new DataGridViewColumn[] { Id, Nombre, LU, Nota });
            dgViews.Location = new Point(12, 129);
            dgViews.Name = "dgViews";
            dgViews.RowHeadersWidth = 51;
            dgViews.Size = new Size(531, 299);
            dgViews.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // LU
            // 
            LU.HeaderText = "LU";
            LU.MinimumWidth = 6;
            LU.Name = "LU";
            LU.Width = 125;
            // 
            // Nota
            // 
            Nota.HeaderText = "Nota";
            Nota.MinimumWidth = 6;
            Nota.Name = "Nota";
            Nota.Width = 125;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(566, 129);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(168, 55);
            btnListar.TabIndex = 1;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(566, 190);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(168, 55);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar Alumno";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(566, 251);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(168, 55);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar Alumno";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(566, 312);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(168, 55);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar Alumno";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(566, 373);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(168, 55);
            btnBorrar.TabIndex = 5;
            btnBorrar.Text = "Borrar Alumno";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // tbxNota
            // 
            tbxNota.Location = new Point(353, 42);
            tbxNota.Name = "tbxNota";
            tbxNota.Size = new Size(190, 27);
            tbxNota.TabIndex = 6;
            // 
            // tbxID
            // 
            tbxID.Location = new Point(353, 82);
            tbxID.Name = "tbxID";
            tbxID.Size = new Size(190, 27);
            tbxID.TabIndex = 7;
            // 
            // tbxNombre
            // 
            tbxNombre.Location = new Point(85, 39);
            tbxNombre.Name = "tbxNombre";
            tbxNombre.Size = new Size(190, 27);
            tbxNombre.TabIndex = 8;
            // 
            // tbxLU
            // 
            tbxLU.Location = new Point(85, 79);
            tbxLU.Name = "tbxLU";
            tbxLU.Size = new Size(190, 27);
            tbxLU.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 10;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(311, 82);
            label2.Name = "label2";
            label2.Size = new Size(27, 20);
            label2.TabIndex = 11;
            label2.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(293, 42);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 12;
            label3.Text = "Nota:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 79);
            label4.Name = "label4";
            label4.Size = new Size(29, 20);
            label4.TabIndex = 13;
            label4.Text = "LU:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbxLU);
            Controls.Add(tbxNombre);
            Controls.Add(tbxID);
            Controls.Add(tbxNota);
            Controls.Add(btnBorrar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(btnBuscar);
            Controls.Add(btnListar);
            Controls.Add(dgViews);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgViews).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgViews;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn LU;
        private DataGridViewTextBoxColumn Nota;
        private Button btnListar;
        private Button btnBuscar;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnBorrar;
        private TextBox tbxNota;
        private TextBox tbxID;
        private TextBox tbxNombre;
        private TextBox tbxLU;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
