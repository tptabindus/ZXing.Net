﻿namespace WindowsFormsDemo
{
   partial class DecodingOptionsForm
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
         this.chkAutoRotate = new System.Windows.Forms.CheckBox();
         this.chkTryHarder = new System.Windows.Forms.CheckBox();
         this.chkTryInverted = new System.Windows.Forms.CheckBox();
         this.btnOk = new System.Windows.Forms.Button();
         this.chkPureBarcode = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // chkAutoRotate
         // 
         this.chkAutoRotate.AutoSize = true;
         this.chkAutoRotate.Location = new System.Drawing.Point(12, 12);
         this.chkAutoRotate.Name = "chkAutoRotate";
         this.chkAutoRotate.Size = new System.Drawing.Size(118, 17);
         this.chkAutoRotate.TabIndex = 0;
         this.chkAutoRotate.Text = "enable Auto Rotate";
         this.chkAutoRotate.UseVisualStyleBackColor = true;
         // 
         // chkTryHarder
         // 
         this.chkTryHarder.AutoSize = true;
         this.chkTryHarder.Location = new System.Drawing.Point(12, 35);
         this.chkTryHarder.Name = "chkTryHarder";
         this.chkTryHarder.Size = new System.Drawing.Size(111, 17);
         this.chkTryHarder.TabIndex = 1;
         this.chkTryHarder.Text = "enable Try Harder";
         this.chkTryHarder.UseVisualStyleBackColor = true;
         // 
         // chkTryInverted
         // 
         this.chkTryInverted.AutoSize = true;
         this.chkTryInverted.Location = new System.Drawing.Point(12, 58);
         this.chkTryInverted.Name = "chkTryInverted";
         this.chkTryInverted.Size = new System.Drawing.Size(118, 17);
         this.chkTryInverted.TabIndex = 2;
         this.chkTryInverted.Text = "enable Try Inverted";
         this.chkTryInverted.UseVisualStyleBackColor = true;
         // 
         // btnOk
         // 
         this.btnOk.Location = new System.Drawing.Point(160, 77);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(112, 23);
         this.btnOk.TabIndex = 3;
         this.btnOk.Text = "Ok";
         this.btnOk.UseVisualStyleBackColor = true;
         this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
         // 
         // chkPureBarcode
         // 
         this.chkPureBarcode.AutoSize = true;
         this.chkPureBarcode.Location = new System.Drawing.Point(12, 81);
         this.chkPureBarcode.Name = "chkPureBarcode";
         this.chkPureBarcode.Size = new System.Drawing.Size(142, 17);
         this.chkPureBarcode.TabIndex = 4;
         this.chkPureBarcode.Text = "image has Pure Barcode";
         this.chkPureBarcode.UseVisualStyleBackColor = true;
         // 
         // DecodingOptionsForm
         // 
         this.AcceptButton = this.btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 116);
         this.Controls.Add(this.chkPureBarcode);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.chkTryInverted);
         this.Controls.Add(this.chkTryHarder);
         this.Controls.Add(this.chkAutoRotate);
         this.Name = "DecodingOptionsForm";
         this.Text = "DecodingOptionsForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox chkAutoRotate;
      private System.Windows.Forms.CheckBox chkTryHarder;
      private System.Windows.Forms.CheckBox chkTryInverted;
      private System.Windows.Forms.Button btnOk;
      private System.Windows.Forms.CheckBox chkPureBarcode;
   }
}