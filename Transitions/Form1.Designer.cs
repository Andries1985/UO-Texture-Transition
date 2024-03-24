namespace Transitions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBoxTexture1 = new PictureBox();
            btnSelectTexture1 = new Button();
            btnSelectTexture2 = new Button();
            pictureBoxTexture2 = new PictureBox();
            btnSelectAlpha = new Button();
            btnGenerateTransition = new Button();
            pictureBoxAlpha1 = new PictureBox();
            trackBarContrast = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            pictureBoxPreview = new PictureBox();
            flowLayoutPanelTextures1 = new FlowLayoutPanel();
            flowLayoutPanelTextures2 = new FlowLayoutPanel();
            flowLayoutPanelAlphaImages = new FlowLayoutPanel();
            pictureBoxLandtile = new PictureBox();
            btnPrevious = new Button();
            btnNext = new Button();
            Compteur = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTexture1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTexture2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlpha1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLandtile).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxTexture1
            // 
            pictureBoxTexture1.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(pictureBoxTexture1, "pictureBoxTexture1");
            pictureBoxTexture1.Name = "pictureBoxTexture1";
            pictureBoxTexture1.TabStop = false;
            // 
            // btnSelectTexture1
            // 
            resources.ApplyResources(btnSelectTexture1, "btnSelectTexture1");
            btnSelectTexture1.Name = "btnSelectTexture1";
            btnSelectTexture1.UseVisualStyleBackColor = true;
            btnSelectTexture1.Click += btnSelectTexture1_Click;
            // 
            // btnSelectTexture2
            // 
            resources.ApplyResources(btnSelectTexture2, "btnSelectTexture2");
            btnSelectTexture2.Name = "btnSelectTexture2";
            btnSelectTexture2.Click += btnSelectTexture2_Click;
            // 
            // pictureBoxTexture2
            // 
            pictureBoxTexture2.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(pictureBoxTexture2, "pictureBoxTexture2");
            pictureBoxTexture2.Name = "pictureBoxTexture2";
            pictureBoxTexture2.TabStop = false;
            // 
            // btnSelectAlpha
            // 
            resources.ApplyResources(btnSelectAlpha, "btnSelectAlpha");
            btnSelectAlpha.Name = "btnSelectAlpha";
            btnSelectAlpha.Click += btnSelectAlpha_Click;
            // 
            // btnGenerateTransition
            // 
            resources.ApplyResources(btnGenerateTransition, "btnGenerateTransition");
            btnGenerateTransition.Name = "btnGenerateTransition";
            btnGenerateTransition.Click += btnGenerateTransition_Click;
            // 
            // pictureBoxAlpha1
            // 
            pictureBoxAlpha1.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(pictureBoxAlpha1, "pictureBoxAlpha1");
            pictureBoxAlpha1.Name = "pictureBoxAlpha1";
            pictureBoxAlpha1.TabStop = false;
            // 
            // trackBarContrast
            // 
            trackBarContrast.LargeChange = 1;
            resources.ApplyResources(trackBarContrast, "trackBarContrast");
            trackBarContrast.Name = "trackBarContrast";
            trackBarContrast.Scroll += trackBarContrast_Scroll;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(pictureBoxPreview, "pictureBoxPreview");
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.TabStop = false;
            // 
            // flowLayoutPanelTextures1
            // 
            resources.ApplyResources(flowLayoutPanelTextures1, "flowLayoutPanelTextures1");
            flowLayoutPanelTextures1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelTextures1.Name = "flowLayoutPanelTextures1";
            // 
            // flowLayoutPanelTextures2
            // 
            resources.ApplyResources(flowLayoutPanelTextures2, "flowLayoutPanelTextures2");
            flowLayoutPanelTextures2.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelTextures2.Name = "flowLayoutPanelTextures2";
            // 
            // flowLayoutPanelAlphaImages
            // 
            resources.ApplyResources(flowLayoutPanelAlphaImages, "flowLayoutPanelAlphaImages");
            flowLayoutPanelAlphaImages.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelAlphaImages.Name = "flowLayoutPanelAlphaImages";
            // 
            // pictureBoxLandtile
            // 
            resources.ApplyResources(pictureBoxLandtile, "pictureBoxLandtile");
            pictureBoxLandtile.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxLandtile.Name = "pictureBoxLandtile";
            pictureBoxLandtile.TabStop = false;
            // 
            // btnPrevious
            // 
            resources.ApplyResources(btnPrevious, "btnPrevious");
            btnPrevious.Name = "btnPrevious";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            resources.ApplyResources(btnNext, "btnNext");
            btnNext.Name = "btnNext";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // Compteur
            // 
            resources.ApplyResources(Compteur, "Compteur");
            Compteur.Name = "Compteur";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Compteur);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(pictureBoxLandtile);
            Controls.Add(flowLayoutPanelAlphaImages);
            Controls.Add(flowLayoutPanelTextures2);
            Controls.Add(flowLayoutPanelTextures1);
            Controls.Add(pictureBoxPreview);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBarContrast);
            Controls.Add(pictureBoxAlpha1);
            Controls.Add(btnSelectAlpha);
            Controls.Add(btnGenerateTransition);
            Controls.Add(pictureBoxTexture2);
            Controls.Add(btnSelectTexture2);
            Controls.Add(btnSelectTexture1);
            Controls.Add(pictureBoxTexture1);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxTexture1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTexture2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlpha1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLandtile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTexture1;
        private System.Windows.Forms.Button btnSelectTexture1;
        private Button btnSelectTexture2;
        private PictureBox pictureBoxTexture2;
        private System.Windows.Forms.Button btnSelectAlpha;
        private System.Windows.Forms.Button btnGenerateTransition;
        private PictureBox pictureBoxAlpha1;
        private TrackBar trackBarContrast;
        private Label label1;
        private Label label2;
        private PictureBox pictureBoxPreview;
        private FlowLayoutPanel flowLayoutPanelTextures1;
        private FlowLayoutPanel flowLayoutPanelTextures2;
        private FlowLayoutPanel flowLayoutPanelAlphaImages;
        private TrackBar trackBarFlou;
        private PictureBox pictureBoxLandtile;
        private Button btnPrevious;
        private Button btnNext;
        private Label Compteur;
    }
}
