namespace NumTranslate;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

        // Устанавливаем стиль границ формы
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        // Включаем панель управления (с кнопками "Закрыть", "Свернуть")
        this.ControlBox = true;

        // Устанавливаем заголовок формы
        this.Text = "Программа группы 'Секция 3'";

        // Настройка минимальной/максимальной кнопок
        this.MinimizeBox = true;  // Разрешить сворачивание
        this.MaximizeBox = false; // Запретить разворачивание

        // Устанавливаем цвет фона и размер формы
        this.BackColor = Color.FromArgb(252, 254, 252);
        this.Size = new Size(800, 450);
        this.ClientSize = new System.Drawing.Size(1024, 600);
    }

    #endregion
}
