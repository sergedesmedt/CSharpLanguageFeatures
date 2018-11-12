using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValueTuples.Binding.WinForms
{
    public partial class Form1 : Form
    {
        public class CollectonData
        {
            public string DataKey { get; set; }
            public int DataValue { get; set; }
            public bool SomeExtraData { get; set; }
        }

        public struct ValueTypeSource
        {
            public string SourceforValueTypeText1;
            public string SourceforValueTypeText2 { get; set; }
        }

        public Form1()
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

            var anonymousDataSource = new 
            {
                SourceforAnonymousTypeText1 = "SourceforAnonymousTypeTextValue1",
                SourceforAnonymousTypeText2 = "SourceforAnonymousTypeTextValue2",

                AnonymousSourceList = collectionSource.Where(s => s.SomeExtraData == false).Select(s => new { s.DataKey, s.DataValue }).ToList()
            };

            textBoxForAnonymousType.DataBindings.Add("Text", anonymousDataSource, "SourceforAnonymousTypeText1");
        }

        private void SetDataSourceWithValueTypes()
        {
            var valueTypeDataSource = new ValueTypeSource();
            valueTypeDataSource.SourceforValueTypeText1 = "SourceforValueTypeTextValue1";
            valueTypeDataSource.SourceforValueTypeText2 = "SourceforValueTypeTextValue2";

            textBoxForTupleType.DataBindings.Add("Text", valueTypeDataSource, "SourceforValueTypeText2");
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

            var anonymousDataSource =
            (
                SourceforValueTypeText1: "SourceforValueTypeTextValue1",
                SourceforValueTypeText2: "SourceforValueTypeTextValue2",

                ValueTypeSourceList: collectionSource.Where(s => s.SomeExtraData == false).ToList()
            );

            textBoxForTupleType.DataBindings.Add("Text", anonymousDataSource, "SourceforValueTypeText1");
        }
    }
}
