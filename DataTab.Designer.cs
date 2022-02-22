namespace Modbus.Common
{
    partial class DataTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelTxtSize = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStartAdress = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonApply);
            this.groupBox1.Controls.Add(this.labelTxtSize);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtStartAdress);
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.groupBoxData);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(645, 487);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(380, 14);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(115, 34);
            this.buttonApply.TabIndex = 36;
            this.buttonApply.Text = "Apply";
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // labelTxtSize
            // 
            this.labelTxtSize.Location = new System.Drawing.Point(217, 23);
            this.labelTxtSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTxtSize.Name = "labelTxtSize";
            this.labelTxtSize.Size = new System.Drawing.Size(56, 17);
            this.labelTxtSize.TabIndex = 35;
            this.labelTxtSize.Text = "Size";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(281, 20);
            this.txtSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSize.MaxLength = 3;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(52, 22);
            this.txtSize.TabIndex = 34;
            this.txtSize.Text = "64";
            this.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSize.TextChanged += new System.EventHandler(this.txtSize_TextChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "Start Address";
            // 
            // txtStartAdress
            // 
            this.txtStartAdress.Location = new System.Drawing.Point(115, 20);
            this.txtStartAdress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStartAdress.Name = "txtStartAdress";
            this.txtStartAdress.Size = new System.Drawing.Size(71, 22);
            this.txtStartAdress.TabIndex = 26;
            this.txtStartAdress.Text = "4100";
            this.txtStartAdress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(503, 14);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(115, 34);
            this.buttonClear.TabIndex = 25;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxData.Location = new System.Drawing.Point(0, 54);
            this.groupBoxData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxData.Size = new System.Drawing.Size(645, 423);
            this.groupBoxData.TabIndex = 17;
            this.groupBoxData.TabStop = false;
            // 
            // DataTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DataTab";
            this.Size = new System.Drawing.Size(650, 500);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button buttonApply;
        protected System.Windows.Forms.Label labelTxtSize;
        protected System.Windows.Forms.TextBox txtSize;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox txtStartAdress;
        protected System.Windows.Forms.Button buttonClear;
        protected System.Windows.Forms.GroupBox groupBoxData;
    }
}
