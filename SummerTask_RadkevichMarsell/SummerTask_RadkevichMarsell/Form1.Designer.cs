
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
            this.MenuStrip_topMenu = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_Create = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_BlockScheme = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitContainer_Workspace = new System.Windows.Forms.SplitContainer();
            this.MenuStrip_topMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Workspace)).BeginInit();
            this.SplitContainer_Workspace.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip_topMenu
            // 
            this.MenuStrip_topMenu.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.MenuStrip_topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Create});
            this.MenuStrip_topMenu.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_topMenu.Name = "MenuStrip_topMenu";
            this.MenuStrip_topMenu.Size = new System.Drawing.Size(978, 24);
            this.MenuStrip_topMenu.TabIndex = 4;
            // 
            // ToolStripMenuItem_Create
            // 
            this.ToolStripMenuItem_Create.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_BlockScheme});
            this.ToolStripMenuItem_Create.Name = "ToolStripMenuItem_Create";
            this.ToolStripMenuItem_Create.Size = new System.Drawing.Size(62, 20);
            this.ToolStripMenuItem_Create.Text = "Создать";
            // 
            // ToolStripMenuItem_BlockScheme
            // 
            this.ToolStripMenuItem_BlockScheme.Name = "ToolStripMenuItem_BlockScheme";
            this.ToolStripMenuItem_BlockScheme.Size = new System.Drawing.Size(139, 22);
            this.ToolStripMenuItem_BlockScheme.Text = "Блок-схему";
            this.ToolStripMenuItem_BlockScheme.Click += new System.EventHandler(this.ToolStripMenuItem_BlockScheme_Click);
            // 
            // SplitContainer_Workspace
            // 
            this.SplitContainer_Workspace.Location = new System.Drawing.Point(0, 27);
            this.SplitContainer_Workspace.Name = "SplitContainer_Workspace";
            // 
            // SplitContainer_Workspace.Panel1
            // 
            this.SplitContainer_Workspace.Panel1.AutoScroll = true;
            this.SplitContainer_Workspace.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SplitContainer_Workspace.Size = new System.Drawing.Size(978, 554);
            this.SplitContainer_Workspace.SplitterDistance = 209;
            this.SplitContainer_Workspace.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 603);
            this.Controls.Add(this.SplitContainer_Workspace);
            this.Controls.Add(this.MenuStrip_topMenu);
            this.MainMenuStrip = this.MenuStrip_topMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MenuStrip_topMenu.ResumeLayout(false);
            this.MenuStrip_topMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Workspace)).EndInit();
            this.SplitContainer_Workspace.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStrip_topMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Create;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_BlockScheme;
        private System.Windows.Forms.SplitContainer SplitContainer_Workspace;
    }
}

