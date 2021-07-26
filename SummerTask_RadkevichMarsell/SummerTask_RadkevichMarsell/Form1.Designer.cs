
namespace SummerTask_RadkevichMarsell
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
            this.button_ChooseFiles = new System.Windows.Forms.Button();
            this.TB_ChoosedFiles = new System.Windows.Forms.TextBox();
            this.Btn_CreateScheme = new System.Windows.Forms.Button();
            this.TB_Methods = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_ChooseFiles
            // 
            this.button_ChooseFiles.AutoSize = true;
            this.button_ChooseFiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_ChooseFiles.Location = new System.Drawing.Point(0, 556);
            this.button_ChooseFiles.Name = "button_ChooseFiles";
            this.button_ChooseFiles.Size = new System.Drawing.Size(978, 47);
            this.button_ChooseFiles.TabIndex = 0;
            this.button_ChooseFiles.Text = "Выберите файл(ы)";
            this.button_ChooseFiles.UseVisualStyleBackColor = true;
            this.button_ChooseFiles.Click += new System.EventHandler(this.button_ChooseFiles_Click);
            // 
            // TB_ChoosedFiles
            // 
            this.TB_ChoosedFiles.Location = new System.Drawing.Point(12, 20);
            this.TB_ChoosedFiles.Multiline = true;
            this.TB_ChoosedFiles.Name = "TB_ChoosedFiles";
            this.TB_ChoosedFiles.ReadOnly = true;
            this.TB_ChoosedFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_ChoosedFiles.Size = new System.Drawing.Size(479, 278);
            this.TB_ChoosedFiles.TabIndex = 1;
            this.TB_ChoosedFiles.WordWrap = false;
            // 
            // Btn_CreateScheme
            // 
            this.Btn_CreateScheme.Location = new System.Drawing.Point(12, 304);
            this.Btn_CreateScheme.Name = "Btn_CreateScheme";
            this.Btn_CreateScheme.Size = new System.Drawing.Size(479, 38);
            this.Btn_CreateScheme.TabIndex = 2;
            this.Btn_CreateScheme.Text = "Создать блок-схемы";
            this.Btn_CreateScheme.UseVisualStyleBackColor = true;
            this.Btn_CreateScheme.Click += new System.EventHandler(this.Btn_CreateScheme_Click);
            // 
            // TB_Methods
            // 
            this.TB_Methods.Location = new System.Drawing.Point(543, 20);
            this.TB_Methods.Multiline = true;
            this.TB_Methods.Name = "TB_Methods";
            this.TB_Methods.ReadOnly = true;
            this.TB_Methods.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Methods.Size = new System.Drawing.Size(423, 278);
            this.TB_Methods.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 603);
            this.Controls.Add(this.TB_Methods);
            this.Controls.Add(this.Btn_CreateScheme);
            this.Controls.Add(this.TB_ChoosedFiles);
            this.Controls.Add(this.button_ChooseFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ChooseFiles;
        private System.Windows.Forms.TextBox TB_ChoosedFiles;
        private System.Windows.Forms.Button Btn_CreateScheme;
        private System.Windows.Forms.TextBox TB_Methods;
    }
}

