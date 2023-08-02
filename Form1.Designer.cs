
namespace OOP_PROJEKT
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.buttonMacierze = new System.Windows.Forms.Button();
            this.labelPrzeciązanie = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMacierze
            // 
            this.buttonMacierze.BackColor = System.Drawing.Color.SlateGray;
            this.buttonMacierze.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMacierze.ForeColor = System.Drawing.Color.Linen;
            this.buttonMacierze.Location = new System.Drawing.Point(287, 349);
            this.buttonMacierze.Name = "buttonMacierze";
            this.buttonMacierze.Size = new System.Drawing.Size(405, 65);
            this.buttonMacierze.TabIndex = 4;
            this.buttonMacierze.Text = "BRYLY REGULARNE";
            this.buttonMacierze.UseVisualStyleBackColor = false;
            this.buttonMacierze.Click += new System.EventHandler(this.buttonMacierze_Click);
            // 
            // labelPrzeciązanie
            // 
            this.labelPrzeciązanie.AutoSize = true;
            this.labelPrzeciązanie.BackColor = System.Drawing.Color.Transparent;
            this.labelPrzeciązanie.Font = new System.Drawing.Font("Calisto MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrzeciązanie.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelPrzeciązanie.Location = new System.Drawing.Point(243, 162);
            this.labelPrzeciązanie.Name = "labelPrzeciązanie";
            this.labelPrzeciązanie.Size = new System.Drawing.Size(479, 34);
            this.labelPrzeciązanie.TabIndex = 6;
            this.labelPrzeciązanie.Text = "Wizualizacja Brył Geometrycznych";
            this.labelPrzeciązanie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(460, 253);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 40);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(964, 547);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelPrzeciązanie);
            this.Controls.Add(this.buttonMacierze);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMenu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMacierze;
        private System.Windows.Forms.Label labelPrzeciązanie;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

