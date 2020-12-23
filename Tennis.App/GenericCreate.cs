using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Tennis.App.Api;
using Tennis.DTO;

namespace Tennis.App
{
    public delegate void Done();

    public class GenericCreate<T> where T : class
    {
        public event Done Done;

        private Panel panel;
        T o;
        public GenericCreate(Panel panel, T o)
        {
            this.panel = panel;
            this.o = o;
        }

        public async Task Generate()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                string oth = "";
                var prop = properties[i];
                string name = prop.Name;

                Label l = new Label();

                l.Content = name;

                Control txtB;
                if (properties[i].PropertyType == typeof(DateTime))
                {
                    txtB = new DatePicker();
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
                    oth = "Id";
                    SetBinding((ComboBox)txtB, name, o, "Id");
                }
                else
                {
                    txtB = new TextBox();
                    SetBinding(txtB, name, o, TextBox.TextProperty);
                }

                panel.Children.Add(l);
                panel.Children.Add(txtB);
            }
            Button btn = new Button();
            btn.Click += (sender, args) =>
            {
                Done?.Invoke();
            };
            btn.Content = "Create";
            panel.Children.Add(btn);
        }

        public void SetBinding(Control cont, string name, T o, DependencyProperty dependencyProperty)
        {
            Binding myBinding = new Binding(name);
            myBinding.Source = o;
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(cont, dependencyProperty, myBinding);
        }

        public void SetBinding(ComboBox cont, string name, T o, string path)
        {
            cont.SelectionChanged += (s, a) =>
            {
                var sel = cont.SelectedItem;
                o.GetType().GetProperty(name).SetValue(o, sel.GetType().GetProperty(path).GetValue(sel));
            };
        }
    }
}
