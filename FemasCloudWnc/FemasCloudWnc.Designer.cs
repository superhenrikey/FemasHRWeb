
namespace FemasCloudWnc
{
    partial class FemasCloudWnc
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
            this.wbFemas = new System.Windows.Forms.WebBrowser();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // wbFemas
            // 
            this.wbFemas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbFemas.Location = new System.Drawing.Point(12, 47);
            this.wbFemas.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbFemas.Name = "wbFemas";
            this.wbFemas.ScriptErrorsSuppressed = true;
            this.wbFemas.Size = new System.Drawing.Size(828, 430);
            this.wbFemas.TabIndex = 0;
            this.wbFemas.Url = new System.Uri("https://femascloud.com/wnc/", System.UriKind.Absolute);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(516, 8);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(91, 28);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(89, 12);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(159, 22);
            this.txtUser.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(331, 12);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(159, 22);
            this.txtPass.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(11, 13);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(73, 19);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(256, 13);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(72, 19);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(633, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 28);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Work In";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Location = new System.Drawing.Point(747, 8);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(91, 28);
            this.btnEnd.TabIndex = 7;
            this.btnEnd.Text = "Work Out";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // timerStart
            // 
            this.timerStart.Tick += new System.EventHandler(this.timerStart_Tick);
            // 
            // FemasCloudWnc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 489);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.wbFemas);
            this.Name = "FemasCloudWnc";
            this.Text = "FemasCloudWnc";
            this.Load += new System.EventHandler(this.FemasCloudWnc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbFemas;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Timer timerStart;
    }
}

