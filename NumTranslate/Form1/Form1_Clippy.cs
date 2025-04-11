using System;
using System.Drawing;
using System.Threading;
using Timer = System.Threading.Timer;

namespace NumTranslate
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Метод для настройки анимированного помощника Clippy.
        /// Загружает изображения для анимации, создает PictureBox для отображения Clippy и настраивает таймер для анимации.
        /// </summary>
        private void SetupCoolClippy()
        {
            /// <summary>
            /// Получает базовый путь к приложению для загрузки изображений.
            /// </summary>
            
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            
            
            /// <summary>
            /// Массив изображений, содержащий кадры анимации Clippy.
            /// </summary>
            
            clippyFrames = new Image[]
            {
                Image.FromFile(basePath + "Gifs\\defaultClippy.gif"),
                Image.FromFile(basePath + "Gifs\\questionMark.gif"),
                Image.FromFile(basePath + "Gifs\\nice.gif")
            };
            
            /// <summary>
            /// Создает PictureBox для отображения анимации Clippy.
            /// Устанавливает размер, расположение и режим отображения изображения (растягиваем изображение).
            /// </summary>
            
            clippyPictureBox = new PictureBox
            {
                Size = new Size(250, 250), 
                Location = new Point(50, 275), 
                SizeMode = PictureBoxSizeMode.StretchImage 
            };
            this.Controls.Add(clippyPictureBox);
            clippyPictureBox.Image = clippyFrames[0];
            
            /// <summary>
            /// Инициализирует таймер для анимации Clippy.
            /// Таймер изначально остановлен (Timeout.Infinite).
            /// </summary>
            
            animationTimer = new Timer(AnimateClippy, null, Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// Метод для анимации Clippy.
        /// Переключает кадры анимации и обновляет изображение в PictureBox.
        /// Если метод вызывается не из основного потока, использует Invoke для безопасного обновления UI.
        /// </summary>
        private void AnimateClippy(object state)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    currentFrame = (currentFrame + 1) % clippyFrames.Length;
                    clippyPictureBox.Image = clippyFrames[currentFrame];
                }));
            }
            else
            {
                currentFrame = (currentFrame + 1) % clippyFrames.Length;
                clippyPictureBox.Image = clippyFrames[currentFrame];
            }
        }
        /// <summary>
        /// Запускает анимацию Clippy.
        /// Устанавливает интервал таймера на 2000 мс (2 секунды).
        /// </summary>
        private void StartAnimation()
        {
            animationTimer.Change(0, 2000); 
        }

        /// <summary>
        /// Останавливает анимацию Clippy.
        /// Устанавливает таймер в состояние Timeout.Infinite, что останавливает его выполнение.
        /// </summary>
        private void StopAnimation()
        {
            animationTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}