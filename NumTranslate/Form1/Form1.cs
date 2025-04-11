using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace NumTranslate
{
    public partial class Form1 : Form
    {
        private PictureBox clippyPictureBox; // Элемент для отображения скрепки
        private Timer animationTimer; // Таймер для анимации
        private int currentFrame = 0; // Текущий кадр анимации
        private Image[] clippyFrames; // Массив кадров анимации

        public Form1()
        {
            InitializeComponent();
            DefaultClippyButton(); 
            NiceButton(); 
            SetupCoolClippy(); 
            AddTextLabels();
            AddNumberInputField();
            AddComboBoxes();
            AddResultTextBox();
        }
    }
}