using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace _1.Cars
{
    public partial class _Default : System.Web.UI.Page
    {
        private static List<Model> bmwModels = new List<Model>()
        {
            new Model("A6"),
            new Model("E60"),
            new Model("E30"),
        };

        private static List<Model> volkswagenModels = new List<Model>()
        {
            new Model("Golf 2"),
            new Model("Phaeton"),
            new Model("Passat"),
        };

        private static List<Model> lamborghiniModels = new List<Model>()
        {
            new Model("Diablo"),
            new Model("Gallardo"),
        };

        private static List<Producer> producers = new List<Producer>()
        {
            new Producer("BMW", bmwModels),
            new Producer("Volkswagen", volkswagenModels),
            new Producer("Lamborghini", lamborghiniModels),
        };

        private static List<string> modelExtras = new List<string>()
        {
            "Used", "Brand new", "Dismentled",
        };

        private static string[] engines = 
        {
            "Diesel", "Petrol", "Electric",
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.DropDownListProducer.DataSource = producers;
                this.DropDownListProducer.DataBind();


                this.CheckBoxListExtras.DataSource = modelExtras;
                this.CheckBoxListExtras.DataBind();

                this.RadioButtonListEngine.DataSource = engines;
                this.RadioButtonListEngine.DataBind();

            }
        }

        protected void DropDownListProducer_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            int indexSelectedProducer = this.DropDownListProducer.SelectedIndex;
            this.DropDownListModel.DataSource =
                producers[indexSelectedProducer].Models;
            this.DropDownListModel.DataBind();

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Producer: " + 
                this.DropDownListProducer.SelectedItem.Value + "\n");
            builder.AppendLine("Model: " +
                this.DropDownListModel.SelectedItem.Value + "\n");

            AppendCheckBoxList(builder);
            AppendRadioList(builder);
            this.LiteralCarInfo.Text = builder.ToString();
        }

        private void AppendRadioList(StringBuilder builder)
        {
            builder.AppendLine("Engine: ");
            for (int i = 0; i < this.RadioButtonListEngine.Items.Count; i++)
            {
                if (this.RadioButtonListEngine.Items[i].Selected)
                {
                    builder.AppendLine(this.RadioButtonListEngine.Items[i].Value);
                }
            }
        }

        private void AppendCheckBoxList(StringBuilder builder)
        {
            builder.AppendLine("Extras: ");
            for (int i = 0; i < this.CheckBoxListExtras.Items.Count; i++)
            {
                if (this.CheckBoxListExtras.Items[i].Selected)
                {
                    builder.AppendLine(this.CheckBoxListExtras.Items[i].Value + ",");
                }
            }
        }
    }
}
