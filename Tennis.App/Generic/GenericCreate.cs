using System;
using System.Collections;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Tennis.App.Api;
using Tennis.DTO.Attributes;

namespace Tennis.App.Generic
{
    public delegate void Done();

    public class GenericCreate<T> where T : class
    {
        public event Done Done;

        private int rows;
        private int cols;
        private Panel panel;
        T o;

        public GenericCreate(Grid panel, T o, int rows = 3, int cols = 5)
        {
            this.panel = panel;
            this.o = o;
            this.rows = rows;
            this.cols = cols;
        }

        /// <summary>
        /// Generates the create layout
        /// </summary>
        public async Task Generate()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            Grid gr = new Grid();
            panel.Children.Clear();
            panel.Children.Add(gr);
            for (int i = 0; i < rows; i++)
            {
                gr.RowDefinitions.Add(new RowDefinition() { MaxHeight = 30 });
            }
            for (int i = 0; i < cols; i++)
            {
                gr.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < properties.Length; i++)
            {
                int row = i / cols;
                int col = i % cols;

                Grid g = new Grid();
                gr.Children.Add(g);
                g.ColumnDefinitions.Add(new ColumnDefinition());
                g.ColumnDefinitions.Add(new ColumnDefinition());

                g.SetValue(Grid.RowProperty, row);
                g.SetValue(Grid.ColumnProperty, col);

                var prop = properties[i];
                string name = prop.Name;

                Label l = new Label();

                l.Content = name;

                Control txtB;
                if (properties[i].PropertyType == typeof(DateTime))
                {
                    txtB = new DatePicker();
                    ((DatePicker)txtB).SelectedDate = DateTime.Now;
                    SetBinding(txtB, name, o, DatePicker.SelectedDateProperty);
                }
                else if (DropDownAttribute.GetAttribute(prop) != null)
                {
                    var d = DropDownAttribute.GetAttribute(prop);
                    txtB = new ComboBox();
                    var reslult = await GenericAPI.GetAll(d.Endpoint, d.Target);
                    ((ComboBox)txtB).ItemsSource = (IEnumerable)reslult;
                    ((ComboBox)txtB).DisplayMemberPath = d.SelectName;
                    ((ComboBox)txtB).SelectedValuePath = "Id";
                    SetBinding((ComboBox)txtB, name, o, "Id");
                }
                else
                {
                    txtB = new TextBox();
                    SetBinding(txtB, name, o, TextBox.TextProperty);
                }

                txtB.SetValue(Grid.ColumnProperty, 1);

                g.Children.Add(l);
                g.Children.Add(txtB);
            }
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.VerticalAlignment = VerticalAlignment.Bottom;

            // btn.SetValue(Grid.RowProperty, cols -1);
            // btn.SetValue(Grid.ColumnProperty, rows - 1);

            btn.Click += (sender, args) =>
            {
                Done?.Invoke();
            };
            btn.Content = "Create";
            panel.Children.Add(btn);
        }

        private void SetBinding(Control cont, string name, T o, DependencyProperty dependencyProperty)
        {
            Binding myBinding = new Binding(name);
            myBinding.Source = o;
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(cont, dependencyProperty, myBinding);
        }

        private void SetBinding(ComboBox cont, string name, T o, string path)
        {
            cont.SelectionChanged += (s, a) =>
            {
                var sel = cont.SelectedItem;
                o.GetType().GetProperty(name).SetValue(o, sel.GetType().GetProperty(path).GetValue(sel));
            };
        }
    }
}
