namespace Граф
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GrafGrid = new System.Windows.Forms.DataGridView();
            this.SelectActionLabel = new System.Windows.Forms.Label();
            this.SelectActionListBox = new System.Windows.Forms.ListBox();
            this.FindAmountSkeletonsButton = new System.Windows.Forms.Button();
            this.FindSkeletonMinWeightButton = new System.Windows.Forms.Button();
            this.AmountSkeletonsTextBox = new System.Windows.Forms.TextBox();
            this.AmountVerticesLabel = new System.Windows.Forms.Label();
            this.AmountVerticesTextBox = new System.Windows.Forms.TextBox();
            this.BuildMatrixButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrafGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // GrafGrid
            // 
            this.GrafGrid.AllowUserToAddRows = false;
            this.GrafGrid.AllowUserToDeleteRows = false;
            this.GrafGrid.AllowUserToResizeColumns = false;
            this.GrafGrid.AllowUserToResizeRows = false;
            this.GrafGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.GrafGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.GrafGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GrafGrid.GridColor = System.Drawing.SystemColors.Control;
            this.GrafGrid.Location = new System.Drawing.Point(285, 27);
            this.GrafGrid.Margin = new System.Windows.Forms.Padding(4);
            this.GrafGrid.Name = "GrafGrid";
            this.GrafGrid.RowHeadersWidth = 50;
            this.GrafGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GrafGrid.Size = new System.Drawing.Size(558, 515);
            this.GrafGrid.TabIndex = 7;
            this.GrafGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrafGrid_CellValueChanged);
            // 
            // SelectActionLabel
            // 
            this.SelectActionLabel.AutoSize = true;
            this.SelectActionLabel.Location = new System.Drawing.Point(12, 27);
            this.SelectActionLabel.Name = "SelectActionLabel";
            this.SelectActionLabel.Size = new System.Drawing.Size(225, 17);
            this.SelectActionLabel.TabIndex = 8;
            this.SelectActionLabel.Text = "Выберите дальнейшее действие";
            // 
            // SelectActionListBox
            // 
            this.SelectActionListBox.FormattingEnabled = true;
            this.SelectActionListBox.ItemHeight = 16;
            this.SelectActionListBox.Items.AddRange(new object[] {
            "Ввести контрольный пример",
            "Ввести произвольный граф"});
            this.SelectActionListBox.Location = new System.Drawing.Point(15, 61);
            this.SelectActionListBox.Name = "SelectActionListBox";
            this.SelectActionListBox.Size = new System.Drawing.Size(203, 36);
            this.SelectActionListBox.TabIndex = 9;
            this.SelectActionListBox.SelectedIndexChanged += new System.EventHandler(this.SelectActionListBox_SelectedIndexChanged);
            // 
            // FindAmountSkeletonsButton
            // 
            this.FindAmountSkeletonsButton.Location = new System.Drawing.Point(12, 282);
            this.FindAmountSkeletonsButton.Name = "FindAmountSkeletonsButton";
            this.FindAmountSkeletonsButton.Size = new System.Drawing.Size(205, 41);
            this.FindAmountSkeletonsButton.TabIndex = 10;
            this.FindAmountSkeletonsButton.Text = "Найти число остовов ";
            this.FindAmountSkeletonsButton.UseVisualStyleBackColor = true;
            this.FindAmountSkeletonsButton.Click += new System.EventHandler(this.FindAmountSkeletonsButton_Click);
            // 
            // FindSkeletonMinWeightButton
            // 
            this.FindSkeletonMinWeightButton.Location = new System.Drawing.Point(14, 440);
            this.FindSkeletonMinWeightButton.Name = "FindSkeletonMinWeightButton";
            this.FindSkeletonMinWeightButton.Size = new System.Drawing.Size(203, 48);
            this.FindSkeletonMinWeightButton.TabIndex = 11;
            this.FindSkeletonMinWeightButton.Text = "Найти остов наименьшего веса";
            this.FindSkeletonMinWeightButton.UseVisualStyleBackColor = true;
            this.FindSkeletonMinWeightButton.Click += new System.EventHandler(this.FindSkeletonMinWeightButton_Click);
            // 
            // AmountSkeletonsTextBox
            // 
            this.AmountSkeletonsTextBox.Location = new System.Drawing.Point(15, 350);
            this.AmountSkeletonsTextBox.Multiline = true;
            this.AmountSkeletonsTextBox.Name = "AmountSkeletonsTextBox";
            this.AmountSkeletonsTextBox.Size = new System.Drawing.Size(203, 71);
            this.AmountSkeletonsTextBox.TabIndex = 12;
            // 
            // AmountVerticesLabel
            // 
            this.AmountVerticesLabel.AutoSize = true;
            this.AmountVerticesLabel.Location = new System.Drawing.Point(12, 121);
            this.AmountVerticesLabel.Name = "AmountVerticesLabel";
            this.AmountVerticesLabel.Size = new System.Drawing.Size(197, 17);
            this.AmountVerticesLabel.TabIndex = 13;
            this.AmountVerticesLabel.Text = "Введите количество вершин";
            // 
            // AmountVerticesTextBox
            // 
            this.AmountVerticesTextBox.Location = new System.Drawing.Point(55, 153);
            this.AmountVerticesTextBox.Name = "AmountVerticesTextBox";
            this.AmountVerticesTextBox.Size = new System.Drawing.Size(100, 22);
            this.AmountVerticesTextBox.TabIndex = 15;
            // BuildMatrixButton
            // 
            this.BuildMatrixButton.Location = new System.Drawing.Point(12, 192);
            this.BuildMatrixButton.Margin = new System.Windows.Forms.Padding(4);
            this.BuildMatrixButton.Name = "BuildMatrixButton";
            this.BuildMatrixButton.Size = new System.Drawing.Size(205, 47);
            this.BuildMatrixButton.TabIndex = 16;
            this.BuildMatrixButton.Text = "Построить матрицу пропускных способностей";
            this.BuildMatrixButton.UseVisualStyleBackColor = true;
            this.BuildMatrixButton.Click += new System.EventHandler(this.BuildMatrixButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 554);
            this.Controls.Add(this.BuildMatrixButton);
            this.Controls.Add(this.AmountVerticesTextBox);
            this.Controls.Add(this.AmountVerticesLabel);
            this.Controls.Add(this.AmountSkeletonsTextBox);
            this.Controls.Add(this.FindSkeletonMinWeightButton);
            this.Controls.Add(this.FindAmountSkeletonsButton);
            this.Controls.Add(this.SelectActionListBox);
            this.Controls.Add(this.SelectActionLabel);
            this.Controls.Add(this.GrafGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrafGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GrafGrid;
        private System.Windows.Forms.Label SelectActionLabel;
        private System.Windows.Forms.ListBox SelectActionListBox;
        private System.Windows.Forms.Button FindAmountSkeletonsButton;
        private System.Windows.Forms.Button FindSkeletonMinWeightButton;
        private System.Windows.Forms.TextBox AmountSkeletonsTextBox;
        private System.Windows.Forms.Label AmountVerticesLabel;
        private System.Windows.Forms.TextBox AmountVerticesTextBox;
        private System.Windows.Forms.Button BuildMatrixButton;
    }
}

