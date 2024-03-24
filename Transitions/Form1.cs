using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Transitions
{
    public partial class Form1 : Form
    {
        private List<Image> textures1 = new List<Image>();
        private List<Image> textures2 = new List<Image>();
        private List<Image> alphaImages = new List<Image>();
        private double gamma = 0.5; // Valeur par d�faut pour gamma
        private double blurValue = 0.5; // Valeur par d�faut pour le flou
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        // Ajouter ces variables membres pour suivre l'index de l'image alpha actuellement affich�e
        private int currentAlphaIndex = 0;
        private int totalAlphaImages = 0;

        public Form1()
        {
            InitializeComponent();
            trackBarContrast.Minimum = 1;
            trackBarContrast.Maximum = 20;
            trackBarContrast.Value = 1; // Valeur par d�faut
            trackBarContrast.TickFrequency = 2; // Fr�quence des marqueurs sur la piste
            //trackBarFlou.Minimum = 1;
            //trackBarFlou.Maximum = 100;
            //trackBarFlou.Value = 1; // Valeur par d�faut
            //trackBarFlou.TickFrequency = 10; // Fr�quence des marqueurs sur la piste
            pictureBoxTexture1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxTexture2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAlpha1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLandtile.SizeMode = PictureBoxSizeMode.Zoom;
            totalAlphaImages = alphaImages.Count;
        }

        private void UpdatePictureBoxes()
        {
            // Effacer d'abord tous les contr�les des FlowLayoutPanels
            flowLayoutPanelTextures1.Controls.Clear();
            flowLayoutPanelTextures2.Controls.Clear();
            flowLayoutPanelAlphaImages.Controls.Clear();

            // Afficher les textures 1
            foreach (Image texture in textures1)
            {
                AddPictureBoxToFlowLayout(flowLayoutPanelTextures1, texture, 128, 128);
            }

            // Afficher les textures 2
            foreach (Image texture in textures2)
            {
                AddPictureBoxToFlowLayout(flowLayoutPanelTextures2, texture, 128, 128);
            }

            // Afficher les alphaImages
            foreach (Image alphaImage in alphaImages)
            {
                AddPictureBoxToFlowLayout(flowLayoutPanelAlphaImages, alphaImage, 128, 128);
            }
        }

        private void AddPictureBoxToFlowLayout(FlowLayoutPanel flowLayoutPanel, Image image, int width, int height)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(width, height);

            flowLayoutPanel.Controls.Add(pictureBox);
        }



        private Image RotateAndResizeImageForPreview(Image image, double angle)
        {
            // Cr�er une nouvelle image avec la taille sp�cifi�e
            Bitmap rotatedImage = new Bitmap(46, 45);

            // Cr�er une matrice de transformation pour la rotation
            Matrix matrix = new Matrix();
            matrix.Translate(23, 22); // D�placer l'origine l�g�rement vers la droite pour compenser l'ajustement
            matrix.Rotate((float)angle); // Rotation
            matrix.Translate(-16, -16); // Ajustement apr�s la rotation

            // Dessiner l'image d'origine rotat�e sur la nouvelle image
            using (Graphics graphics = Graphics.FromImage(rotatedImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.Transform = matrix;

                // Dessiner l'image d'origine sur la nouvelle image en ajustant la taille pour qu'elle mesure exactement 46x45 pixels
                graphics.DrawImage(image, -1, 0, 34, 33);
            }

            return rotatedImage;
        }

        // Gestionnaire d'�v�nement pour le bouton "Pr�c�dent"
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // D�cr�menter l'index de l'image alpha actuellement affich�e
            currentAlphaIndex--;

            // V�rifier si l'index est inf�rieur � z�ro, revenir � la derni�re image si c'est le cas
            if (currentAlphaIndex < 0)
            {
                currentAlphaIndex = alphaImages.Count - 1;
            }

            // Mettre � jour la pr�visualisation avec l'image alpha correspondante
            UpdatePreview();
            // Mettre � jour le label "compteur"
            UpdateCounterLabel();
        }

        // Gestionnaire d'�v�nement pour le bouton "Suivant"
        private void btnNext_Click(object sender, EventArgs e)
        {
            // Incr�menter l'index de l'image alpha actuellement affich�e
            currentAlphaIndex++;

            // V�rifier si l'index d�passe le nombre total d'images, revenir � la premi�re image si c'est le cas
            if (currentAlphaIndex >= alphaImages.Count)
            {
                currentAlphaIndex = 0;
            }

            // Mettre � jour la pr�visualisation avec l'image alpha correspondante
            UpdatePreview();
            // Mettre � jour le label "compteur"
            UpdateCounterLabel();
        }

        // M�thode pour mettre � jour le label "compteur" avec le num�ro actuel de l'image alpha
        private void UpdateCounterLabel()
        {
            int currentNumber = currentAlphaIndex + 1; // Ajouter 1 car les indices commencent � 0
            int totalNumber = alphaImages.Count;
            Compteur.Text = $"{currentNumber}/{totalNumber}";
        }






        // Mettre � jour la pr�visualisation avec l'image alpha correspondant � l'index actuel
        private void UpdatePreview()
        {
            // V�rifier si des images alpha sont disponibles
            if (alphaImages.Count > 0)
            {
                // Obtenir l'image alpha correspondant � l'index actuel
                Image alphaImage = alphaImages[currentAlphaIndex];

                // G�n�rer la premi�re image de transition avec l'image alpha s�lectionn�e
                // Utilisez �galement les autres textures comme vous le faites actuellement
                Image texture1 = textures1[0];
                Image texture2 = textures2[0];
                Bitmap transitionImage = GenerateTransition(texture1, texture2, alphaImage);

                // Afficher la premi�re image de transition dans pictureBoxPreview
                pictureBoxPreview.Image = transitionImage;

                // Redimensionner et pivoter l'image pour la pr�visualisation
                Image previewImage = RotateAndResizeImageForPreview(transitionImage, 45);

                // Afficher la pr�visualisation dans pictureBoxLandtile
                pictureBoxLandtile.Image = previewImage;
            }
        }



        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            gamma = (double)trackBarContrast.Value;
            UpdatePreview();
        }

        private void trackBarFlou_Scroll(object sender, EventArgs e)
        {
            blurValue = (double)trackBarFlou.Value / 10.0 * 2;
            UpdatePreview();
        }

        private Bitmap GenerateTransition(Image texture1, Image texture2, Image alphaImage)
        {
            Bitmap blurredAlphaImage = ApplyGamma(ApplyGaussianBlur((Bitmap)alphaImage, blurValue), gamma);
            Bitmap transitionImage = new Bitmap(texture1.Width, texture1.Height);

            for (int x = 0; x < texture1.Width; x++)
            {
                for (int y = 0; y < texture1.Height; y++)
                {
                    Color alphaPixel = blurredAlphaImage.GetPixel(x, y);
                    float alpha = alphaPixel.GetBrightness();

                    Color texture1Pixel = ((Bitmap)texture1).GetPixel(x, y);
                    Color texture2Pixel = ((Bitmap)texture2).GetPixel(x, y);

                    int newRed = (int)(alpha * texture1Pixel.R + (1 - alpha) * texture2Pixel.R);
                    int newGreen = (int)(alpha * texture1Pixel.G + (1 - alpha) * texture2Pixel.G);
                    int newBlue = (int)(alpha * texture1Pixel.B + (1 - alpha) * texture2Pixel.B);

                    newRed = Math.Max(0, Math.Min(255, newRed));
                    newGreen = Math.Max(0, Math.Min(255, newGreen));
                    newBlue = Math.Max(0, Math.Min(255, newBlue));

                    transitionImage.SetPixel(x, y, Color.FromArgb(newRed, newGreen, newBlue));
                }
            }

            return transitionImage;
        }

        private Bitmap ApplyGaussianBlur(Bitmap image, double blurValue)
        {
            BlurFilter filter = new BlurFilter();
            filter.Sigma = blurValue;
            return filter.ProcessImage(image);
        }

        private Bitmap ApplyGamma(Bitmap image, double gamma)
        {
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalPixel = image.GetPixel(x, y);
                    int newRed = (int)(255 * Math.Pow(originalPixel.R / 255.0, gamma));
                    int newGreen = (int)(255 * Math.Pow(originalPixel.G / 255.0, gamma));
                    int newBlue = (int)(255 * Math.Pow(originalPixel.B / 255.0, gamma));

                    newRed = Math.Max(0, Math.Min(255, newRed));
                    newGreen = Math.Max(0, Math.Min(255, newGreen));
                    newBlue = Math.Max(0, Math.Min(255, newBlue));

                    adjustedImage.SetPixel(x, y, Color.FromArgb(newRed, newGreen, newBlue));
                }
            }

            return adjustedImage;
        }

        private void btnSelectTexture1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textures1.Clear();
                foreach (string imagePath in openFileDialog.FileNames)
                {
                    try
                    {
                        Image texture1 = Image.FromFile(imagePath);
                        textures1.Add(texture1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Une erreur s'est produite lors du chargement de l'image : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                UpdatePictureBoxes();
                UpdatePreview();
            }
        }

        private void btnSelectTexture2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textures2.Clear();
                foreach (string imagePath in openFileDialog.FileNames)
                {
                    try
                    {
                        Image texture2 = Image.FromFile(imagePath);
                        textures2.Add(texture2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Une erreur s'est produite lors du chargement de l'image : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                UpdatePictureBoxes();
                UpdatePreview();
            }
        }


        private void btnSelectAlpha_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "S�lectionner le dossier contenant les images alpha";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;

                try
                {
                    alphaImages.Clear();
                    string[] alphaFiles = Directory.GetFiles(folderPath, "*.png");

                    foreach (string filePath in alphaFiles)
                    {
                        Image alphaImage = Image.FromFile(filePath);
                        alphaImages.Add(alphaImage);
                    }

                    MessageBox.Show($"Chargement r�ussi : {alphaImages.Count} images alpha charg�es.", "Succ�s", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite lors du chargement des images alpha : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                UpdatePictureBoxes();
                UpdatePreview();
            }
        }







        private void btnGenerateTransition_Click(object sender, EventArgs e)
        {
            if (textures1.Count == 0 || textures2.Count == 0 || alphaImages.Count == 0)
            {
                MessageBox.Show("Veuillez s�lectionner les textures et les images alpha avant de g�n�rer la transition.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                int alphaIndex = 0;

                foreach (Image alphaImage in alphaImages)
                {
                    Image texture1 = textures1[alphaIndex % textures1.Count];
                    Image texture2 = textures2[alphaIndex % textures2.Count];
                    Bitmap transitionImage = GenerateTransition(texture1, texture2, alphaImage);

                    // Enregistrer les images sans rotation
                    string transitionFileName = Path.Combine(folderBrowserDialog.SelectedPath, $"Transition_{alphaIndex + 1}.bmp");
                    transitionImage.Save(transitionFileName, ImageFormat.Bmp);

                    // Pr�visualiser la transition
                    Image previewImage = RotateAndResizeImageForPreview(transitionImage, 45);

                    // Enregistrer les images avec rotation � 45 degr�s et redimensionn�es
                    string rotatedTransitionFileName = Path.Combine(folderBrowserDialog.SelectedPath, $"RotatedTransition_{alphaIndex + 1}.bmp");
                    previewImage.Save(rotatedTransitionFileName, ImageFormat.Bmp);

                    alphaIndex++;
                }

                MessageBox.Show("G�n�ration termin�e.", "Succ�s", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Vider les listes
                textures1.Clear();
                textures2.Clear();
                alphaImages.Clear();

                // Effacer les PictureBox
                pictureBoxTexture1.Image = null;
                pictureBoxTexture2.Image = null;
                pictureBoxAlpha1.Image = null;
                pictureBoxPreview.Image = null;
                pictureBoxLandtile.Image = null;

                // Effacer les contr�les des FlowLayoutPanels
                flowLayoutPanelTextures1.Controls.Clear();
                flowLayoutPanelTextures2.Controls.Clear();
                flowLayoutPanelAlphaImages.Controls.Clear();
            }
        }





        // D�finition de la classe BlurFilter pour le flou gaussien
        public class BlurFilter
        {
            private double[] kernel;
            private int kernelSize;

            public double Sigma { get; set; }

            public BlurFilter()
            {
                Sigma = 1.0;
                kernelSize = 1;
                kernel = GenerateGaussianKernel(Sigma, kernelSize);
            }

            public Bitmap ProcessImage(Bitmap image)
            {
                Bitmap result = new Bitmap(image.Width, image.Height);

                int k = kernelSize / 2;
                int r, g, b;

                for (int x = k; x < image.Width - k; x++)
                {
                    for (int y = k; y < image.Height - k; y++)
                    {
                        r = g = b = 0;

                        for (int i = -k; i <= k; i++)
                        {
                            for (int j = -k; j <= k; j++)
                            {
                                Color c = image.GetPixel(x + i, y + j);
                                double w = kernel[i + k] * kernel[j + k];
                                r += (int)(c.R * w);
                                g += (int)(c.G * w);
                                b += (int)(c.B * w);
                            }
                        }

                        r = Math.Min(255, Math.Max(0, r));
                        g = Math.Min(255, Math.Max(0, g));
                        b = Math.Min(255, Math.Max(0, b));

                        result.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                return result;
            }

            private double Gaussian(double x, double sigma)
            {
                return Math.Exp(-(x * x) / (2 * sigma * sigma)) / (Math.Sqrt(2 * Math.PI) * sigma);
            }

            private double[] GenerateGaussianKernel(double sigma, int size)
            {
                double[] kernel = new double[size];
                int center = size / 2;

                for (int i = 0; i < size; i++)
                {
                    kernel[i] = Gaussian(i - center, sigma);
                }

                // Normalize the kernel
                double sum = 0;
                foreach (double value in kernel)
                {
                    sum += value;
                }

                for (int i = 0; i < size; i++)
                {
                    kernel[i] /= sum;
                }

                return kernel;
            }
        }
    }
}