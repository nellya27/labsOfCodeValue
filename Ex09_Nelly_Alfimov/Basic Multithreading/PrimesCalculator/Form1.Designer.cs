namespace PrimesCalculator
{
    partial class Form1
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
            this.firstNumber = new System.Windows.Forms.TextBox();
            this.secondNumber = new System.Windows.Forms.TextBox();
            this.calcButton = new System.Windows.Forms.Button();
            this.outputFile = new System.Windows.Forms.TextBox();
            this.formLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNumber
            // 
            this.firstNumber.Location = new System.Drawing.Point(12, 57);
            this.firstNumber.Name = "firstNumber";
            this.firstNumber.Size = new System.Drawing.Size(71, 20);
            this.firstNumber.TabIndex = 0;
            // 
            // secondNumber
            // 
            this.secondNumber.Location = new System.Drawing.Point(12, 83);
            this.secondNumber.Name = "secondNumber";
            this.secondNumber.Size = new System.Drawing.Size(71, 20);
            this.secondNumber.TabIndex = 1;
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(12, 152);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(75, 23);
            this.calcButton.TabIndex = 2;
            this.calcButton.Text = "Calculate";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // outputFile
            // 
            this.outputFile.Location = new System.Drawing.Point(12, 109);
            this.outputFile.Name = "outputFile";
            this.outputFile.Size = new System.Drawing.Size(71, 20);
            this.outputFile.TabIndex = 5;
            // 
            // formLabel
            // 
            this.formLabel.Location = new System.Drawing.Point(108, 26);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(60, 30);
            this.formLabel.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.formLabel);
            this.Controls.Add(this.outputFile);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.secondNumber);
            this.Controls.Add(this.firstNumber);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNumber;
        private System.Windows.Forms.TextBox secondNumber;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.TextBox outputFile;
        private System.Windows.Forms.Label formLabel;
    }
}

