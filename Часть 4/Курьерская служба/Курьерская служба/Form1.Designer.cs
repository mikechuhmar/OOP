namespace Курьерская_служба
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
            this.timeBrLabel = new System.Windows.Forms.Label();
            this.amCourLabel = new System.Windows.Forms.Label();
            this.amCourCBox = new System.Windows.Forms.ComboBox();
            this.amBrLabel = new System.Windows.Forms.Label();
            this.amBrCBox = new System.Windows.Forms.ComboBox();
            this.timeBrGrid = new System.Windows.Forms.DataGridView();
            this.LettersGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.stepLabel = new System.Windows.Forms.Label();
            this.stepCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentDayTB = new System.Windows.Forms.TextBox();
            this.crL = new System.Windows.Forms.Label();
            this.crGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.timeBrGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LettersGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // timeBrLabel
            // 
            this.timeBrLabel.AutoSize = true;
            this.timeBrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeBrLabel.Location = new System.Drawing.Point(6, 194);
            this.timeBrLabel.Name = "timeBrLabel";
            this.timeBrLabel.Size = new System.Drawing.Size(309, 40);
            this.timeBrLabel.TabIndex = 16;
            this.timeBrLabel.Text = "Введите продолжительность пути \r\n              между филиалами ";
            // 
            // amCourLabel
            // 
            this.amCourLabel.AutoSize = true;
            this.amCourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.amCourLabel.Location = new System.Drawing.Point(3, 21);
            this.amCourLabel.Name = "amCourLabel";
            this.amCourLabel.Size = new System.Drawing.Size(278, 20);
            this.amCourLabel.TabIndex = 15;
            this.amCourLabel.Text = "Выберите количество курьеров";
            // 
            // amCourCBox
            // 
            this.amCourCBox.AutoCompleteCustomSource.AddRange(new string[] {
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.amCourCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.amCourCBox.FormattingEnabled = true;
            this.amCourCBox.Location = new System.Drawing.Point(112, 77);
            this.amCourCBox.Name = "amCourCBox";
            this.amCourCBox.Size = new System.Drawing.Size(121, 28);
            this.amCourCBox.TabIndex = 14;
            // 
            // amBrLabel
            // 
            this.amBrLabel.AutoSize = true;
            this.amBrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.amBrLabel.Location = new System.Drawing.Point(3, 113);
            this.amBrLabel.Name = "amBrLabel";
            this.amBrLabel.Size = new System.Drawing.Size(287, 20);
            this.amBrLabel.TabIndex = 12;
            this.amBrLabel.Text = "Выберите количество филиалов";
            // 
            // amBrCBox
            // 
            this.amBrCBox.AutoCompleteCustomSource.AddRange(new string[] {
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.amBrCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.amBrCBox.FormattingEnabled = true;
            this.amBrCBox.Location = new System.Drawing.Point(112, 158);
            this.amBrCBox.Name = "amBrCBox";
            this.amBrCBox.Size = new System.Drawing.Size(121, 28);
            this.amBrCBox.TabIndex = 11;
            this.amBrCBox.SelectedIndexChanged += new System.EventHandler(this.amBrCBox_SelectedIndexChanged);
            // 
            // timeBrGrid
            // 
            this.timeBrGrid.AllowUserToAddRows = false;
            this.timeBrGrid.Location = new System.Drawing.Point(7, 251);
            this.timeBrGrid.Name = "timeBrGrid";
            this.timeBrGrid.Size = new System.Drawing.Size(240, 150);
            this.timeBrGrid.TabIndex = 13;
            this.timeBrGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.timeBrGrid_CellValueChanged);
            this.timeBrGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.timeBrGrid_KeyPress);
            // 
            // LettersGrid
            // 
            this.LettersGrid.AllowUserToAddRows = false;
            this.LettersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LettersGrid.Location = new System.Drawing.Point(420, 142);
            this.LettersGrid.Name = "LettersGrid";
            this.LettersGrid.Size = new System.Drawing.Size(240, 175);
            this.LettersGrid.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(429, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "Начать моделирования";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stepLabel
            // 
            this.stepLabel.AutoSize = true;
            this.stepLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepLabel.Location = new System.Drawing.Point(416, 21);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(269, 20);
            this.stepLabel.TabIndex = 21;
            this.stepLabel.Text = "Выберите шаг моделирования";
            // 
            // stepCB
            // 
            this.stepCB.AutoCompleteCustomSource.AddRange(new string[] {
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.stepCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepCB.FormattingEnabled = true;
            this.stepCB.Location = new System.Drawing.Point(480, 66);
            this.stepCB.Name = "stepCB";
            this.stepCB.Size = new System.Drawing.Size(121, 28);
            this.stepCB.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(793, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Текущий день";
            // 
            // currentDayTB
            // 
            this.currentDayTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentDayTB.Location = new System.Drawing.Point(797, 66);
            this.currentDayTB.Name = "currentDayTB";
            this.currentDayTB.Size = new System.Drawing.Size(100, 27);
            this.currentDayTB.TabIndex = 23;
            // 
            // crL
            // 
            this.crL.AutoSize = true;
            this.crL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crL.Location = new System.Drawing.Point(447, 404);
            this.crL.Name = "crL";
            this.crL.Size = new System.Drawing.Size(213, 20);
            this.crL.TabIndex = 24;
            this.crL.Text = "Информация о курьерах";
            // 
            // crGrid
            // 
            this.crGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crGrid.Location = new System.Drawing.Point(480, 443);
            this.crGrid.Name = "crGrid";
            this.crGrid.RowTemplate.Height = 24;
            this.crGrid.Size = new System.Drawing.Size(240, 150);
            this.crGrid.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 756);
            this.Controls.Add(this.crGrid);
            this.Controls.Add(this.crL);
            this.Controls.Add(this.currentDayTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stepLabel);
            this.Controls.Add(this.stepCB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LettersGrid);
            this.Controls.Add(this.timeBrLabel);
            this.Controls.Add(this.amCourLabel);
            this.Controls.Add(this.amCourCBox);
            this.Controls.Add(this.amBrLabel);
            this.Controls.Add(this.amBrCBox);
            this.Controls.Add(this.timeBrGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timeBrGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LettersGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeBrLabel;
        private System.Windows.Forms.Label amCourLabel;
        private System.Windows.Forms.ComboBox amCourCBox;
        private System.Windows.Forms.Label amBrLabel;
        private System.Windows.Forms.ComboBox amBrCBox;
        private System.Windows.Forms.DataGridView timeBrGrid;
        private System.Windows.Forms.DataGridView LettersGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label stepLabel;
        private System.Windows.Forms.ComboBox stepCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentDayTB;
        private System.Windows.Forms.Label crL;
        private System.Windows.Forms.DataGridView crGrid;
    }
}

