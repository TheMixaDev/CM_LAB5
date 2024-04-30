namespace Lab2.UI
{
    partial class InputForm
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
            this.graph = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.loadButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.inputGrid = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.functionBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.intervalStartBox = new System.Windows.Forms.TextBox();
            this.intervalEndBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dotsBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.outputGrid = new System.Windows.Forms.DataGridView();
            this.targetBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // graph
            // 
            this.graph.AllowExternalDrop = true;
            this.graph.CreationProperties = null;
            this.graph.DefaultBackgroundColor = System.Drawing.Color.White;
            this.graph.Location = new System.Drawing.Point(335, 11);
            this.graph.Margin = new System.Windows.Forms.Padding(2);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(364, 281);
            this.graph.TabIndex = 16;
            this.graph.ZoomFactor = 1D;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(2, 272);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(163, 20);
            this.loadButton.TabIndex = 36;
            this.loadButton.Text = "Загрузить";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Enabled = false;
            this.calculateButton.Location = new System.Drawing.Point(171, 272);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(163, 20);
            this.calculateButton.TabIndex = 37;
            this.calculateButton.Text = "Вычислить";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // inputGrid
            // 
            this.inputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.inputGrid.Location = new System.Drawing.Point(2, 11);
            this.inputGrid.Name = "inputGrid";
            this.inputGrid.RowHeadersWidth = 51;
            this.inputGrid.Size = new System.Drawing.Size(163, 255);
            this.inputGrid.TabIndex = 38;
            this.inputGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.inputGrid_CellEndEdit);
            this.inputGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.inputGrid_CellValueChanged);
            this.inputGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.inputGrid_RowsAdded);
            this.inputGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.inputGrid_RowsRemoved);
            this.inputGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.inputGrid_UserAddedRow);
            this.inputGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.inputGrid_UserDeletedRow);
            // 
            // X
            // 
            this.X.Frozen = true;
            this.X.HeaderText = "X";
            this.X.MinimumWidth = 6;
            this.X.Name = "X";
            this.X.Width = 50;
            // 
            // Y
            // 
            this.Y.Frozen = true;
            this.Y.HeaderText = "Y";
            this.Y.MinimumWidth = 6;
            this.Y.Name = "Y";
            this.Y.Width = 50;
            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(474, 294);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(225, 172);
            this.resultLabel.TabIndex = 40;
            this.resultLabel.Text = "Результат:\r\nВычисления не проводились\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Из функции:";
            // 
            // functionBox
            // 
            this.functionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functionBox.FormattingEnabled = true;
            this.functionBox.Items.AddRange(new object[] {
            "sin(x)",
            "cox(x)+x"});
            this.functionBox.Location = new System.Drawing.Point(171, 28);
            this.functionBox.Name = "functionBox";
            this.functionBox.Size = new System.Drawing.Size(154, 21);
            this.functionBox.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Интервал:";
            // 
            // intervalStartBox
            // 
            this.intervalStartBox.Location = new System.Drawing.Point(171, 68);
            this.intervalStartBox.Name = "intervalStartBox";
            this.intervalStartBox.Size = new System.Drawing.Size(67, 20);
            this.intervalStartBox.TabIndex = 44;
            this.intervalStartBox.Text = "0";
            // 
            // intervalEndBox
            // 
            this.intervalEndBox.Location = new System.Drawing.Point(258, 68);
            this.intervalEndBox.Name = "intervalEndBox";
            this.intervalEndBox.Size = new System.Drawing.Size(67, 20);
            this.intervalEndBox.TabIndex = 45;
            this.intervalEndBox.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Количество точек:";
            // 
            // dotsBox
            // 
            this.dotsBox.Location = new System.Drawing.Point(171, 107);
            this.dotsBox.Name = "dotsBox";
            this.dotsBox.Size = new System.Drawing.Size(154, 20);
            this.dotsBox.TabIndex = 47;
            this.dotsBox.Text = "6";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(167, 133);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(163, 20);
            this.generateButton.TabIndex = 48;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Целевое X:";
            // 
            // outputGrid
            // 
            this.outputGrid.AllowUserToAddRows = false;
            this.outputGrid.AllowUserToDeleteRows = false;
            this.outputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputGrid.Location = new System.Drawing.Point(2, 294);
            this.outputGrid.Name = "outputGrid";
            this.outputGrid.ReadOnly = true;
            this.outputGrid.RowHeadersWidth = 51;
            this.outputGrid.Size = new System.Drawing.Size(466, 172);
            this.outputGrid.TabIndex = 50;
            // 
            // targetBox
            // 
            this.targetBox.Location = new System.Drawing.Point(171, 247);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(163, 20);
            this.targetBox.TabIndex = 51;
            this.targetBox.Text = "0,5";
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 475);
            this.Controls.Add(this.targetBox);
            this.Controls.Add(this.outputGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.dotsBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.intervalEndBox);
            this.Controls.Add(this.intervalStartBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.functionBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.inputGrid);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.graph);
            this.Name = "InputForm";
            this.Text = "Лабораторная работа №5";
            this.Load += new System.EventHandler(this.InputForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 graph;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.DataGridView inputGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox functionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox intervalStartBox;
        private System.Windows.Forms.TextBox intervalEndBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dotsBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView outputGrid;
        private System.Windows.Forms.TextBox targetBox;
    }
}