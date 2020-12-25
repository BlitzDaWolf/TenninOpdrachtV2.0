using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using Tennis.DTO.Attributes;
using System.Windows;
using System.Windows.Data;

namespace Tennis.App.Generic
{
    public delegate void Change<T>(T filter) where T : class;

    public class GenericFilter<T> where T : class, new()
    {
        private readonly Panel panel;
        public List<T> FilterdItems = new List<T>();
        public object filters = new object();

        public event Change<T> Change;

        private T filterObject = new T();

        public GenericFilter(Panel panel)
        {
            this.panel = panel;
        }

        public void Generate()
        {
            int curCols = 0;
            PropertyInfo[] properties = typeof(T).GetProperties();

            Grid gr = new Grid();
            panel.Children.Clear();
            panel.Children.Add(gr);

            for (int i = 0; i < properties.Length; i++)
            {
                Grid child = new Grid();

                var prop = properties[i];
                string name = prop.Name;

                FilterAttribute attribute = FilterAttribute.GetAttribute(prop);
                if (attribute  == null) continue;

                Label l = new Label();
                l.Content = prop.Name;

                TextBox tb = new TextBox();
                SetBinding(tb, name, filterObject, TextBox.TextProperty);

                l.SetValue(Grid.ColumnProperty, 0);
                tb.SetValue(Grid.ColumnProperty, 1);

                child.SetValue(Grid.ColumnProperty, curCols);
                curCols++;
                filterObject.GetType().GetProperty(name).SetValue(filterObject, "");

                tb.TextChanged += (sender, a) =>
                {
                    Change?.Invoke(filterObject);
                };

                child.ColumnDefinitions.Add(new ColumnDefinition());
                child.ColumnDefinitions.Add(new ColumnDefinition());
                child.Children.Add(l);
                child.Children.Add(tb);

                gr.Children.Add(child);
            }

            for (int i = 0; i < curCols; i++)
            {
                gr.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void SetBinding(Control cont, string name, T o, DependencyProperty dependencyProperty)
        {
            Binding myBinding = new Binding(name);
            myBinding.Source = o;
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(cont, dependencyProperty, myBinding);
        }
    }
}
