using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ValueTuples.Binding.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class CollectonData
        {
            public string DataKey { get; set; }
            public int DataValue { get; set; }
            public bool SomeExtraData { get; set; }
        }

        public struct ValueTypeData
        {
            public string DataKeyField;
            public int DataValueField;
            public string DataKey { get; set; }
            public int DataValue { get; set; }
            public bool SomeExtraData { get; set; }
        }

        public struct ValueTypeSource
        {
            public string SourceforValueTypeText1;
            public string SourceforValueTypeText2 { get; set; }
            public List<ValueTypeData> ValueTypeSourceList { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            SetDataSourceWithValueTypes();
        }

        private void SetDataSourceWithAnonymousTypes()
        {
            var collectionSource = new List<CollectonData>()
            {
                new CollectonData(){ DataKey = "10", DataValue = 1, SomeExtraData = false },
                new CollectonData(){ DataKey = "20", DataValue = 2, SomeExtraData = true },
                new CollectonData(){ DataKey = "30", DataValue = 3, SomeExtraData = false },
                new CollectonData(){ DataKey = "40", DataValue = 4, SomeExtraData = true },
                new CollectonData(){ DataKey = "50", DataValue = 5, SomeExtraData = false },
            };

            AnonymousTypeBinding.DataContext = new
            {
                SourceforAnonymousTypeText1 = "SourceforAnonymousTypeTextValue1",
                SourceforAnonymousTypeText2 = "SourceforAnonymousTypeTextValue2",

                AnonymousSourceList = collectionSource.Where(s => s.SomeExtraData == false).Select(s => new { s.DataKey, s.DataValue }).ToList()
            };
        }

        private void TargetforSourceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var theComboBox = sender as ComboBox;
            if(theComboBox.SelectedValue != null)
                Debug.WriteLine("The selected value using Anonymous Types is " + theComboBox.SelectedValue);
        }

        private void SetDataSourceWithValueTypes()
        {
            var collectionSourceWithAssignedProperties = new List<ValueTypeData>()
            {
                new ValueTypeData(){ DataKey = "10", DataValue = 1, SomeExtraData = false},
                new ValueTypeData(){ DataKey = "20", DataValue = 2, SomeExtraData = true},
                new ValueTypeData(){ DataKey = "30", DataValue = 3, SomeExtraData = false},
                new ValueTypeData(){ DataKey = "40", DataValue = 4, SomeExtraData = true},
                new ValueTypeData(){ DataKey = "50", DataValue = 5, SomeExtraData = false},
            };

            var collectionSourceWithAssignedFields = new List<ValueTypeData>()
            {
                new ValueTypeData(){ DataKeyField = "10", DataValueField = 1, SomeExtraData = false},
                new ValueTypeData(){ DataKeyField = "20", DataValueField = 2, SomeExtraData = true},
                new ValueTypeData(){ DataKeyField = "30", DataValueField = 3, SomeExtraData = false},
                new ValueTypeData(){ DataKeyField = "40", DataValueField = 4, SomeExtraData = true},
                new ValueTypeData(){ DataKeyField = "50", DataValueField = 5, SomeExtraData = false},
            };

            var valueTypeDataSource = new ValueTypeSource();
            valueTypeDataSource.SourceforValueTypeText1 = "SourceforValueTypeTextValue1";
            valueTypeDataSource.SourceforValueTypeText2 = "SourceforValueTypeTextValue2";
            valueTypeDataSource.ValueTypeSourceList = collectionSourceWithAssignedProperties.Where(s => s.SomeExtraData == false).ToList();

            ValueTypeBinding.DataContext = valueTypeDataSource;
        }

        private void SetDataSourceWithNamedValueTuples()
        {
            var collectionSource = new List<(string DataKey, int DataValue, bool SomeExtraData)>()
            {
                (DataKey : "10", DataValue : 1, SomeExtraData : false),
                (DataKey : "20", DataValue : 2, SomeExtraData : true),
                (DataKey : "30", DataValue : 3, SomeExtraData : false),
                (DataKey : "40", DataValue : 4, SomeExtraData : true),
                (DataKey : "50", DataValue : 5, SomeExtraData : false),
            };

            // No binding takes place: ValueTuples are structs with fields and not properties, and thus cannot be bound
            ValueTypeBinding.DataContext = 
            (
                SourceforValueTypeText1: "SourceforValueTypeTextValue1",
                SourceforValueTypeText2: "SourceforValueTypeTextValue2",

                ValueTypeSourceList : collectionSource.Where(s => s.SomeExtraData == false).ToList()
            );
        }
    }
}
