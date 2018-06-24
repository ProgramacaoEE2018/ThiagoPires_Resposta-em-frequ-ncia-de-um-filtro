namespace AppFiltro
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.bconect = new System.Windows.Forms.Button();
            this.bcaptr = new System.Windows.Forms.Button();
            this.bclean = new System.Windows.Forms.Button();
            this.grafmod = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graffase = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grafmod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graffase)).BeginInit();
            this.SuspendLayout();
            // 
            // bconect
            // 
            this.bconect.Location = new System.Drawing.Point(52, 87);
            this.bconect.Name = "bconect";
            this.bconect.Size = new System.Drawing.Size(75, 23);
            this.bconect.TabIndex = 0;
            this.bconect.Text = "Conectar";
            this.bconect.UseVisualStyleBackColor = true;
            this.bconect.Click += new System.EventHandler(this.bconect_Click);
            // 
            // bcaptr
            // 
            this.bcaptr.Location = new System.Drawing.Point(52, 175);
            this.bcaptr.Name = "bcaptr";
            this.bcaptr.Size = new System.Drawing.Size(75, 23);
            this.bcaptr.TabIndex = 1;
            this.bcaptr.Text = "Capturar";
            this.bcaptr.UseVisualStyleBackColor = true;
            this.bcaptr.Click += new System.EventHandler(this.bcaptr_Click);
            // 
            // bclean
            // 
            this.bclean.Location = new System.Drawing.Point(52, 262);
            this.bclean.Name = "bclean";
            this.bclean.Size = new System.Drawing.Size(75, 23);
            this.bclean.TabIndex = 2;
            this.bclean.Text = "Limpar";
            this.bclean.UseVisualStyleBackColor = true;
            this.bclean.Click += new System.EventHandler(this.bclean_Click);
            // 
            // grafmod
            // 
            chartArea1.Name = "ChartArea1";
            this.grafmod.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.grafmod.Legends.Add(legend1);
            this.grafmod.Location = new System.Drawing.Point(349, 87);
            this.grafmod.Name = "grafmod";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.grafmod.Series.Add(series1);
            this.grafmod.Size = new System.Drawing.Size(439, 300);
            this.grafmod.TabIndex = 3;
            this.grafmod.Text = "chart1";
            // 
            // graffase
            // 
            chartArea2.Name = "ChartArea1";
            this.graffase.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.graffase.Legends.Add(legend2);
            this.graffase.Location = new System.Drawing.Point(349, 393);
            this.graffase.Name = "graffase";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.graffase.Series.Add(series2);
            this.graffase.Size = new System.Drawing.Size(439, 300);
            this.graffase.TabIndex = 4;
            this.graffase.Text = "chart2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(417, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Diagrama de Bode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Verifica a conexão com o osciloscópio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Inicia a medição (somente se o osciloscópio estiver conectado)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Limpa os resultados do gráfico";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 697);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graffase);
            this.Controls.Add(this.grafmod);
            this.Controls.Add(this.bclean);
            this.Controls.Add(this.bcaptr);
            this.Controls.Add(this.bconect);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grafmod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graffase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bconect;
        private System.Windows.Forms.Button bcaptr;
        private System.Windows.Forms.Button bclean;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafmod;
        private System.Windows.Forms.DataVisualization.Charting.Chart graffase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

