using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualisasiGraf
{
    public partial class SimulationWindow : Form
    {

        public int daysValue;
        private Visualizer graph;

        public SimulationWindow()
        {
            InitializeComponent();
            daysValue = 0;
            graph = new Visualizer();
        }

        private void simulateButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pisang");
            graph.BFS(daysValue);

            // Inititalize MSAGL graph
            Microsoft.Msagl.Drawing.Graph graphMSAGL = new Microsoft.Msagl.Drawing.Graph("graphMSAGL");


            // For each infected edges draw red edge
            foreach (Tuple<int, int> edge in graph.infectedEdge)
                graphMSAGL.AddEdge(edge.Item1.ToString(), edge.Item2.ToString()).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;

            // For each uninfected edges draw black edge
            foreach (Tuple<int, int> edge in graph.uninfectedEdge)
            {
                graphMSAGL.AddEdge(edge.Item1.ToString(), edge.Item2.ToString());
            }

            // If node infected, set node color to red
            for (int i = 0; i < graph.nodeCount; i++)
            {
                if (graph.infected[i])
                    graphMSAGL.FindNode(i.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                else
                    graphMSAGL.FindNode(i.ToString());

            }

            // Wrap graph in the graphWindow
            graph.viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            graph.viewer.Graph = graphMSAGL;
            this.label1.Text = graph.printed;
            Form graphForm = new Form();
            Form explanationForm = new Form();

            graphForm.SuspendLayout();
            graphForm.Controls.Add(graph.viewer);

            explanationForm.SuspendLayout();
            explanationForm.Controls.Add(label1);

            graphForm.TopLevel = false;
            graphForm.WindowState = FormWindowState.Maximized;
            graphForm.FormBorderStyle = FormBorderStyle.None;

            explanationForm.TopLevel = false;
            explanationForm.WindowState = FormWindowState.Maximized;
            explanationForm.FormBorderStyle = FormBorderStyle.None;

            graphPanel.Controls.Add(graphForm);
            panel1.Controls.Add(explanationForm);

            graphForm.ResumeLayout();
            explanationForm.ResumeLayout();

            graphForm.Show();
            explanationForm.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SimulateButton.Text = "Simulate";
            DayInputField.Text = "0";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (DayInputField.Text == "") daysValue = 0;
            else daysValue = int.Parse(DayInputField.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PathOutput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
