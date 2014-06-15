using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCBS.CoreDomain;
using OpenCBS.Services;

namespace OpenCBS.GUI.UserControl
{
    public partial class CityTextBox : TextBox
    {
        private IList<City> _autoCompleteSource = null;
        private ToolStripDropDown _dropDown = null;
        private ListBox _box = null;
        public bool dropDownEnabled = false;

        public IList<City> MyAutoCompleteSource
        {
            get { return _autoCompleteSource; }
            set { _autoCompleteSource = value; 
                if(_autoCompleteSource!=null)
                    SortByName();}
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (_box != null)
            {
                if (this.Text != "")
                {
                    _box.Items.Clear();
                    var legalStrings = from item in _autoCompleteSource
                                       where item.Name.ToUpper().StartsWith(this.Text.Trim().ToUpper())
                                       select item.Name;
                    if (legalStrings.Count<string>() > 0)
                    {
                        foreach (string str in legalStrings)
                        {
                            _box.Items.Add(str);
                        }
                        if (_dropDown != null && dropDownEnabled)
                        {
                            UpdateDropDownSize();
                            _dropDown.Show(this, new Point(0, this.Height));
                            _dropDown.AutoClose = true;
                        }
                    }
                    else
                    {
                        _dropDown.Close();
                    }
                }
                else
                    _dropDown.Close();
            }
        }

        private void UpdateDropDownSize()
        {
            Size len, maxLen = new Size(this.Width - 2, _box.Height);
            foreach (string str in _box.Items)
            {
                len = TextRenderer.MeasureText(str, _box.Font);
                if (maxLen.Width < len.Width)
                    maxLen.Width = len.Width;
            }
            _box.Width = maxLen.Width;
            if (_box.Items.Count < 10)
                _box.Height = _box.ItemHeight*(_box.Items.Count + 1);
            else _box.Height = _box.ItemHeight*10;
            maxLen.Height = _box.Height;
            _dropDown.Size = maxLen;
        }

        public void SortByName()
        {
            List<City> SortedList =
                (from c in _autoCompleteSource orderby c.Name select c)
                    .ToList<City>();
            _autoCompleteSource = SortedList;
            for (int i = 0; i < _autoCompleteSource.Count - 1; i++)
            {
                if (_autoCompleteSource[i].Name == _autoCompleteSource[i + 1].Name)
                {
                    District dist =
                        ServicesProvider.GetInstance()
                                        .GetLocationServices()
                                        .FindDistirctById(_autoCompleteSource[i].DistrictId);
                    _autoCompleteSource[i].Name += " (" + dist.Name + ")";
                    AddDistrictrForSameNames(i, i + 1);
                }
            }
        }

        private void AddDistrictrForSameNames(int i, int j)
        {
            District dist =
                ServicesProvider.GetInstance().GetLocationServices().FindDistirctById(_autoCompleteSource[j].DistrictId);
            _autoCompleteSource[j].Name += " (" + dist.Name + ")";
            if (j + 1 < _autoCompleteSource.Count && _autoCompleteSource[i].Name == _autoCompleteSource[j + 1].Name)
                AddDistrictrForSameNames(i, j + 1);
        }

        public bool IsValueInSource
        {
            get
            {
                if (_autoCompleteSource == null) return true;
                else
                {
                    var data = from item in _autoCompleteSource
                               where item.Name.ToUpper() == this.Text.Trim().ToUpper()
                               select item.Name;
                    if (data.Count<string>() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public City GetCity()
        {
            City selectedCity = null;
            if (_box!=null)
                foreach (City city in _autoCompleteSource)
                {
                    if (city.Name != this.Text)
                    {
                        continue;
                    }
                    selectedCity = city;
                    break;
                }
            return selectedCity;
        }
        
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _dropDown = new ToolStripDropDown();
            _box = new ListBox();
            _box.Width = this.Width - 2;
            _box.KeyDown += (KeyEventHandler)((sender, k) =>
            {
                if (k.KeyCode == Keys.Enter)
                {
                    this.Text = _box.SelectedItem.ToString();
                    _dropDown.Close();
                }
                _dropDown.AutoClose = true;
                if (k.KeyCode == Keys.Escape)
                    _dropDown.Close();
            });
            _box.Click += (EventHandler)((sender, arg) =>
                {
                    this.Text = _box.SelectedItem.ToString();
                    _dropDown.Close();
                });
            _box.MouseMove += (MouseEventHandler)((sender, m) =>
            {
                int index = _box.IndexFromPoint(m.Location);
                _box.SelectedIndex = index;
            });
            ToolStripControlHost host = new ToolStripControlHost(_box);
            host.AutoSize = false;
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            _dropDown.Items.Add(host);
            _dropDown.Height = _box.Height;
            _dropDown.AutoSize = false;
            _dropDown.Margin = Padding.Empty;
            _dropDown.Padding = Padding.Empty;
            _dropDown.Size = host.Size = _box.Size;
            _dropDown.AutoClose = false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            _dropDown.AutoClose = true;
            if (e.KeyCode == Keys.Down && dropDownEnabled && _box.Items.Count > 0)
            {
                _dropDown.Show(this, new Point(0, this.Height));
                _box.Focus();
                if (_box.SelectedIndex < _box.Items.Count - 1)
                    _box.SelectedIndex++;
                SendKeys.Send(Keys.Down.ToString());
            }
            if (e.KeyCode == Keys.Enter && _box.SelectedIndex > -1)
            {
                this.Text = _box.SelectedItem.ToString();
                _dropDown.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                _dropDown.Close();
            }
            _dropDown.AutoClose = false;
            base.OnKeyDown(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            dropDownEnabled = true;
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            _dropDown.Close();
            base.OnLeave(e);
        }
    }
}
