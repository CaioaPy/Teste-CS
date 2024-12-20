namespace teste
{
    public partial class Form1 : Form
    {

        private Button btVerde;
        private Button BtStart;
        private Button btAmarelo;
        private Button btVermelho;
        private Button btAzul;

        int sequencia_sistema = 1;
        int sequencia_atual = 0;
        int aux = 0;
        List<Button> sequencia;
        Color corPadrao;
        Color corPiscando;
        bool piscando = false;
        int lvl = 0;

        string verdePadrao = "#004700";
        string amareloPadrao = "#F0B200";
        string vermelhoPadrao = "#A80A00";
        string azulPadrao = "#ADD8E6";

        string verdePiscando = "#008A00";
        string amareloPiscando = "#FFD847";
        string vermelhoPiscando = "#F50E00";
        string azulPiscando = "#0fffff";

        private Label lbLvl;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btVerde = new Button();
            BtStart = new Button();
            btAmarelo = new Button();
            btVermelho = new Button();
            btAzul = new Button();
            lbLvl = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btVerde
            // 
            btVerde.Location = new Point(42, 31);
            btVerde.Name = "btVerde";
            btVerde.Size = new Size(76, 74);
            btVerde.TabIndex = 3;
            btVerde.UseVisualStyleBackColor = true;
            // 
            // BtStart
            // 
            BtStart.Location = new Point(87, 280);
            BtStart.Name = "BtStart";
            BtStart.Size = new Size(75, 23);
            BtStart.TabIndex = 4;
            BtStart.Text = "Começar";
            BtStart.UseVisualStyleBackColor = true;
            BtStart.Click += BtStart_Click;
            // 
            // btAmarelo
            // 
            btAmarelo.Location = new Point(133, 31);
            btAmarelo.Name = "btAmarelo";
            btAmarelo.Size = new Size(76, 74);
            btAmarelo.TabIndex = 5;
            btAmarelo.UseVisualStyleBackColor = true;
            // 
            // btVermelho
            // 
            btVermelho.Location = new Point(42, 127);
            btVermelho.Name = "btVermelho";
            btVermelho.Size = new Size(76, 74);
            btVermelho.TabIndex = 6;
            btVermelho.UseVisualStyleBackColor = true;
            // 
            // btAzul
            // 
            btAzul.Location = new Point(133, 127);
            btAzul.Name = "btAzul";
            btAzul.Size = new Size(76, 74);
            btAzul.TabIndex = 7;
            btAzul.UseVisualStyleBackColor = true;
            // 
            // lbLvl
            // 
            lbLvl.AutoSize = true;
            lbLvl.Font = new Font("Segoe UI", 24F);
            lbLvl.Location = new Point(106, 217);
            lbLvl.Name = "lbLvl";
            lbLvl.Size = new Size(0, 45);
            lbLvl.TabIndex = 8;
            // 
            // timer1
            // 
            timer1.Interval = 250;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            ClientSize = new Size(253, 328);
            Controls.Add(lbLvl);
            Controls.Add(btAzul);
            Controls.Add(btVermelho);
            Controls.Add(btAmarelo);
            Controls.Add(BtStart);
            Controls.Add(btVerde);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        public Form1()
        {
            InitializeComponent();

            btVerde.BackColor = ColorTranslator.FromHtml(verdePadrao);
            btAmarelo.BackColor = ColorTranslator.FromHtml(amareloPadrao);
            btVermelho.BackColor = ColorTranslator.FromHtml(vermelhoPadrao);
            btAzul.BackColor = ColorTranslator.FromHtml(azulPadrao);

            btVerde.FlatStyle = FlatStyle.Flat;
            btAmarelo.FlatStyle = FlatStyle.Flat;
            btVermelho.FlatStyle = FlatStyle.Flat;
            btAzul.FlatStyle = FlatStyle.Flat;

            btVerde.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(verdePadrao);
            btAmarelo.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(amareloPadrao);
            btVermelho.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(vermelhoPadrao);
            btAzul.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(azulPadrao);

            btVerde.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml(verdePiscando);
            btAmarelo.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml(amareloPiscando);
            btVermelho.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml(vermelhoPiscando);
            btAzul.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml(azulPiscando);

            btVerde.Cursor = Cursors.Hand;
            btAmarelo.Cursor = Cursors.Hand;
            btVermelho.Cursor = Cursors.Hand;
            btAzul.Cursor = Cursors.Hand;
        }

        private void BtStart_Click(object sender, EventArgs e)
        {
            sequencia = new List<Button>();
            BtStart.Enabled = false;
            lvl++;
            lbLvl.Text = lvl.ToString();

            gerarSequencia();
            Vez(false);
            Piscando();
        }

        private void gerarSequencia()
        {
            Random random = new Random();
            int num = random.Next(0, 4);

            Button bt = null;

            switch (num)
            {
                case 0:
                    bt = btVerde;
                    break;
                case 1:
                    bt = btAmarelo;
                    break;
                case 2:
                    bt = btVermelho;
                    break;
                case 3:
                    bt = btAzul;
                    break;
            }
            sequencia.Add(bt);
        }

        private void Piscando()
        {
            sequencia_atual = 0;
            aux = 0;
            AtualizarCoresPiscando();
            timer1.Start();
        }

        private void AtualizarCoresPiscando()
        {
            Button botaoAtual = sequencia[sequencia_atual];

            if (botaoAtual == btVerde)
                corPiscando = ColorTranslator.FromHtml(verdePiscando);
            else if (botaoAtual == btAmarelo)
                corPiscando = ColorTranslator.FromHtml(amareloPiscando);
            else if (botaoAtual == btVermelho)
                corPiscando = ColorTranslator.FromHtml(vermelhoPiscando);
            else if (botaoAtual == btAzul)
                corPiscando = ColorTranslator.FromHtml(azulPiscando);

            corPadrao = botaoAtual.BackColor;
        }

        private void Vez(bool habilita)
        {
            btVerde.Enabled = habilita;
            btAmarelo.Enabled = habilita;
            btVermelho.Enabled = habilita;
            btAzul.Enabled = habilita;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!piscando)
            {
                sequencia[sequencia_atual].BackColor = corPiscando;
                piscando = true;
            }
            else
            {
                sequencia[sequencia_atual].BackColor = corPadrao;
                piscando = false;
                aux++;

                if (aux < sequencia.Count)
                {
                    sequencia_atual++;
                    AtualizarCoresPiscando();
                }
                else
                {
                    timer1.Stop();
                    Vez(true);
                }
            }
        }
    }
}
