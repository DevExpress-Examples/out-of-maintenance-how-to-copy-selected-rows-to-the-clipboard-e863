using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SelectedValues {

    public static class DataHelper {
        public static BindingList<Record> GetData(int count) {
            BindingList<Record> records = new BindingList<Record>();
            for (int i = 0; i < count; i++)
                records.Add(new Record() {
                    ID = i,
                    ParentID = i % 10,
                    Text = string.Format("Text {0}", i),
                    Dt = DateTime.Today.AddDays(i),
                    Value = i % 2 == 0 ? i * 0.13M : i * 0.012M,
                    State = i % 2 == 0,
                    Info = string.Format("Line{0}", i)
                });
            return records;
        }
    }

    public class Record : INotifyPropertyChanged {
        public Record() {
        }
        int id;
        public int ID {
            get { return id; }
            set {
                if (id != value) {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }
        int parentID;
        public int ParentID {
            get { return parentID; }
            set {
                if (parentID != value) {
                    parentID = value;
                    OnPropertyChanged();
                }
            }
        }
        string text;
        public string Text {
            get { return text; }
            set {
                if (text != value) {
                    text = value;
                    OnPropertyChanged();
                }
            }
        }
        string info;
        public string Info {
            get { return info; }
            set {
                if (info != value) {
                    info = value;
                    OnPropertyChanged();
                }
            }
        }
        decimal? val;
        public decimal? Value {
            get { return val; }
            set {
                if (val != value) {
                    val = value;
                    OnPropertyChanged();
                }
            }
        }
        DateTime dt;
        public DateTime Dt {
            get { return dt; }
            set {
                if (dt != value) {
                    dt = value;
                    OnPropertyChanged();
                }
            }
        }
        bool state;
        public bool State {
            get { return state; }
            set {
                if (state != value) {
                    state = value;
                    OnPropertyChanged();
                }
            }
        }

        public override string ToString() {
            return string.Format("ID = {0}, Text = {1}", ID, Text);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] String propertyName = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
