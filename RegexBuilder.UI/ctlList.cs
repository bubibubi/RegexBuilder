using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace RegexBuilder.UI
{
    public partial class ctlList : UserControl
    {
        public ctlList()
        {
            InitializeComponent();
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListBox.ObjectCollection Items
        {
            get { return list.Items; }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get { return list.SelectedItem; }
        }


        public bool ButtonsEnabled
        {
            get
            {
                return btnAdd.Enabled;
            }
            set
            {
                btnAdd.Enabled = value;
                btnRemove.Enabled = value;
            }
        }

        public event EventHandler Add;

        protected virtual void OnAdd(EventArgs e)
        {
            if (Add != null)
                Add(this, e);
        }


        public event EventHandler Remove;

        protected virtual void OnRemove(EventArgs e)
        {
            if (Remove != null)
                Remove(this, e);
        }


        public event EventHandler Edit;

        protected virtual void OnEdit(EventArgs e)
        {
            if (Edit != null)
                Edit(this, e);
        }


        public event EventHandler SelectedItemChanged;

        protected virtual void OnSelectedItemChanged(EventArgs e)
        {
            if (SelectedItemChanged != null)
                SelectedItemChanged(this, e);
        }

        private void list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (list.SelectedItem != null)
                OnEdit(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAdd(e);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            OnRemove(e);
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedItemChanged(e);
        }

        public void AddItems(IEnumerable items)
        {
            list.Items.Clear();
            list.Items.AddRange(items.Cast<object>().ToArray());
        }
    }
}
