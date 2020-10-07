using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakfastForLumberjacksCh8
{
    public partial class Form1 : Form
    {
        Queue<Lumberjack> breakfastLine;
        public Form1()
        {
            InitializeComponent();
            breakfastLine = new Queue<Lumberjack>();
        }

        private void addLumberjack_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lumberjackName.Text)) { return; }
            breakfastLine.Enqueue(new Lumberjack(lumberjackName.Text));
            lumberjackName.Text = "";
            RedrawList();
        }

        private void RedrawList()
        {
            int number = 1;
            line.Items.Clear();
            foreach (Lumberjack lumberjack in breakfastLine)
            {
                line.Items.Add(number + ". " +  lumberjack.Name);
                number++;
            }
            if (breakfastLine.Count == 0)
            {
                addFlapjacks.Enabled = false;
                nextLumberjack.Enabled = false;
            }
            else
            {
                addFlapjacks.Enabled = true;
                nextLumberjack.Enabled = true;
                Lumberjack currentLumberjack = breakfastLine.Peek();
                nextInLine.Text = currentLumberjack.Name + " has "
                    + currentLumberjack.FlapjackCount + " flapjacks";
            }
        }

        private void addFlapjacks_Click(object sender, EventArgs e)
        {
            Flapjack food;
            if (breakfastLine.Count == 0)
            {
                return;
            }

            if (crispy.Checked == true)
            {
                food = Flapjack.Crispy;
            }
            else if (soggy.Checked == true)
            {
                food = Flapjack.Soggy;
            }
            else if (browned.Checked == true)
            {
                food = Flapjack.Browned;
            }
            else
            {
                food = Flapjack.Banana;
            }
            Lumberjack currentLumberjack = breakfastLine.Peek();
            currentLumberjack.TakeFlapjacks(food,
                (int)howMany.Value);

            RedrawList();
        }

        private void nextLumberjack_Click(object sender, EventArgs e)
        {
            breakfastLine.Dequeue().EatFlapjacks();
            RedrawList();
        }
    }
}
