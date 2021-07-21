
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
            this.SuspendLayout();
            // 
            // button_ChooseFiles
            // 
            this.button_ChooseFiles.AutoSize = true;
            this.button_ChooseFiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_ChooseFiles.Location = new System.Drawing.Point(0, 327);
            this.button_ChooseFiles.Name = "button_ChooseFiles";
            this.button_ChooseFiles.Size = new System.Drawing.Size(507, 47);
            this.button_ChooseFiles.TabIndex = 0;
            this.button_ChooseFiles.Text = "Выберите файл(ы)";
            this.button_ChooseFiles.UseVisualStyleBackColor = true;
            this.button_ChooseFiles.Click += new System.EventHandler(this.button_ChooseFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 374);
            this.Controls.Add(this.button_ChooseFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ChooseFiles;
    }
}

