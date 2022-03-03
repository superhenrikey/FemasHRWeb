
namespace FemasCloudWnc
{
    partial class DailyTemperature
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
            this.components = new System.ComponentModel.Container();
            this.wbTemperature = new System.Windows.Forms.WebBrowser();
            this.timerClick = new System.Windows.Forms.Timer(this.components);
            this.btnClick = new System.Windows.Forms.Button();
            this.btnClick2 = new System.Windows.Forms.Button();
            this.btnClick3 = new System.Windows.Forms.Button();
            this.btnClick4 = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wbTemperature
            // 
            this.wbTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbTemperature.Location = new System.Drawing.Point(12, 35);
            this.wbTemperature.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbTemperature.Name = "wbTemperature";
            this.wbTemperature.ScriptErrorsSuppressed = true;
            this.wbTemperature.Size = new System.Drawing.Size(776, 403);
            this.wbTemperature.TabIndex = 0;
            this.wbTemperature.Url = new System.Uri("https://forms.office.com/Pages/ResponsePage.aspx?id=qSd-Xm91ukmjrnKroQoxbjIQFyLah" +
        "t5AjdRVi7Z5szFUN1BGTDM4OFlUSTVaR083M0M4MVNUOVg4Ni4u", System.UriKind.Absolute);
            // 
            // timerClick
            // 
            this.timerClick.Tick += new System.EventHandler(this.timerClick_Tick);
            // 
            // btnClick
            // 
            this.btnClick.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClick.Location = new System.Drawing.Point(270, 3);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(91, 28);
            this.btnClick.TabIndex = 2;
            this.btnClick.Text = "Click";
            this.btnClick.UseVisualStyleBackColor = true;
            this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
            // 
            // btnClick2
            // 
            this.btnClick2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClick2.Location = new System.Drawing.Point(381, 3);
            this.btnClick2.Name = "btnClick2";
            this.btnClick2.Size = new System.Drawing.Size(91, 28);
            this.btnClick2.TabIndex = 3;
            this.btnClick2.Text = "Click 2";
            this.btnClick2.UseVisualStyleBackColor = true;
            this.btnClick2.Click += new System.EventHandler(this.btnClick2_Click);
            // 
            // btnClick3
            // 
            this.btnClick3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClick3.Location = new System.Drawing.Point(490, 3);
            this.btnClick3.Name = "btnClick3";
            this.btnClick3.Size = new System.Drawing.Size(91, 28);
            this.btnClick3.TabIndex = 4;
            this.btnClick3.Text = "Click 3";
            this.btnClick3.UseVisualStyleBackColor = true;
            this.btnClick3.Click += new System.EventHandler(this.btnClick3_Click);
            // 
            // btnClick4
            // 
            this.btnClick4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClick4.Location = new System.Drawing.Point(595, 3);
            this.btnClick4.Name = "btnClick4";
            this.btnClick4.Size = new System.Drawing.Size(91, 28);
            this.btnClick4.TabIndex = 5;
            this.btnClick4.Text = "Click 4";
            this.btnClick4.UseVisualStyleBackColor = true;
            this.btnClick4.Click += new System.EventHandler(this.btnClick4_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(697, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(91, 28);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(162, 3);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(91, 28);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // DailyTemperature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClick4);
            this.Controls.Add(this.btnClick3);
            this.Controls.Add(this.btnClick2);
            this.Controls.Add(this.btnClick);
            this.Controls.Add(this.wbTemperature);
            this.Name = "DailyTemperature";
            this.Text = "DailyTemperature";
            this.Load += new System.EventHandler(this.DailyTemperature_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbTemperature;
        private System.Windows.Forms.Timer timerClick;
        private System.Windows.Forms.Button btnClick;
        private System.Windows.Forms.Button btnClick2;
        private System.Windows.Forms.Button btnClick3;
        private System.Windows.Forms.Button btnClick4;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnReload;
    }
}